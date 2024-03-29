﻿using System;
using System.Collections.Generic;
using System.Text;

namespace CommonDAL.Models
{
    public class ProductionRawSettings
    {
        public int Id { get; set; }
        public int OrganizationId { get; set; }
        public int ShopId { get; set; }
        public int ProductionType { get; set; }
        public int ProductItemId { get; set; }
        public string Amount { get; set; }
        public decimal? Price { get; set; }
        public byte Status { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
    }
}
