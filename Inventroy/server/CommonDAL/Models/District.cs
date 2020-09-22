using System;
using System.Collections.Generic;
using System.Text;

namespace CommonDAL.Models
{
    public class District
    {
        public int Id { get; set; }
        public int DivisionId { get; set; }
        public string DistrictName { get; set; }
    }
}
