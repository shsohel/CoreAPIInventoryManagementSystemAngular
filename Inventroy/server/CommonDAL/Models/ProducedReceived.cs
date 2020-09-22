using System;
using System.Collections.Generic;
using System.Text;

namespace CommonDAL.Models
{
    public class ProducedReceived
    {
        public long Id { get; set; }
        public string Code { get; set; }
        public int OrganizationId { get; set; }
        public int ShopId { get; set; }
        public int ResponsibleEmployeeId { get; set; }
        public DateTime Date { get; set; }
        public string Note { get; set; }
        public bool IsLocked { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public byte Status { get; set; }
    }
}
