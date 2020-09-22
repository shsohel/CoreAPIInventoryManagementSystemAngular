using System;
using System.Collections.Generic;
using System.Text;

namespace CommonDAL.Models
{
    public class CashCollection
    {
        public long Id { get; set; }
        public int OrganizationId { get; set; }
        public int ShopId { get; set; }
        public long SalesId { get; set; }
        public long SalesReturnId { get; set; }
        public string Code { get; set; }
        public long CustomerId { get; set; }
        public int CollectionPersonId { get; set; }
        public decimal Amount { get; set; }
        public DateTime Date { get; set; }
        public bool IsLocked { get; set; }
        public string Note { get; set; }
        public long CheckInfoId { get; set; }
        public long? BankTransferId { get; set; }
        public string Instrument { get; set; }
        public bool? IsAdjustment { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public byte Status { get; set; }
    }
}
