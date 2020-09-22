using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CommonBLL;
using CommonDAL.Models;
using CommonDAL.Repository;
using CommonDAL.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using SignInResult = Microsoft.AspNetCore.Identity.SignInResult;

namespace IMSERP.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppUserController : ControllerBase
    {
        private string message = "Sorry! Something going wrong. Please try again.";
        private readonly IRepository<User> repository;
        private readonly AppUserManagerBLL appUserManagerBLL;
        private readonly UserManager<User> userManager;

        public AppUserController(UserManager<User> userManager, SignInManager<User> signInManager, IOptions<IMSSetting> iMSSetting, IRepository<Shop> shopRepository)
        {
            this.appUserManagerBLL = new AppUserManagerBLL(userManager, signInManager, iMSSetting.Value, shopRepository);
            this.userManager = userManager;
        }
        [HttpPost]
        [Route("signUp")]
        public async Task<ActionResult> SignUp(UserViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    IdentityResult result = await appUserManagerBLL.SignUpAsync(model);
                    if (result != null)
                    {
                        if (result.Succeeded)
                        {
                            return Ok(new { status = 200, message = "Signup successfull now you can login." });
                        }
                        if (result.Errors.First().Code == "InvalidUserName")
                        {
                            message = result.Errors.First().Description.ToString() + "Not even any space.";
                        }
                        else
                        {
                            message = result.Errors.First().Description.ToString();
                        }
                    }
                }
            }
            catch (Exception e)
            {

            }
            return BadRequest(new { status = 404, message = message });
        }
        [HttpPost]
        [Route("login")]
        public async Task<ActionResult> Login(LoginViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    string token = await appUserManagerBLL.LoginAsync(model);
                    if (token != null)
                    {
                        return Ok(new { status = 200, iMSToken= token, message = "Login Succesfull." });
                    }
                    message = "Username of password is not correct";
                }
            }
            catch (Exception e)
            {

            }
            return BadRequest(new { status = 404, message = message });
        }
        [HttpGet]
        [Route("getDetails")]
        public async Task<ActionResult> GetDetails()
        {
            try
            {
                if (User.Identity != null)
                {
                    ApplicationUser user = await appUserManagerBLL.GetUserDetailsAsync(User, userManager);
                    if (user != null)
                    {
                        return Ok(new { status = 200, obj = user, message = "Data retrive succesfull." });
                    }
                    message = "Your are not logged in.";
                }
            }
            catch (Exception e)
            {

            }
            return BadRequest(new { status = 404, message = message });
        }
        [HttpPost]
        [Route("forgetPassword")]
        public async Task<ActionResult> ForgetPassword(ForgetPasswordViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    bool result = await appUserManagerBLL.ForgetPasswordAsync(model);
                    if (result != false)
                    {
                        return Ok(new { status = 200, message = "Password reset link sent successful. Check your email." });
                    }
                    message = "Your email is not correct or you are not registered.";
                }
            }
            catch (Exception e)
            {

            }
            return BadRequest(new { status = 404, message = message });
        }
        [HttpPost]
        [Route("resetPassword")]
        public async Task<ActionResult> ResetPassword(PasswordResetViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    IdentityResult result = await appUserManagerBLL.ResetPasswordAsync(model);
                    if (result.Succeeded)
                    {
                        return Ok(new { status = 200, message = "Password reset successful. Now you can login." });
                    }
                    message = "Reset password fialed. Try again...";
                }
            }
            catch (Exception e)
            {

            }
            return BadRequest(new { status = 404, message = message });
        }
    }
}