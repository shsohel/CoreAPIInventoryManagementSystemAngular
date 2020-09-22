using System;
using System.Collections.Generic;
using System.Text;

namespace CommonDAL.Models
{
    public class PayIncentive
    {
        public long Id { get; set; }
        public int OrganizationId { get; set; }
        public int ShopId { get; set; }
        public string PayIncentiveNo { get; set; }
        public int IncentiveType { get; set; }
        public int? PaymentType { get; set; }
        public long PaidToId { get; set; }
        public DateTime PaymentDate { get; set; }
        public decimal Amount { get; set; }
        public long ResponsibleEmpId { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public byte Status { get; set; }
    }
}
