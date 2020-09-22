using System;
using System.Collections.Generic;
using System.Text;

namespace CommonDAL.Models
{
  public  class EmployeeAddress
    {
        public long Id { get; set; }
        public long? EmployeeId { get; set; }
        public string PresentVillageHouse { get; set; }
        public string PresentRoadBlockSector { get; set; }
        public int? PresentPostOffice { get; set; }
        public string PresentPostCode { get; set; }
        public int? PresentUpazila { get; set; }
        public int? PresentDistrict { get; set; }
        public string PermanentVillageHouse { get; set; }
        public string PermanentRoadBlockSector { get; set; }
        public int? PermanentPostOffice { get; set; }
        public string PermanentPostCode { get; set; }
        public int? PermanentUpazila { get; set; }
        public int? PermanentDistrict { get; set; }
        public string CapturedBy { get; set; }
        public DateTime? CapturedDate { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public byte? Status { get; set; }
    }
}
