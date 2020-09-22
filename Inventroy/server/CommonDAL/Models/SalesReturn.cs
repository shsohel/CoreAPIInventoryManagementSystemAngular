using System;
using System.Collections.Generic;
using System.Text;

namespace CommonDAL.Models
{
    public class SalesReturn
    {
        public long Id { get; set; }
        public long SalesId { get; set; }
        public string SalesReturnCode { get; set; }
        public int OrganizationId { get; set; }
        public int ShopId { get; set; }
        public long SalesOrderId { get; set; }
        public DateTime SystemDate { get; set; }
        public int SalesPersonId { get; set; }
        public long CustomerId { get; set; }
        public int CounterNumber { get; set; }
        public DateTime Date { get; set; }
        public decimal TotalPrice { get; set; }
        public decimal DiscountProductwise { get; set; }
        public decimal TotalVat { get; set; }
        public decimal TotalPayable { get; set; }
        public decimal DiscountExtraDeduction { get; set; }
        public long CashCollectionId { get; set; }
        public bool IsLocked { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public byte Status { get; set; }
    }
}
