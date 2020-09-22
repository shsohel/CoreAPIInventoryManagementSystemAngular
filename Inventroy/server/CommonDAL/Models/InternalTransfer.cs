using System;
using System.Collections.Generic;
using System.Text;

namespace CommonDAL.Models
{
    public class InternalTransfer
    {
        public long Id { get; set; }
        public int OrganizationId { get; set; }
        public int ShopId { get; set; }
        public string InternalTransferNo { get; set; }
        public string SentBy { get; set; }
        public DateTime SentDate { get; set; }
        public string SentTo { get; set; }
        public decimal Amount { get; set; }
        public string Note { get; set; }
        public string RejectReason { get; set; }
        public string ApprovedBy { get; set; }
        public DateTime? ApproveDate { get; set; }
        public string CapturedBy { get; set; }
        public DateTime? CapturedDate { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? UpdateDate { get; set; }
        public string CanceledBy { get; set; }
        public DateTime? CanceledDate { get; set; }
        public byte Status { get; set; }
    }
}
