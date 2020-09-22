using CommonBLL.Helper;
using CommonDAL.Models;
using CommonDAL.Repository;
using CommonDAL.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace CommonBLL
{
    public class AppUserManagerBLL
    {
        private readonly UserManager<User> userManager;
        private readonly SignInManager<User> signInManager;
        private readonly IMSSetting iMSSetting;
        private readonly IRepository<Shop> shopRepository;

        public AppUserManagerBLL(UserManager<User> userManager, SignInManager<User> signInManager, IMSSetting iMSSetting, IRepository<Shop> shopRepository)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.iMSSetting = iMSSetting;
            this.shopRepository = shopRepository;
        }
        public async Task<IdentityResult> SignUpAsync(UserViewModel model)
        {
            try
            {
                User user = new User
                {
                    UserName = model.UserName,
                    Email = model.Email,
                    PhoneNumber = model.MobileNo,
                    EmployeeId = model.EmployeeId,
                    UserType = model.UserType
                };
                IdentityResult result = await userManager.CreateAsync(user, model.Password);
                return result;
            }
            catch (Exception e)
            {

            }
            return null;
        }
        public async Task<string> LoginAsync(LoginViewModel model)
        {
            try
            {
                User user = await userManager.FindByNameAsync(model.UserName);
                if (user != null && await userManager.CheckPasswordAsync(user, model.Password))
                {
                    var tokenDescriptor = new SecurityTokenDescriptor
                    {
                        Subject = new ClaimsIdentity(new Claim[]
                    {
                        new Claim("id", user.Id.ToString())
                    }),
                        Expires = DateTime.UtcNow.AddDays(1),
                        SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(Encoding.UTF8.GetBytes(iMSSetting.IMSSequrity)), SecurityAlgorithms.HmacSha256Signature)
                    };
                    var tokenHandler = new JwtSecurityTokenHandler();
                    var securityToken = tokenHandler.CreateToken(tokenDescriptor);
                    var token = tokenHandler.WriteToken(securityToken);
                    return token;
                }
            }
            catch (Exception e)
            {

            }
            return null;
        }
        public async Task<ApplicationUser> GetUserDetailsAsync(ClaimsPrincipal claims, UserManager<User> userManager)
        {
            try
            {
                User user = await userManager.FindByIdAsync(claims.Claims.First(x => x.Type == "id").Value);
                if(user != null)
                {
                    ApplicationUser applicationUser = new ApplicationUser
                    {
                        EmployeeId = user.EmployeeId,
                        Id = user.Id,
                        OrganizationId = (int)user.OrganizationId,
                        ProfilePicture = user.ProfilePicture,
                        ShopId = (int)user.ShopId,
                        UserName = user.UserName,
                        UserType = user.UserType
                    };
                    return applicationUser;
                }
            }
            catch (Exception e)
            {

            }
            return null;
        }
        public async Task<bool> ForgetPasswordAsync(ForgetPasswordViewModel model)
        {
            try
            {
                User user = await userManager.FindByEmailAsync(model.Email);
                if (user != null)
                {
                    Shop shop = await shopRepository.GetAsync(user.ShopId);
                    var token = await userManager.GeneratePasswordResetTokenAsync(user);

                    model.Link = model.Link + "email=" + model.Email  + "&token=" + token;
                    string htmlBody = Messenger.GetPasswordResetHTMLMessage(model.Link, user.UserName);
                    MessengeDetails messengeDetails = new MessengeDetails
                    {
                        MailForm = shop.EmailForSystemGeneratedMail,
                        MailFormPassword = shop.PasswordForSystemGeneratedMail,
                        MailTo = model.Email,
                        MailToUserName = user.UserName,
                        MessageBodyInHTML = htmlBody,
                        MessageSubject = "Password Reset",
                        ShopName = shop.Name
                    };
                    bool messageSent = Messenger.SendConfirmMailWithHTMLFormat(messengeDetails);
                    return messageSent;
                }
            }
            catch (Exception e)
            {

            }
            return false;
        }
        public async Task<IdentityResult> ResetPasswordAsync(PasswordResetViewModel model)
        {
            try
            {
                User user = await userManager.FindByEmailAsync(model.Email);
                if(user != null)
                {
                    string token = model.Token.Replace(' ', '+');
                    IdentityResult result = await userManager.ResetPasswordAsync(user, token, model.Password);
                    return result;
                }
            }
            catch (Exception e)
            {

            }
            return null;
        }
    }
}
