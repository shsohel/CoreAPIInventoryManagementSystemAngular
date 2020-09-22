using System;
using System.Collections.Generic;
using System.Text;

namespace CommonDAL.ViewModels
{
    public class UserCreateRequestViewModel
    {
        public int? RequestId { get; set; }
        public int? OrganizationId { get; set; }
        public int? ShopId { get; set; }
        public string ShopName { get; set; }
        public string VarificationCode { get; set; }
        public long? EmployeeId { get; set; }
        public int? UserType { get; set; }
        public string UserTypeName { get; set; }
        public string RequestBy { get; set; }
        public string UserName { get; set; }
        public DateTime? RequestDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public string UpdatedBy { get; set; }
        public byte? Status { get; set; }
        public string Url { get; set; }
        public string MobileNo { get; set; }
        public string Email { get; set; }
    }
}
