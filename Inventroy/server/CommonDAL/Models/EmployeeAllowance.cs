using System;
using System.Collections.Generic;
using System.Text;

namespace CommonDAL.Models
{
   public class EmployeeAllowance
    {
        public int Id { get; set; }
        public string AllowanceNo { get; set; }
        public string AllowanceName { get; set; }
        public string PayableTypeId { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public byte? Status { get; set; }
    }
}
