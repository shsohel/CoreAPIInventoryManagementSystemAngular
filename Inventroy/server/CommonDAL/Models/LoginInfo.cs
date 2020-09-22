using System;
using System.Collections.Generic;
using System.Text;

namespace CommonDAL.Models
{
    public class LoginInfo
    {
        public long Id { get; set; }
        public int ShopId { get; set; }
        public string SessionKey { get; set; }
        public int UserId { get; set; }
        public DateTime? LoginDateTime { get; set; }
        public DateTime? LogoutDate { get; set; }
        public string Ipaddress { get; set; }
        public int? UserTypeId { get; set; }
        public int Status { get; set; }
        public string Macaddress { get; set; }
        public string HostName { get; set; }
        public string InterfaceName { get; set; }
        public string Protocol { get; set; }
        public string PublicIp { get; set; }
        public string InterfaceDescription { get; set; }
    }
}
