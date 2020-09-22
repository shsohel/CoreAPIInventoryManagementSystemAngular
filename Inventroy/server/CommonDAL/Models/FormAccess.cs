using System;
using System.Collections.Generic;
using System.Text;

namespace CommonDAL.Models
{
    public class FormAccess
    {
        public int Id { get; set; }
        public int FormGroupId { get; set; }
        public string Name { get; set; }
        public string KeyOfForm { get; set; }
        public int? Priority { get; set; }
        public byte Status { get; set; }
    }
}
