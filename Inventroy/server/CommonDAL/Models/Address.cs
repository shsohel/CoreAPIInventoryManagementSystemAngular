using System;
using System.Collections.Generic;
using System.Text;

namespace CommonDAL.Models
{
    public class Address
    {
        public long Id { get; set; }
        public int ShopId { get; set; }
        public int ReferenceType { get; set; }
        public int ReferenceId { get; set; }
        public string Address1 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string PostalCode { get; set; }
        public string Country { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public byte Status { get; set; }
    }
}
