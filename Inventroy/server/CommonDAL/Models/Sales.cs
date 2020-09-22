using System;
using System.Collections.Generic;
using System.Text;

namespace CommonDAL.Models
{
    public class Sales
    {
        public long Id { get; set; }
        public int OrganizationId { get; set; }
        public int ShopId { get; set; }
        public int? WareHouseId { get; set; }
        public string SalesCode { get; set; }
        public long SalesOrderId { get; set; }
        public DateTime SystemDate { get; set; }
        public int SalesPersonId { get; set; }
        public long CustomerId { get; set; }
        public int CounterNumber { get; set; }
        public DateTime Date { get; set; }
        public string Vehicle { get; set; }
        public string DriverName { get; set; }
        public string MobileDriver { get; set; }
        public decimal? AdditionalBill { get; set; }
        public decimal TransportCost { get; set; }
        public decimal LabourCost { get; set; }
        public decimal OthersCost { get; set; }
        public decimal TotalPrice { get; set; }
        public decimal TotalDiscountProductWise { get; set; }
        public decimal? DiscountExtra { get; set; }
        public decimal TotalVat { get; set; }
        public decimal TotalPayable { get; set; }
        public decimal TotalPriceInitial { get; set; }
        public decimal TotalDiscountProductWiseInitial { get; set; }
        public decimal? DiscountExtraInitial { get; set; }
        public decimal TotalVatInitial { get; set; }
        public decimal TotalPayableInitial { get; set; }
        public bool IsLocked { get; set; }
        public decimal? PreviousDue { get; set; }
        public string Note { get; set; }
        public bool? IsDispatched { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public byte Status { get; set; }
    }
}
