using System;
using System.Collections.Generic;
using System.Text;

namespace CommonDAL.Models
{
   public class Organization
    {
        public int Id { get; set; }
        public string OrganizationNo { get; set; }
        public byte? OrganizationTypeId { get; set; }
        public string Name { get; set; }
        public string FounderName { get; set; }
        public DateTime? EstablishedOn { get; set; }
        public string TelephoneNo { get; set; }
        public string MobileNo { get; set; }
        public string Email { get; set; }
        public string WebAddress { get; set; }
        public string RegistrationNo { get; set; }
        public DateTime? RegisteredDate { get; set; }
        public string AddressVillageHouse { get; set; }
        public string AddressRoadBlockSector { get; set; }
        public int? AddressPostOffice { get; set; }
        public string AddressPostCode { get; set; }
        public int? AddressUpazila { get; set; }
        public int? AddressDistrict { get; set; }
        public int? AddressCountry { get; set; }
        public string LogoImage { get; set; }
        public string NameCardImage { get; set; }
        public string CapturedBy { get; set; }
        public DateTime? CapturedDate { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public byte? Status { get; set; }
    }
}
