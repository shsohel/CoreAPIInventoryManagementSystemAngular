using System;
using System.Collections.Generic;
using System.Text;

namespace CommonDAL.ViewModels
{
    public class EmployeeBasicInfoViewModel
    {
        public long? Id { get; set; }
        public long? EmployeeId { get; set; }
        public string FathersName { get; set; }
        public byte? FathersProfession { get; set; }
        public string MothersName { get; set; }
        public byte? MothersProfession { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public byte? ReligionId { get; set; }
        public int? NationalityId { get; set; }
        public byte? CitizenShipStatusId { get; set; }
        public int? CountryOfBirthId { get; set; }
        public int? DistictOfBirthId { get; set; }
        public byte? GenderId { get; set; }
        public string BirthRegNo { get; set; }
        public string NationalIdno { get; set; }
        public string PassportNo { get; set; }
        public int? Hight { get; set; }
        public byte? BloodGroupId { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public byte? Status { get; set; }
    }
}
