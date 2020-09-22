using System;
using System.Collections.Generic;
using System.Text;

namespace CommonDAL.Models
{
    public class CheckInfo
    {
        public long Id { get; set; }
        public int OrganizationId { get; set; }
        public int ShopId { get; set; }
        public string CheckNo { get; set; }
        public string BankName { get; set; }
        public DateTime CheckDate { get; set; }
        public decimal Amount { get; set; }
        public byte Status { get; set; }
        public string CapturedBy { get; set; }
        public DateTime CaptureDate { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? UpdateDate { get; set; }
    }
}
