using System;
using System.Collections.Generic;
using System.Text;

namespace CommonDAL.Models
{
    public class IncentiveSettings
    {
        public int Id { get; set; }
        public int OrganizationId { get; set; }
        public int ShopId { get; set; }
        public int Type { get; set; }
        public string SlabName { get; set; }
        public decimal SoldAmountMin { get; set; }
        public decimal SoldAmountMax { get; set; }
        public int UnitIdsold { get; set; }
        public decimal IncentiveAmount { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int CustomerType { get; set; }
        public byte Status { get; set; }
        public string CapturedBy { get; set; }
        public DateTime CaptureDate { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? UpdateDate { get; set; }
    }
}
