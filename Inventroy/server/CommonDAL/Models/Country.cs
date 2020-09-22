using System;
using System.Collections.Generic;
using System.Text;

namespace CommonDAL.Models
{
 public   class Country
    {
        public int Id { get; set; }
        public string CountryName { get; set; }
        public string CountryCode { get; set; }
        public byte? Status { get; set; }
    }
}
