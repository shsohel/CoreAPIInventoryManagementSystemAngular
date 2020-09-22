using System;
using System.Collections.Generic;
using System.Text;

namespace CommonDAL.Models
{
    public class WarehouseTransactionDetail
    {
        public long Id { get; set; }
        public int OrganizationId { get; set; }
        public int ShopId { get; set; }
        public long WarehouseTransactionId { get; set; }
        public int ReferenceType { get; set; }
        public int ReferenceParentId { get; set; }
        public long ReferenceId { get; set; }
        public int WarehouseId { get; set; }
        public int ProductId { get; set; }
        public int ProductItemId { get; set; }
        public decimal Inqty { get; set; }
        public decimal OutQty { get; set; }
        public byte Status { get; set; }
        public string CapturedBy { get; set; }
        public DateTime CaptureDate { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? UpdateDate { get; set; }
    }
}
