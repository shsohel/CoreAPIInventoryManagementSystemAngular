using System;
using System.Collections.Generic;
using System.Text;

namespace CommonDAL.Models
{
    public class DiscountDesOnPurchasAmount
    {
        public long Id { get; set; }
        public long DiscountId { get; set; }
        public decimal PurchasedAmountToBe { get; set; }
        public bool IsPercent { get; set; }
        public decimal FreeAmount { get; set; }
        public decimal TotalFreedAmount { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public byte Status { get; set; }
    }
}
