using System;
using System.Collections.Generic;
using System.Text;

namespace CommonDAL.Models
{
    public class SalesOrder
    {
        public long Id { get; set; }
        public int OrganizationId { get; set; }
        public int ShopId { get; set; }
        public string SalesOrderCode { get; set; }
        public DateTime SystemDate { get; set; }
        public int SalesPersonId { get; set; }
        public long CustomerId { get; set; }
        public int CounterNumber { get; set; }
        public decimal TotalPrice { get; set; }
        public decimal TotalDiscount { get; set; }
        public decimal TotalVat { get; set; }
        public decimal TotalPayable { get; set; }
        public DateTime Date { get; set; }
        public bool IsLocked { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public byte Status { get; set; }
    }
}
