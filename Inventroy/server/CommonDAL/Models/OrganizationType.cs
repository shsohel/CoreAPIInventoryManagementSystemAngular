using System;
using System.Collections.Generic;
using System.Text;

namespace CommonDAL.Models
{
    public class OrganizationType
    {
        public int Id { get; set; }
        public string TypeNo { get; set; }
        public string Name { get; set; }
        public long? CapturedBy { get; set; }
        public DateTime? CapturedDate { get; set; }
        public long? UpdatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public byte? Status { get; set; }
    }
}
