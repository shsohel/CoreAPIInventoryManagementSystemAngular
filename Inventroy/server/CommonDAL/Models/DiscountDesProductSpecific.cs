using System;
using System.Collections.Generic;
using System.Text;

namespace CommonDAL.Models
{
    public class DiscountDesProductSpecific
    {
        public long Id { get; set; }
        public long DiscountId { get; set; }
        public decimal PurchasAmountToBe { get; set; }
        public int PurchasAmountToBeType { get; set; }
        public int FreeType { get; set; }
        public decimal DiscountTkamount { get; set; }
        public decimal DiscountProductAmount { get; set; }
        public int DiscountProductUnit { get; set; }
        public int FreedProductItemId { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public byte Status { get; set; }
    }
}
