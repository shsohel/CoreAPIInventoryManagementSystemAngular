using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CommonDAL.ViewModels
{
    public class VendorViewModel
    {
        public long? Id { get; set; }
        public int OrganizationId { get; set; }
        public int ShopId { get; set; }
        public string VendorNo { get; set; }
        public string Name { get; set; }
        public int GuarantorId { get; set; }
        public string MobileNo { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string RegistrationNo { get; set; }
        public string Tin { get; set; }
        public decimal CreditLimit { get; set; }
        public decimal DiscountPercent { get; set; }
        public DateTime DayOfPayment { get; set; }
        public string Picture { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public byte Status { get; set; }
    }
    public class VedorDetailsViewModel : VendorViewModel
    {
        public string DayOfPaymentString { get; set; }
        public string GurantorName { get; set; }
        public string CreatedByName { get; set; }
        public string ModifiedByName { get; set; }
        public string CreatedDateString { get; set; }
        public string ModifiedDateString { get; set; }
    }
}

