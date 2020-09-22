using System;
using System.Collections.Generic;
using System.Text;

namespace CommonDAL.Models
{
  public  class ClassType
    {
        public int Id { get; set; }
        public string ClassTypeName { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public byte? Status { get; set; }
    }
}
