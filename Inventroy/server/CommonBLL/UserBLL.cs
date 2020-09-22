using CommonBLL.Helper;
using CommonDAL.Models;
using CommonDAL.Repository;
using CommonDAL.ViewModels;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonBLL
{
    public class UserBLL
    {
        private readonly IRepository<User> userRepository;
        private readonly IRepository<Employee> employeeRepositoty;
        private readonly IRepository<Shop> shopRepository;
        private readonly IRepository<UserType> userTypeRepository;
        private readonly IRepository<UserCreateRequest> userCreateRequestRepository;
        private readonly IRepository<Organization> organizationRepository;

        public UserBLL(IRepository<User> userRepository, IRepository<Employee> employeeRepositoty, IRepository<Shop> shopRepository,
            IRepository<UserType> userTypeRepository, IRepository<UserCreateRequest> userCreateRequestRepository, IRepository<Organization> organizationRepository)
        {
            this.userRepository = userRepository;
            this.employeeRepositoty = employeeRepositoty;
            this.shopRepository = shopRepository;
            this.userTypeRepository = userTypeRepository;
            this.userCreateRequestRepository = userCreateRequestRepository;
            this.organizationRepository = organizationRepository;
        }
        public async Task<UserCreateDataViewModel> GetUserCreateDataAsync()
        {
            try
            {
                IEnumerable<Employee> employees = await employeeRepositoty.GetAsync();
                IEnumerable<Shop> shops = await shopRepository.GetAsync();
                IEnumerable<UserType> userTypes = await userTypeRepository.GetAsync();

                if (employees != null)
                {
                    UserCreateDataViewModel userCreateDataViewModel = new UserCreateDataViewModel();
                    userCreateDataViewModel.Employees = employees.ToList();
                    userCreateDataViewModel.UserTypes = userTypes.ToList();
                    userCreateDataViewModel.Shops = shops.ToList();
                    return userCreateDataViewModel;
                }
            }
            catch(Exception e)
            {

            }
            return null;
        }
        public async Task<UserCreateRequestViewModel> GetByTokenAsync(UserCreateRequestViewModel model)
        {
            try
            {
                IEnumerable<UserCreateRequest> userCreateRequest = await userCreateRequestRepository.GetAsync();

                if (userCreateRequest != null)
                {
                    UserCreateRequest request = userCreateRequest.Where(x => x.VarificationCode == model.VarificationCode).FirstOrDefault();
                    if (request != null)
                    {
                        return assignDataToUserCreateRequestViewModel(request);
                    }
                }
            }
            catch(Exception e)
            {

            }
            
            return null;
        }
        public async Task<UserCreateRequestViewModel> AddUserRequest(UserCreateRequestViewModel model, ApplicationUser token)
        {
            try
            {
                Employee employee = await employeeRepositoty.GetAsync((int)model.EmployeeId);
                UserCreateRequest userCreateRequest = new UserCreateRequest
                {
                    EmployeeId = model.EmployeeId,
                    UserType = model.UserType,
                    RequestDate = DateTime.Now,
                    ShopId = model.ShopId,
                    Status = (byte)Enums.ApplicationStatus.Drafted,
                    VarificationCode = Guid.NewGuid().ToString(),
                    Email = employee.Email,
                    MobileNo = employee.Mobile,
                    RequestBy = token.Id
                };

                UserCreateRequest result = await userCreateRequestRepository.AddAsync(userCreateRequest);

                if (result != null)
                {
                    Organization organization = await organizationRepository.GetAsync(employee.OrganizationId);
                    Shop shop = await shopRepository.GetAsync(employee.ShopId);
                    model.Url = model.Url + "token=" + result.VarificationCode;
                    string htmlBody = Messenger.GetHTMLMessage(model.Url, employee.Name, shop.Name);
                    MessengeDetails messengeDetails = new MessengeDetails
                    {
                        ShopName = shop.Name,
                        MailForm = shop.EmailForSystemGeneratedMail,
                        MailFormPassword = shop.PasswordForSystemGeneratedMail,
                        MailTo = employee.Email,
                        MailToUserName = employee.Name,
                        MessageBodyInHTML = htmlBody,
                        MessageSubject = "Email Confirmation"
                    };
                    bool messageSent = Messenger.SendConfirmMailWithHTMLFormat(messengeDetails);
                    if (messageSent)
                    {
                        return assignDataToUserCreateRequestViewModel(result);
                    }
                }
            }
            catch (Exception e)
            {

            }
            return null;
        }
        public List<UserViewModel> GetUserForTable(UserManager<User> userManager)
        {
            try
            {
                IEnumerable<User> users = userManager.Users;

                if (users != null)
                {
                    List<UserViewModel> userViewModels = new List<UserViewModel>();

                    foreach (User user in users)
                    {
                        UserViewModel userViewModel = new UserViewModel()
                        {
                            Email = user.Email,
                            MobileNo = user.PhoneNumber,
                            Status = user.Ststus,
                            UserName = user.UserName,
                            UserTypeName = userTypeRepository.GetAsync(user.UserType).Result.Name
                        };
                        userViewModels.Add(userViewModel);
                    }
                    return userViewModels;
                }
            }
            catch(Exception e)
            {

            }
            return null;
        }
        public UserCreateRequestViewModel assignDataToUserCreateRequestViewModel(UserCreateRequest userCreateRequest)
        {
            UserCreateRequestViewModel userCreateRequestViewModel = new UserCreateRequestViewModel
            {
                EmployeeId = userCreateRequest.EmployeeId,
                OrganizationId = userCreateRequest.OrganizationId,
                RequestBy = userCreateRequest.RequestBy,
                RequestDate = userCreateRequest.RequestDate,
                RequestId = userCreateRequest.Id,
                ShopId = userCreateRequest.ShopId,
                Status = userCreateRequest.Status,
                UpdatedBy = userCreateRequest.UpdatedBy,
                UpdatedDate = userCreateRequest.UpdatedDate,
                Email = userCreateRequest.Email,
                MobileNo = userCreateRequest.MobileNo,
                UserType = userCreateRequest.UserType
            };
            return userCreateRequestViewModel;
        }
    }
}
