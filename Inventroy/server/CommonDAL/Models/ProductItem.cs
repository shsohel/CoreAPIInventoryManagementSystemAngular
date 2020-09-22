using System;
using System.Collections.Generic;
using System.Text;

namespace CommonDAL.Models
{
    public class ProductItem
    {
        public long Id { get; set; }
        public int OrganizationId { get; set; }
        public int ShopId { get; set; }
        public string ProductItemNo { get; set; }
        public int ProductId { get; set; }
        public int CategoryId { get; set; }
        public int ManufacturerId { get; set; }
        public int UnitId { get; set; }
        public string BarCode { get; set; }
        public string Sku { get; set; }
        public int ProductType { get; set; }
        public int VATId { get; set; }
        //public decimal? Measure { get; set; }
        //public int? MeasureUnit { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public byte Status { get; set; }
        public bool IsSerialProduct { get; set; }
    }
}
