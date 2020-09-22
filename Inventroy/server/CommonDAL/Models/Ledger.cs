using System;
using System.Collections.Generic;
using System.Text;

namespace CommonDAL.Models
{
    public class Ledger
    {
        public long Id { get; set; }
        public string LedgerNo { get; set; }
        public int OrganizationId { get; set; }
        public int ShopId { get; set; }
        public int CustomerId { get; set; }
        public int ResponsibleEmpId { get; set; }
        public int Type { get; set; }
        public long TransactionById { get; set; }
        public string TransactionByCode { get; set; }
        public bool IsDebit { get; set; }
        public decimal Amount { get; set; }
        public string Particulars { get; set; }
        public DateTime Date { get; set; }
        public byte Status { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
    }
}
