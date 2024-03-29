﻿using System;
using System.Collections.Generic;
using System.Text;

namespace CommonDAL.ViewModels
{
    public class BankTransferViewModel
    {
        public long? Id { get; set; }
        public int OrganizationId { get; set; }
        public int ShopId { get; set; }
        public string BankTransferNo { get; set; }
        public int BankAccountId { get; set; }
        public byte? TransferPurpose { get; set; }
        public int? ResponsiblePersonId { get; set; }
        public decimal Amount { get; set; }
        public string Note { get; set; }
        public decimal? Deposit { get; set; }
        public decimal? Withdraw { get; set; }
        public string RequestedBy { get; set; }
        public DateTime? RequestedDate { get; set; }
        public string CanceledBy { get; set; }
        public DateTime? CanceledDate { get; set; }
        public string RejectedBy { get; set; }
        public DateTime? RejectedDate { get; set; }
        public string RejectReason { get; set; }
        public string ApprovedBy { get; set; }
        public DateTime? ApprovedDate { get; set; }
        public string CapturedBy { get; set; }
        public DateTime CapturedDate { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public byte? Status { get; set; }
    }
    public class BankTransferDetailsModel: BankTransferViewModel
    {
        public string ResponsiblePersonName { get; set; }
        public string RejectedByName { get; set; }
        public string RejectedDateString { get; set; }
        public string RequestByName { get; set; }
        public string RequestDateString { get; set; }
        public string ApprovedByName { get; set; }
        public string ApproveDateString { get; set; }
        public string CapturedByName { get; set; }
        public string CaptureDateString { get; set; }
        public string CanceledByName { get; set; }
        public string CanceledDateString { get; set; }
        public string UpdatedByName { get; set; }
        public string UpdatedDateString { get; set; }
    }
}
