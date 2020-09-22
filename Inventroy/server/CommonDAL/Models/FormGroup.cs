using System;
using System.Collections.Generic;
using System.Text;

namespace CommonDAL.Models
{
    public class FormGroup
    {
        public int Id { get; set; }
        public int AccountHolderId { get; set; }
        public string Key { get; set; }
        public string Name { get; set; }
        public int Priority { get; set; }
        public byte Status { get; set; }
    }
}
