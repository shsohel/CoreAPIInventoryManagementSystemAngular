using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace CommonDAL.Models
{
    public class User: IdentityUser
    {
        public long EmployeeId { get; set; }
        public int UserType { get; set; }
        public int? OrganizationId { get; set; }
        public int? ShopId { get; set; }
        public string ProfilePicture { get; set; }
        public byte Ststus { get; set; }
    }
}
