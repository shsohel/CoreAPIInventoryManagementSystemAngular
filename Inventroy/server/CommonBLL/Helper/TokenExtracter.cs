using CommonDAL.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace CommonBLL.Helper
{
    public static class TokenExtracter
    {
        public static async Task<ApplicationUser> ExtractTokenAsync(ClaimsPrincipal claims, UserManager<User> userManager)
        {
            try
            {
                string id = claims.Claims.First(c => c.Type == "id").Value;
                User user = await userManager.FindByIdAsync(id);
                if(user != null)
                {
                    ApplicationUser applicationUser = new ApplicationUser
                    {
                        Id = user.Id,
                        OrganizationId = (int)user.OrganizationId,
                        ShopId = (int)user.ShopId,
                        UserName = user.UserName
                    };
                    return applicationUser;
                }
            }
            catch (Exception e)
            {

            }
            return null;
        }
    }
}
