﻿using System;
using System.Collections.Generic;
using System.Text;

namespace CommonDAL.Models
{
    public class Warehouse
    {
        public int Id { get; set; }
        public int OrganizationId { get; set; }
        public int ShopId { get; set; }
        public string WarehouseNo { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Address { get; set; }
        public string ContactPerson { get; set; }
        public string MobileNo { get; set; }
        public string Email { get; set; }
        public bool IsDefault { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public byte Status { get; set; }
    }
}
