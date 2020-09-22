using System;
using System.Collections.Generic;
using System.Text;

namespace CommonDAL.ViewModels
{
  public  class VATViewModel
    {
        public long? Id { get; set; }
        public int OrganizationId { get; set; }
        public int ShopId { get; set; }
        public string Name { get; set; }
        public string VatNo { get; set; }
        public string Description { get; set; }
        public bool IsPercent { get; set; }
        public decimal Amount { get; set; }
        public DateTime FromDate { get; set; }
        public DateTime? ToDate { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public byte Status { get; set; }
    }
    public class VATDetailsViewModel : VATViewModel
    {
        public string FromDateString { get; set; }
        public string ToDateString { get; set; }
        public string CreatedByName { get; set; }
        public string ModifiedByName { get; set; }
        public string CreatedDateString { get; set; }
        public string ModifiedDateString { get; set; }
    }
}
