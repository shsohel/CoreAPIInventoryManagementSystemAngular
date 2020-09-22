using System;
using System.Collections.Generic;
using System.Text;

namespace CommonDAL.Models
{
    public class DiscountUsageHistory
    {
        public long Id { get; set; }
        public long DiscountId { get; set; }
        public long OrderId { get; set; }
        public long SalesId { get; set; }
        public int FreeType { get; set; }
        public decimal DiscountedTkamount { get; set; }
        public decimal DiscountedProductAmount { get; set; }
        public int DiscountedProductUnit { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public byte Status { get; set; }
    }
}
