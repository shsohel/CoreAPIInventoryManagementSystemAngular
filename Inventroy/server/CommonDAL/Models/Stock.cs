using System;
using System.Collections.Generic;
using System.Text;

namespace CommonDAL.Models
{
    public class Stock
    {
        public long Id { get; set; }
        public int OrganizationId { get; set; }
        public int ShopId { get; set; }
        public int ProductItemId { get; set; }
        public int ChangeByType { get; set; }
        public string ChangedById { get; set; }
        public string ChangedByCode { get; set; }
        public decimal Qty { get; set; }
        public decimal ChangedQty { get; set; }
        public bool IsIncreased { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime ModifiedDate { get; set; }
        public byte Status { get; set; }
    }
}
