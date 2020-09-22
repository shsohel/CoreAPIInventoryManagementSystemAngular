using System;
using System.Collections.Generic;
using System.Text;

namespace CommonDAL.ViewModels
{
   public class ProductionViewModel
    {
        public long? Id { get; set; }
        public int OrganizationId { get; set; }
        public int ShopId { get; set; }
        public string ProductionNo { get; set; }
        public string BatchCode { get; set; }
        public string Batch { get; set; }
        public string Name { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime ExpiredDate { get; set; }
        public string Note { get; set; }
        public decimal RawProductCostTotal { get; set; }
        public decimal OtherCostTotal { get; set; }
        public byte Status { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
    }
    public class ProductionDetailsViewModel: ProductionViewModel
    {
        public string CreatedByName { get; set; }
        public string ModifiedByName { get; set; }
        public string CreatedDateString { get; set; }
        public string ModifiedDateString { get; set; }
        public string StartDateString { get; set; }
        public string ExpiredDateString { get; set; }
    }
}
