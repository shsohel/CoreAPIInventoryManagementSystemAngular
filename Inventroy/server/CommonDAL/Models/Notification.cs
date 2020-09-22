using System;
using System.Collections.Generic;
using System.Text;

namespace CommonDAL.Models
{
    public class Notification
    {
        public long Id { get; set; }
        public int OrganizationId { get; set; }
        public int ShopId { get; set; }
        public int EmployeeId { get; set; }
        public string Message { get; set; }
        public DateTime Date { get; set; }
        public int Type { get; set; }
        public bool IsRead { get; set; }
        public byte Status { get; set; }
        public string CapturedBy { get; set; }
        public DateTime CaptureDate { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? UpdateDate { get; set; }
    }
}
