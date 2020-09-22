using System;
using System.Collections.Generic;
using System.Text;

namespace CommonDAL.Models
{
    public class Purchase
    {
        public long Id { get; set; }
        public int OrganizationId { get; set; }
        public int ShopId { get; set; }
        public long PurchaseOrderId { get; set; }
        public string PurchaseNo { get; set; }
        public int? WareHouseId { get; set; }
        public long? SupplierId { get; set; }
        public long? PaidByEmpId { get; set; }
        public long ResponsibleEmpId { get; set; }
        public DateTime Date { get; set; }
        public string Note { get; set; }
        public decimal PaidAmount { get; set; }
        public decimal Amount { get; set; }
        public decimal TransportCost { get; set; }
        public decimal LabourCost { get; set; }
        public decimal Vat { get; set; }
        public decimal OthersCost { get; set; }
        public bool IsLocked { get; set; }
        public bool? IsWarehoused { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public byte Status { get; set; }
    }
}