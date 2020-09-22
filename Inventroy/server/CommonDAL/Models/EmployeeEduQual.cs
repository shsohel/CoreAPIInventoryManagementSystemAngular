using System;
using System.Collections.Generic;
using System.Text;

namespace CommonDAL.Models
{
   public class EmployeeEduQual
    {
        public long Id { get; set; }
        public long EmployeeId { get; set; }
        public string RegistrationNo { get; set; }
        public string RollNo { get; set; }
        public byte? BoardorUniversity { get; set; }
        public byte? SubjectId { get; set; }
        public int ? ClassTypeId { get; set; }
        public DateTime PassingYear { get; set; }
        public byte? Result { get; set; }
        public string ResultCgpa { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public byte? Status { get; set; }
    }
}
