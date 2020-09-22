using System;
using System.Collections.Generic;
using System.Text;

namespace CommonDAL.ViewModels
{
 public  class SpecificationAttributeViewModel
    {
        public int? Id { get; set; }
        public int OrganizationId { get; set; }
        public int ShopId { get; set; }
        public string Name { get; set; }
        public string AttributeNo { get; set; }
        public int Sequence { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public byte Status { get; set; }
    }
    public class SpecificationAttributeDetailsViewModel : SpecificationAttributeViewModel
    {
        public string CreatedByName { get; set; }
        public string ModifiedByName { get; set; }
        public string CreatedDateString { get; set; }
        public string ModifiedDateString { get; set; }
    }
    public class SpecificationAttrValueViewModel
    {
        public int? Id { get; set; }
        public int SpecificationAttrId { get; set; }
        public string AttributeValueNo { get; set; }
        public string AttrValue { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public byte Status { get; set; }
    }
    public class ExtraSpAttrValueViewModel
    {
        public ExtraSpAttrValueViewModel()
        {
            specificationAttrValueViewModels = new List<SpecificationAttrValueViewModel>();
        }
        public List<SpecificationAttrValueViewModel> specificationAttrValueViewModels { get; set; }
    }
    public class FullAttributeDetailsViewModel
    {
        public FullAttributeDetailsViewModel()
        {
            specificationAttribute = new SpecificationAttributeDetailsViewModel();
            specificationAttrValues = new List<SpecificationAttrValueViewModel>();
        }
        public SpecificationAttributeDetailsViewModel specificationAttribute { get; set; }

        public List<SpecificationAttrValueViewModel> specificationAttrValues { get; set; }
    }

}
