using System;
using System.Collections.Generic;
using System.Text;

namespace CommonDAL.Models
{
    public class StockDeductionItem
    {
        public int Id { get; set; }
        public int OrganizationId { get; set; }
        public int ShopId { get; set; }
        public long StockDeductionId { get; set; }
        public int ProductId { get; set; }
        public int ProductItemId { get; set; }
        public decimal Qty { get; set; }
        public int UnitId { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public byte Status { get; set; }
    }
}
