using System;
using System.Collections.Generic;
using System.Text;

namespace CommonDAL.Models
{
    public class DistrictPostOffice
    {
        public int Id { get; set; }
        public int? DistrictId { get; set; }
        public string UpazilaName { get; set; }
        public string PostOfficeName { get; set; }
        public string PostCode { get; set; }
        public byte? Status { get; set; }
    }
}
