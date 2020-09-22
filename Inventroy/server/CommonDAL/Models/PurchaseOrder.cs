using System;
using System.Collections.Generic;
using System.Text;

namespace CommonDAL.Models
{
    public class PurchaseOrder
    {
        public long Id { get; set; }
        public int OrganizationId { get; set; }
        public int ShopId { get; set; }
        public DateTime SystemDate { get; set; }
        public int? SupplierId { get; set; }
        public int? ResponsibleEmpId { get; set; }
        public DateTime Date { get; set; }
        public string PurchaseOrderCode { get; set; }
        public decimal Amount { get; set; }
        public bool IsProductReceived { get; set; }
        public bool IsLocked { get; set; }
        public string Note { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public byte Status { get; set; }
    }
}
