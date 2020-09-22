using System;
using System.Collections.Generic;
using System.Text;

namespace CommonDAL.Models
{
    public class SerialProductItem
    {
        public long Id { get; set; }
        public int OrganizationId { get; set; }
        public int ShopId { get; set; }
        public int ProductId { get; set; }
        public int ProductItemId { get; set; }
        public string SerialNo { get; set; }
        public long PurchaseId { get; set; }
        public long SalesId { get; set; }
        public byte Status { get; set; }
        public string CapturedBy { get; set; }
        public DateTime CaptureDate { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? UpdateDate { get; set; }
    }
}
