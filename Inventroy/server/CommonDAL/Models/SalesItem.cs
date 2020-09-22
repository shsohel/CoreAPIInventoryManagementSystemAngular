using System;
using System.Collections.Generic;
using System.Text;

namespace CommonDAL.Models
{
    public class SalesItem
    {
        public long Id { get; set; }
        public int OrganizationId { get; set; }
        public int ShopId { get; set; }
        public long SalesId { get; set; }
        public int ProductId { get; set; }
        public int ProductItemId { get; set; }
        public decimal Qty { get; set; }
        public decimal QtyInitial { get; set; }
        public decimal QtyReturn { get; set; }
        public int PriceId { get; set; }
        public decimal SalesPrice { get; set; }
        public long DiscountId { get; set; }
        public decimal Discount { get; set; }
        public long TaxAmountId { get; set; }
        public decimal Tax { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public byte Status { get; set; }
    }
}
