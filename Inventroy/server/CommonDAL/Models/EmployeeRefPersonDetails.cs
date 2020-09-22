using System;
using System.Collections.Generic;
using System.Text;

namespace CommonDAL.Models
{
 public class EmployeeRefPersonDetails
    {
        public long Id { get; set; }
        public long EmployeeId { get; set; }
        public byte ReletionShipId { get; set; }
        public string RefPersonName { get; set; }
        public byte ProfessionId { get; set; }
        public string MobileNo { get; set; }
        public string Email { get; set; }
        public int? CountryId { get; set; }
        public int? DistictId { get; set; }
        public int? PoliceStationId { get; set; }
        public int? PostOffice { get; set; }
        public string PostCode { get; set; }
        public string RoadBlockSector { get; set; }
        public string HouseVillage { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public byte? Status { get; set; }
    }
}
