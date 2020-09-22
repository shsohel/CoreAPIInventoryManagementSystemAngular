using System;
using System.Collections.Generic;
using System.Text;

namespace CommonDAL.ViewModels
{
    public class InternalTransferViewModel
    {
        public long? Id { get; set; }
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
        public byte? Status { get; set; }
    }
    public class InternalTransferDetailsModel : InternalTransferViewModel
    {
        public string SentByName { get; set; }
        public string SentToName { get; set; }
        public string SentDateString { get; set; }
        public string ApproveByName { get; set; }
        public string CapturedByName { get; set; }
        public string CancelByName { get; set; }
        public string UpdateByName { get; set; }
        public string ApproveDateString{ get; set; }
        public string CapturedDateString { get; set; }
        public string CancelDateString { get; set; }
        public string UpdateDateString { get; set; }

    }
}
