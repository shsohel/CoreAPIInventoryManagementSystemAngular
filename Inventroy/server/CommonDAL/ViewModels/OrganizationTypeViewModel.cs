using System;
using System.Collections.Generic;
using System.Text;

namespace CommonDAL.ViewModels
{
   public class OrganizationTypeViewModel
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
    public class OrganizationTypeDetailsViewModel:OrganizationTypeViewModel
    {
        public string CreatedByName { get; set; }
        public string ModifiedByName { get; set; }
        public string CreatedDateString { get; set; }
        public string ModifiedDateString { get; set; }
    }

}
