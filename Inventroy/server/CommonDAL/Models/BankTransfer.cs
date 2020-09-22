﻿using System;
using System.Collections.Generic;
using System.Text;

namespace CommonDAL.Models
{
    public class BankTransfer
    {
        public long Id { get; set; }
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
}
