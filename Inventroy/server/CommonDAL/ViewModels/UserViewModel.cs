using System;
using System.Collections.Generic;
using System.Text;

namespace CommonDAL.ViewModels
{
    public class UserViewModel
    {
        public long EmployeeId { get; set; }
        public string Email { get; set; }
        public string MobileNo { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
        public string UserName { get; set; }
        public int UserType { get; set; }
        public string UserTypeName { get; set; }
        public byte Status { get; set; }
    }
}
