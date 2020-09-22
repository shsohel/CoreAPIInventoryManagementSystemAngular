using System;
using System.Collections.Generic;
using System.Text;

namespace CommonDAL.Models
{
    public class ProducedReceivedItem
    {
        public long Id { get; set; }
        public int OrganizationId { get; set; }
        public int ShopId { get; set; }
        public long ProducedReceivedId { get; set; }
        public int ProductId { get; set; }
        public int ProductItemId { get; set; }
        public decimal Qty { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public byte Status { get; set; }
    }
}
