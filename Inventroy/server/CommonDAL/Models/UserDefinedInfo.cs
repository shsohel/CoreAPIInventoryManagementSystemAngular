using System;
using System.Collections.Generic;
using System.Text;

namespace CommonDAL.Models
{
    public class UserDefinedInfo
    {
        public int Id { get; set; }
        public int ReferenceType { get; set; }
        public int OrganizationId { get; set; }
        public int ShopId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool IsMendatory { get; set; }
        public byte Status { get; set; }
        public string CapturedBy { get; set; }
        public DateTime CaptureDate { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? UpdateDate { get; set; }
    }
}
