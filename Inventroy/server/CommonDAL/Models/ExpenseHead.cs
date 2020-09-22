using System;
using System.Collections.Generic;
using System.Text;

namespace CommonDAL.Models
{
    public class ExpenseHead
    {
        public int Id { get; set; }
        public int OrganizationId { get; set; }
        public int ShopId { get; set; }
        public string ExpenseHeadNo { get; set; }
        public int ExpenseTypeId { get; set; }
        public int? ParentId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public byte? Status { get; set; }
    }
}
