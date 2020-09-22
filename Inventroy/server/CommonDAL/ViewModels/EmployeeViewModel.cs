using System;
using System.Collections.Generic;
using System.Text;

namespace CommonDAL.ViewModels
{
    public class EmployeeViewModel
    {
        public long? Id { get; set; }
        public string EmployeeNo { get; set; }
        public int OrganizationId { get; set; }
        public int ShopId { get; set; }
        public bool? IsOwner { get; set; }
        public string Name { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int? Designation { get; set; }
        public string Mobile { get; set; }
        public string ResidanceMobileNo { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public DateTime? JoiningDate { get; set; }
        public DateTime? TerminationDate { get; set; }
        public byte? SalaryTypeId { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public byte Status { get; set; }
    }
}
