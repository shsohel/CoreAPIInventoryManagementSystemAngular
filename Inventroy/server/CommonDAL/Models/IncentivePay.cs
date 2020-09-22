using System;
using System.Collections.Generic;
using System.Text;

namespace CommonDAL.Models
{
    public class IncentivePay
    {
        public long Id { get; set; }
        public int OrganizationId { get; set; }
        public int ShopId { get; set; }
        public int Type { get; set; }
        public DateTime DateForPaying { get; set; }
        public DateTime Date { get; set; }
        public long CustomerId { get; set; }
        public decimal Amount { get; set; }
        public string Note { get; set; }
        public int Responsible { get; set; }
        public byte Status { get; set; }
        public string CapturedBy { get; set; }
        public DateTime CaptureDate { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? UpdateDate { get; set; }
    }
}
