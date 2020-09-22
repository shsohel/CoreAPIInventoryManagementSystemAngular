using System;
using System.Collections.Generic;
using System.Text;

namespace CommonDAL.Models
{
  public  class Nationality
    {
        public int Id { get; set; }
        public string Alpha2Code { get; set; }
        public string Alpha3Code { get; set; }
        public string CountryName { get; set; }
        public string NationalityName { get; set; }
    }
}
