using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CommonBLL;
using CommonBLL.Helper;
using CommonDAL.Models;
using CommonDAL.Repository;
using CommonDAL.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace IMSERP.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private string message = "Sorry! Something going wrong. Please try again.";
        private readonly IRepository<User> repository;
        private readonly UserManager<User> userManager;
        private UserBLL userBLL;
        private ApplicationUser token;
        public UserController(IRepository<User> repository, IRepository<Employee> employeeRepositoty, IRepository<Shop> shopRepository,
            IRepository<UserType> userTypeRepository, IRepository<UserCreateRequest> userCreateRequestRepository, IRepository<Organization> organizationRepository,
            UserManager<User> userManager)
        {
            userBLL = new UserBLL(repository, employeeRepositoty, shopRepository, userTypeRepository, userCreateRequestRepository, organizationRepository);
            this.userManager = userManager;
        }
        [HttpPost]
        public async Task<ActionResult> Post(UserCreateRequestViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    token = await TokenExtracter.ExtractTokenAsync(User, userManager);
                    UserCreateRequestViewModel UserCreateRequestViewModel = await userBLL.AddUserRequest(model, token);
                    if (UserCreateRequestViewModel != null)
                    {
                        return Ok(new { status = 200, obj = UserCreateRequestViewModel, message = "User create request sent successfully. Please check your email to confrm!" });
                    }
                }
                else
                {
                    return BadRequest(new { status = 404, message = ModelState });
                }
            }
            catch (Exception e)
            {

            }
            return BadRequest(new { status = 404, message = message });
        }
        [HttpGet]
        [Route("userCreateData")]
        public async Task<ActionResult> GetUserCreateData()
        {
            try
            {
                UserCreateDataViewModel userCreateDataViewModel = await userBLL.GetUserCreateDataAsync();
                if (userCreateDataViewModel != null)
                {
                    return Ok(new { status = 200, obj = userCreateDataViewModel, message = "User Create data retrive successfull." });
                }
            }
            catch (Exception e)
            {

            }
            return BadRequest(new { status = 404, message = message });
        }
        [HttpPost]
        [Route("getByToken")]
        public async Task<ActionResult> GetByToken(UserCreateRequestViewModel model)
        {
            try
            {
                UserCreateRequestViewModel userCreateDataViewModel = await userBLL.GetByTokenAsync(model);
                if (userCreateDataViewModel != null)
                {
                    return Ok(new { status = 200, obj = userCreateDataViewModel, message = "User Create request data retrive successfull." });
                }
            }
            catch (Exception e)
            {

            }
            return BadRequest(new { status = 404, message = message });
        }
        [HttpGet]
        [Route("tableData")]
        public ActionResult GetUserForTable()
        {
            try
            {
                List<UserViewModel> userViewModels = userBLL.GetUserForTable(userManager);
                if (userViewModels != null)
                {
                    return Ok(new { status = 200, obj = userViewModels, message = "User data retrive successfull." });
                }
            }
            catch (Exception e)
            {

            }
            return BadRequest(new { status = 404, message = message });
        }
    }
}