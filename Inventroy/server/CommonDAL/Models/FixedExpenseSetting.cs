using System;
using System.Collections.Generic;
using System.Text;

namespace CommonDAL.Models
{
    public class FixedExpenseSetting
    {
        public long Id { get; set; }
        public int? OrganizationId { get; set; }
        public int? ShopId { get; set; }
        public string FixedExpenseSettingNo { get; set; }
        public int? ExpenseHeadId { get; set; }
        public DateTime ValidFrom { get; set; }
        public DateTime ValidTo { get; set; }
        public decimal Amount { get; set; }
        public byte? PayableType { get; set; }
        public long? ServiceProviderId { get; set; }
        public string Note { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public byte? Status { get; set; }
    }
}