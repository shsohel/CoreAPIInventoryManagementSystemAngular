using System;
using System.Collections.Generic;
using System.Text;

namespace CommonDAL.Models
{
    public class CashPay
    {
        public long Id { get; set; }
        public int OrganizationId { get; set; }
        public int ShopId { get; set; }
        public long PurchasId { get; set; }
        public long PurchasReturnId { get; set; }
        public string Code { get; set; }
        public int SupplierId { get; set; }
        public int PaidByEmpId { get; set; }
        public decimal Amount { get; set; }
        public DateTime Date { get; set; }
        public bool IsLocked { get; set; }
        public string Note { get; set; }
        public long CheckInfoId { get; set; }
        public long? BankTransferId { get; set; }
        public bool? IsAdjustment { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public byte Status { get; set; }
    }
}
