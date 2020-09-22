using System;
using System.Collections.Generic;
using System.Text;

namespace CommonDAL.Models
{
    public class SpecificationAttribute
    {
        public int Id { get; set; }
        public int OrganizationId { get; set; }
        public string AttributeNo { get; set; }
        public int ShopId { get; set; }
        public string Name { get; set; }
        public int Sequence { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public byte Status { get; set; }
    }
}
