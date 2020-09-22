using System;
using System.Collections.Generic;
using System.Text;

namespace CommonDAL.ViewModels
{
    public class FixedExpenseViewModel
    {
        public long? Id { get; set; }
        public int? OrganizationId { get; set; }
        public int? ShopId { get; set; }
        public string FixedExpenseNo { get; set; }
        public DateTime? FixedExpenseDate { get; set; }
        public long? ServiceProviderId { get; set; }
        public int? ExpenseHeadId { get; set; }
        public long? VoucherId { get; set; }
        public string Note { get; set; }
        public decimal? Amount { get; set; }
        public string CapturedBy { get; set; }
        public DateTime? CapturedDate { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public byte? Status { get; set; }
    }
    public class FixedExpenseDetailsViewModel: FixedExpenseViewModel
    {
        public string FixedExpenseDateString { get; set; }
        public string ServiceProviderName { get; set; }
        public string ExpenseHeadName { get; set; }
        public string CreatedByName { get; set; }
        public string CreatedDateString { get; set; }
        public string UpdatedByName { get; set; }
        public string UpdatedDateString { get; set; }
    }
}
