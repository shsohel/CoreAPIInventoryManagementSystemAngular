using CommonBLL.Enums;
using CommonBLL.Helper;
using CommonDAL.Models;
using CommonDAL.Repository;
using CommonDAL.ViewModels;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace StockBLL
{
    public class PayIncentiveBLL
    {
        private readonly IRepository<PayIncentive> repository;
        private readonly UserManager<User> userManger;
        private readonly IRepository<Employee> empRepository;

        public PayIncentiveBLL(IRepository<PayIncentive> repository, UserManager<User> userManger, IRepository<Employee> empRepository)
        {
            this.repository = repository;
            this.userManger = userManger;
            this.empRepository = empRepository;
        }
        public async Task<IEnumerable<PayIncentiveViewModel>> GetPayIncentives()
        {
            try
            {
                IEnumerable<PayIncentive> payIncentives = await repository.GetAsync();
                List<PayIncentiveViewModel> payIncentiveViewModels = new List<PayIncentiveViewModel>();
                if (payIncentives != null)
                {
                    foreach (PayIncentive payIncentive in payIncentives)
                    {
                        payIncentiveViewModels.Add(assignDataToPayIncentiveViewModel(payIncentive));
                    }
                    return payIncentiveViewModels;
                }
            }
            catch (Exception e)
            {

            }
            return null;
        }
        public async Task<PayIncentiveViewModel> GetPayIncentive(long id)
        {
            try
            {
                PayIncentive payIncentive = await repository.GetAsync(id);
                if (payIncentive != null)
                {
                    return assignDataToPayIncentiveViewModel(payIncentive);
                }
            }
            catch (Exception e)
            {

            }
            return null;
        }
        public async Task<PayIncentiveViewModel> AddPayIncentive(PayIncentiveViewModel model, ApplicationUser token)
        {
            try
            {
                PayIncentive payIncentive = new PayIncentive
                {
                    OrganizationId = token.OrganizationId,
                    ShopId = token.ShopId,
                    PayIncentiveNo= DateTime.Now.ToString("ddMMyyhhmmssmmm"),
                    ResponsibleEmpId = model.ResponsibleEmpId,
                    Amount = model.Amount,
                    IncentiveType = (int)model.IncentiveType,
                    PaidToId = model.PaidToId,
                    PaymentDate = (DateTime)model.PaymentDate,
                    PaymentType = model.PaymentType,                    
                    CreatedBy = token.Id,
                    CreatedDate = DateTime.Now,
                    Status = (byte)Status.InActive
                };
                PayIncentive result = await repository.AddAsync(payIncentive);
                model.Id = result.Id;
                if (result != null)
                {
                    return assignDataToPayIncentiveViewModel(result);
                }
            }
            catch (Exception e)
            {

            }
            return null;
        }
        public async Task<PayIncentiveViewModel> UpdatePayIncentive(PayIncentiveViewModel model, ApplicationUser toekn)
        {
            try
            {
                PayIncentive payIncentive = await repository.GetAsync((long)model.Id);
                if (payIncentive != null)
                {
                    payIncentive.ResponsibleEmpId = model.ResponsibleEmpId;
                    payIncentive.Amount = model.Amount;
                    payIncentive.IncentiveType = (int)model.IncentiveType;
                    payIncentive.PaidToId = model.PaidToId;
                    payIncentive.PaymentDate = (DateTime)model.PaymentDate;
                    payIncentive.PaymentType = model.PaymentType;
                    payIncentive.UpdatedBy = toekn.Id;
                    payIncentive.UpdatedDate = DateTime.Now;
                    payIncentive.Status = (byte)Status.Active;
                    PayIncentive result = await repository.UpdateAsync(payIncentive);
                    if (result != null)
                    {
                        return assignDataToPayIncentiveViewModel(result);
                    }
                }
            }
            catch (Exception e)
            {

            }
            return null;
        }
        public async Task<PayIncentiveViewModel> DeletePayIncentive(long id)
        {
            try
            {
                PayIncentive payIncentive = await repository.GetAsync(id);
                if (payIncentive != null)
                {
                    PayIncentive result = await repository.DeleteAsync(payIncentive);
                    if (result != null)
                    {
                        return assignDataToPayIncentiveViewModel(result);
                    }
                }
            }
            catch (Exception e)
            {

            }
            return null;
        }
        public async Task<PayIncentiveDetailsViewModel> GetDetails(long id)
        {
            try
            {
                PayIncentive payIncentive = await repository.GetAsync(id);
                if (payIncentive != null)
                {
                    PayIncentiveDetailsViewModel payIncentiveDetailsViewModel = new PayIncentiveDetailsViewModel()
                    {
                        Id = payIncentive.Id,
                        PayIncentiveNo = payIncentive.PayIncentiveNo,
                        PaidToName = empRepository.GetAsync(payIncentive.PaidToId).Result.Name,
                        PaymentTypeName = Enum.GetName(typeof(CommonBLL.Enums.PaybleType), payIncentive.PaymentType),
                        Amount = payIncentive.Amount,
                        IncentiveTypeName = Enum.GetName(typeof(CommonBLL.Enums.IncentiveType), payIncentive.IncentiveType),
                        PaymentDateString = payIncentive.PaymentDate != null ? Formater.FormatDateddMMyyyy((DateTime)payIncentive.PaymentDate) : null,
                        ResponsibleEmpName = empRepository.GetAsync(payIncentive.ResponsibleEmpId).Result.Name,
                        CreatedByName = payIncentive.CreatedBy != null ? userManger.FindByIdAsync(payIncentive.CreatedBy).Result.UserName : null,
                        CreatedDateString = payIncentive.CreatedDate != null ? Formater.FormatDateddMMyyyy((DateTime)payIncentive.CreatedDate) : null,
                        UpdatedByName = payIncentive.UpdatedBy != null ? userManger.FindByIdAsync(payIncentive.UpdatedBy).Result.UserName : null,
                        UpdatedDateString = payIncentive.UpdatedBy != null ? Formater.FormatDateddMMyyyy((DateTime)payIncentive.UpdatedDate) : null,

                        Status = payIncentive.Status
                    };
                    return payIncentiveDetailsViewModel;
                }

            }
            catch (Exception e)
            {

            }
            return null;
        }
        public async Task<List<PayIncentiveDetailsViewModel>> GetTableData()
        {
            try
            {
                IEnumerable<PayIncentive> payIncentives = await repository.GetAsync();
                List<PayIncentiveDetailsViewModel> payIncentiveDetailsViewModels = new List<PayIncentiveDetailsViewModel>();
                foreach (PayIncentive payIncentive in payIncentives)
                {
                    PayIncentiveDetailsViewModel payIncentiveDetailsViewModel = new PayIncentiveDetailsViewModel
                    {
                        Id = payIncentive.Id,
                        PayIncentiveNo = payIncentive.PayIncentiveNo,
                        PaidToName = empRepository.GetAsync(payIncentive.PaidToId).Result.Name,
                        Amount = payIncentive.Amount,
                        IncentiveTypeName = Enum.GetName(typeof(CommonBLL.Enums.IncentiveType), payIncentive.IncentiveType),
                        PaymentDateString = payIncentive.PaymentDate != null ? Formater.FormatDateddMMyyyy((DateTime)payIncentive.PaymentDate) : null,
                        ResponsibleEmpName = empRepository.GetAsync(payIncentive.ResponsibleEmpId).Result.Name,
                        Status = payIncentive.Status
                    };
                    payIncentiveDetailsViewModels.Add(payIncentiveDetailsViewModel);
                }
                if (payIncentiveDetailsViewModels != null)
                {
                    return payIncentiveDetailsViewModels;
                }
            }
            catch (Exception e)
            {

            }
            return null;
        }
        public PayIncentiveViewModel assignDataToPayIncentiveViewModel(PayIncentive payIncentive)
        {
            PayIncentiveViewModel payIncentiveViewModel = new PayIncentiveViewModel
            {
                Id = payIncentive.Id,
                OrganizationId = payIncentive.OrganizationId,
                PayIncentiveNo = payIncentive.PayIncentiveNo,
                ShopId = payIncentive.ShopId,
                IncentiveType = payIncentive.IncentiveType,
                PaidToId = payIncentive.PaidToId,
                Amount = payIncentive.Amount,
                PaymentDate = payIncentive.PaymentDate,
                PaymentType = payIncentive.PaymentType,
                ResponsibleEmpId = payIncentive.ResponsibleEmpId,
                CreatedBy = payIncentive.CreatedBy,
                CreatedDate = payIncentive.CreatedDate,
                UpdatedBy = payIncentive.UpdatedBy,
                UpdatedDate = payIncentive.UpdatedDate,
                Status = payIncentive.Status,                
            };
            return payIncentiveViewModel;
        }
    }
}
