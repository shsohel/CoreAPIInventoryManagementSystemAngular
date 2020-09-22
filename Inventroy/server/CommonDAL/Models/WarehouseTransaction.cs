using System;
using System.Collections.Generic;
using System.Text;

namespace CommonDAL.Models
{
    public class WarehouseTransaction
    {
        public long Id { get; set; }
        public int OrganizationId { get; set; }
        public int ShopId { get; set; }
        public int TransactionType { get; set; }
        public int WarehouseId { get; set; }
        public DateTime Date { get; set; }
        public int Responsible { get; set; }
        public bool IsApproved { get; set; }
        public int ApporvedBy { get; set; }
        public string Note { get; set; }
        public byte Status { get; set; }
        public string CapturedBy { get; set; }
        public DateTime CaptureDate { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? UpdateDate { get; set; }
    }
}
