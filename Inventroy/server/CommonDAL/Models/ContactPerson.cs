using System;
using System.Collections.Generic;
using System.Text;

namespace CommonDAL.Models
{
    public class ContactPerson
    {
        public long Id { get; set; }
        public int OrganizationId { get; set; }
        public int ShopId { get; set; }
        public int ReferenceType { get; set; }
        public int ReferenceId { get; set; }
        public string Designation { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public byte Status { get; set; }
    }
}
