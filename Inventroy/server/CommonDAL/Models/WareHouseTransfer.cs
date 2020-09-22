using System;
using System.Collections.Generic;
using System.Text;

namespace CommonDAL.Models
{
    public class WareHouseTransfer
    {
        public long Id { get; set; }
        public int OrganizationId { get; set; }
        public int ShopId { get; set; }
        public string WareHouseTransferNo { get; set; }
        public int WareHouseIdfrom { get; set; }
        public int WareHouseIdto { get; set; }
        public DateTime Date { get; set; }
        public string Note { get; set; }
        public string RequestBy { get; set; }
        public bool IsApproved { get; set; }
        public string ApprovedBy { get; set; }
        public bool IsLocked { get; set; }
        public byte Status { get; set; }
        public string CapturedBy { get; set; }
        public DateTime CaptureDate { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? UpdateDate { get; set; }
    }
}
