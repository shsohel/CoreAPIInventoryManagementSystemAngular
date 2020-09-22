using System;
using System.Collections.Generic;
using System.Text;

namespace CommonDAL.Models
{
    public class UserTypeButtonNotAccess
    {
        public int Id { get; set; }
        public int UserTypeId { get; set; }
        public int ButtonAccessId { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public byte Status { get; set; }
    }
}
