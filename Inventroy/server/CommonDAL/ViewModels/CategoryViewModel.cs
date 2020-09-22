using System;
using System.Collections.Generic;
using System.Text;

namespace CommonDAL.ViewModels
{
 public  class CategoryViewModel
    {
        public int? Id { get; set; }
        public int ParentId { get; set; }
        public string CategoryNo { get; set; }
        public int Priority { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public int? ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public byte Status { get; set; }
    }
    public  class CategoryDetailsViewModel : CategoryViewModel
    {
        public string CreatedByName { get; set; }
        public string ModifiedByName { get; set; }
        public string CreatedDateString { get; set; }
        public string ModifiedDateString { get; set; }
    }
}
