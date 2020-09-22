using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace CommonDAL.Models
{
    public class ApplicationUser
    {
        public string Id { get; set; }
        public string UserName { get; set; }
        public int ShopId { get; set; }
        public int OrganizationId { get; set; }
        public long EmployeeId { get; set; }
        public int UserType { get; set; }
        public string ProfilePicture { get; set; }
    }
}
