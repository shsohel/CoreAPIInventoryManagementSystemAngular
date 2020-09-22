using System;
using System.Collections.Generic;
using System.Text;

namespace CommonDAL.ViewModels
{
    public class ExpenseHeadViewModel
    {
        public int? Id { get; set; }
        public int? OrganizationId { get; set; }
        public int? ShopId { get; set; }
        public string ExpenseHeadNo { get; set; }
        public int ExpenseTypeId { get; set; }
        public int? ParentId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public byte? Status { get; set; }
    }
    public class ExpenseHeadDetailsViewModel : ExpenseHeadViewModel
    {
        public string ExpenseTypeName { get; set; }
        public string ParentTypeName { get; set; }
        public string CreatedByName { get; set; }
        public string CreatedDateString { get; set; }
        public string UpdatedByName { get; set; }
        public string UpdatedDateString { get; set; }
    }
}
