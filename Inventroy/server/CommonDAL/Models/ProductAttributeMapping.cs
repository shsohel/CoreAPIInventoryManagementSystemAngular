using System;
using System.Collections.Generic;
using System.Text;

namespace CommonDAL.Models
{
    public class ProductAttributeMapping
    {
        public long Id { get; set; }
        public int OrganizationId { get; set; }
        public int ShopId { get; set; }
        public int ProductItemId { get; set; }
        public int SpecificationAttrId { get; set; }
        public int SpecificationAttrValueId { get; set; }
        public int? SequenceNo { get; set; }
        public decimal PriceAdjustment { get; set; }
        public decimal WeightAdjustment { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public byte Status { get; set; }
    }
}
