using System;
using System.Collections.Generic;
using System.Text;

namespace CommonDAL.Models
{
  public  class Subject
    {
        public long Id { get; set; }
        public string SubjectName { get; set; }
        public long? CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public long? UpdatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public byte? Status { get; set; }
    }
}
