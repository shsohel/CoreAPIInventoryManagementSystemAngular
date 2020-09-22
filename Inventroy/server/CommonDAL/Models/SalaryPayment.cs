using System;
using System.Collections.Generic;
using System.Text;

namespace CommonDAL.Models
{
    public class SalaryPayment
    {
        public long Id { get; set; }
        public int? OrganizationId { get; set; }
        public int? ShopId { get; set; }
        public long? EmployeeId { get; set; }
        public string SalaryPaymentNo { get; set; }
        public int? ExpenseHeadId { get; set; }
        public DateTime? SalaryPaymentDate { get; set; }
        public string Note { get; set; }
        public long? VoucherId { get; set; }
        public decimal? PaidAmount { get; set; }
        public string CapturedBy { get; set; }
        public DateTime? CapturedDate { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public byte? Status { get; set; }
    }
}
