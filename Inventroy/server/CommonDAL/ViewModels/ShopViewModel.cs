using System;
using System.Collections.Generic;
using System.Text;

namespace CommonDAL.ViewModels
{
    public class ShopViewModel
    {
        public int? Id { get; set; }
        public int? OrganizationId { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string Owner { get; set; }
        public string Designation { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string Phone { get; set; }
        public string EmailForSystemGeneratedMail { get; set; }
        public string PasswordForSystemGeneratedMail { get; set; }
        public string VatRegNo { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public byte? Status { get; set; }
    }
    public  class ShopDetailsViewModel : ShopViewModel
    {
        public string CreatedByName { get; set; }
        public string CreatedDateString { get; set; }
        public string ModifiedByName { get; set; }
        public string ModifiedDateString { get; set; }
    }
}
