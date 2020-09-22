using System;
using System.Collections.Generic;
using System.Text;

namespace CommonDAL.ViewModels
{
    public class ExternalPersonViewModel
    {
        public long? Id { get; set; }
        public int? OrganizationId { get; set; }
        public int? ShopId { get; set; }
        public string ExternalPersonNo { get; set; }
        public string Name { get; set; }
        public string FathersName { get; set; }
        public string MobileNo { get; set; }
        public string Email { get; set; }
        public byte? RelationshipId { get; set; }
        public string Address { get; set; }
        public string CapturedBy { get; set; }
        public DateTime? CapturedDate { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public byte? Status { get; set; }
    }

    public class ExternalPersonDetailsViewModel : ExternalPersonViewModel
    {
        public string RelationshipName { get; set; }
        public string CapturedByName { get; set; }
        public string CapturedDateString { get; set; }
        public string UpdatedByName { get; set; }
        public string UpdatedDateString { get; set; }
    }

}
