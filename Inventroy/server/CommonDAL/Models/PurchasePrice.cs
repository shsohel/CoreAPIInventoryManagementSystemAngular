using System;
using System.Collections.Generic;
using System.Text;

namespace CommonDAL.Models
{
    public class PurchasePrice
    {
        public int Id { get; set; }
        public int ProductItemId { get; set; }
        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }
        public decimal UnitPrice { get; set; }
        public bool Iscurrent { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public byte Status { get; set; }
    }
}
