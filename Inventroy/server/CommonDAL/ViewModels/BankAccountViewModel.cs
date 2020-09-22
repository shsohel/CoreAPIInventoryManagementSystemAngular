using System;
using System.Collections.Generic;
using System.Text;

namespace CommonDAL.ViewModels
{
    public class BankAccountViewModel
    {
        public long? Id { get; set; }
        public int? OrganizationId { get; set; }
        public int? ShopId { get; set; }
        public string BankAccountNo { get; set; }
        public string BankName { get; set; }
        public string BranchName { get; set; }
        public string AccountName { get; set; }
        public string AccountNo { get; set; }
        public byte? AccountType { get; set; }
        public byte? TransectionType { get; set; }
        public string CapturedBy { get; set; }
        public DateTime CapturedDate { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public byte? Status { get; set; }
    }
    public class BankAccountDetailsViewModel : BankAccountViewModel
    {
        public string AccountTypeName { get; set; }
        public string TransectionTypeName { get; set; }
        public string CapturedByName { get; set; }
        public string CaptureDateString { get; set; }
        public string UpdatedByName { get; set; }
        public string UpdatedDateString { get; set; }
    }
}
