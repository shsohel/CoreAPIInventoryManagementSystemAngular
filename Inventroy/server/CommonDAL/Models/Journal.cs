using System;
using System.Collections.Generic;
using System.Text;

namespace CommonDAL.Models
{
    public class Journal
    {
        public long Id { get; set; }
        public string Code { get; set; }
        public int OrganizationId { get; set; }
        public int ShopId { get; set; }
        public DateTime Date { get; set; }
        public bool IsShopBalanceEffected { get; set; }
        public int TransactionType { get; set; }
        public int? TransactionTypeType { get; set; }
        public int? TransactionTypeTypeSub { get; set; }
        public long PartyId { get; set; }
        public int PartyType { get; set; }
        public long? PartyIdsecond { get; set; }
        public int? PartyTypeSecond { get; set; }
        public decimal Paid { get; set; }
        public decimal Receive { get; set; }
        public string Particular { get; set; }
        public string TransactionBy { get; set; }
        public string TransactionByCode { get; set; }
        public int? EventFrom { get; set; }
        public bool? IsAdjustment { get; set; }
        public string Reference { get; set; }
        public byte Status { get; set; }
        public string CapturedBy { get; set; }
        public DateTime CaptureDate { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
    }
}
