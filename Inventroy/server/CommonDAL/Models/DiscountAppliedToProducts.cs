using System;
using System.Collections.Generic;
using System.Text;

namespace CommonDAL.Models
{
    public class DiscountAppliedToProducts
    {
        public long Id { get; set; }
        public long DiscountId { get; set; }
        public int ProductId { get; set; }
        public int PriceTypeId { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public byte Status { get; set; }
    }
}
