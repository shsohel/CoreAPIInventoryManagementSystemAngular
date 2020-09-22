using System;
using System.Collections.Generic;
using System.Text;

namespace CommonDAL.Models
{
    public class ButtonAccess
    {
        public int Id { get; set; }
        public int FormAccessId { get; set; }
        public string Name { get; set; }
        public string KeyOfButton { get; set; }
        public byte Status { get; set; }
    }
}
