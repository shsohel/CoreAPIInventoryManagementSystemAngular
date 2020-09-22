using System;
using System.Collections.Generic;
using System.Text;

namespace CommonDAL.Models
{
    public class UserDefinedInfoMapping
    {
        public long Id { get; set; }
        public int OrganizationId { get; set; }
        public int ShopId { get; set; }
        public int ReferenceType { get; set; }
        public long ReferenceId { get; set; }
        public int UserDefinedInfoId { get; set; }
        public string Note { get; set; }
        public byte Status { get; set; }
        public string CapturedBy { get; set; }
        public DateTime CaptureDate { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? UpdateDate { get; set; }
    }
}
