using System;
using System.Collections.Generic;
using System.Text;

namespace CommonDAL.Models
{
    public class EmployeeAttendance
    {
        public long Id { get; set; }
        public long? EmployeeId { get; set; }
        public byte? SequenceId { get; set; }
        public int? ShiftSectionId { get; set; }
        public DateTime? Date { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public byte? Status { get; set; }
    }
}
