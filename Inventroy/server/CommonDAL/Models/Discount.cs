using System;
using System.Collections.Generic;
using System.Text;

namespace CommonDAL.Models
{
    public class Discount
    {
        public long Id { get; set; }
        public int OrganizationId { get; set; }
        public int ShopId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int DiscountType { get; set; }
        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }
        public decimal DiscountTkamountLimit { get; set; }
        public decimal DiscountProuductLimit { get; set; }
        public int ProductUnitType { get; set; }
        public bool IsRunningOrPostPont { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public byte Status { get; set; }
    }
}
