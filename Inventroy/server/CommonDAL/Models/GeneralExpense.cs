using System;
using System.Collections.Generic;
using System.Text;

namespace CommonDAL.Models
{
    public class GeneralExpense
    {
        public long Id { get; set; }
        public int? OrganizationId { get; set; }
        public int? ShopId { get; set; }
        public string GeneralExpenseNo { get; set; }
        public DateTime GeneralExpenseDate { get; set; }
        public int ExpenseHeadId { get; set; }
        public long? VoucherId { get; set; }
        public string Note { get; set; }
        public decimal Amount { get; set; }
        public string CapturedBy { get; set; }
        public DateTime CapturedDate { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public byte? Status { get; set; }
    }
}
