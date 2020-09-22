using System;
using System.Collections.Generic;
using System.Text;

namespace CommonDAL.ViewModels
{
    public class PayIncentiveViewModel
    {
        public long? Id { get; set; }
        public int? OrganizationId { get; set; }
        public int? ShopId { get; set; }
        public string PayIncentiveNo { get; set; }
        public int? IncentiveType { get; set; }
        public int? PaymentType { get; set; }
        public long PaidToId { get; set; }
        public DateTime? PaymentDate { get; set; }
        public decimal Amount { get; set; }
        public long ResponsibleEmpId { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public byte? Status { get; set; }
    }
    public class PayIncentiveDetailsViewModel : PayIncentiveViewModel
    {
        public string IncentiveTypeName { get; set; }
        public string PaymentTypeName { get; set; }
        public string PaidToName { get; set; }
        public string PaymentDateString { get; set; }
        public string ResponsibleEmpName { get; set; }
        public string CreatedByName { get; set; }
        public string CreatedDateString { get; set; }
        public string UpdatedByName { get; set; }
        public string UpdatedDateString { get; set; }
    }
}
