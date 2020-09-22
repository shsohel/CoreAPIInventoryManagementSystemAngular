using System;
using System.Collections.Generic;
using System.Text;

namespace CommonDAL.Models
{
    public class Profession
    {
        public int Id { get; set; }
        public string ProfessionName { get; set; }
        public byte? Status { get; set; }
    }
}
