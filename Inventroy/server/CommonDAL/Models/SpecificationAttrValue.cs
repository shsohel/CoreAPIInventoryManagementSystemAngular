using System;
using System.Collections.Generic;
using System.Text;

namespace CommonDAL.Models
{
    public class SpecificationAttrValue
    {
        public int Id { get; set; }
        public int SpecificationAttrId { get; set; }
        public string AttributeValueNo { get; set; }
        public string AttrValue { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public byte Status { get; set; }
    }
}
