using System;
using System.Collections.Generic;
using System.Text;

namespace CommonDAL.ViewModels
{
    public class ProductItemViewModel
    {
        public long? Id { get; set; }
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
    public class ProductItemDetailsViewModel: ProductItemViewModel
    {
        public string ProductName { get; set; }
        public string CategoryName { get; set; }
        public string UnitName { get; set; }
        public string VatName { get; set; }
        public string ManufacturerName { get; set; }
        public string CreatedByName { get; set; }
        public string ModifiedByName { get; set; }
        public string CreatedDateString { get; set; }
        public string ModifiedDateString { get; set; }
    }
}
