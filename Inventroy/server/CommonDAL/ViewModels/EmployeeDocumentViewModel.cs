using System;
using System.Collections.Generic;
using System.Text;

namespace CommonDAL.ViewModels
{
  public  class EmployeeDocumentViewModel
    {
        public long? Id { get; set; }
        public long? EmployeeId { get; set; }
        public string DocumentName { get; set; }
        public string FileName { get; set; }
        public string File { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public byte? Status { get; set; }
    }
    public class CreateUpdateEmpDocumentViewModel
    {
       public CreateUpdateEmpDocumentViewModel()
        {
            EmployeeDocumentViewModels = new List< EmployeeDocumentViewModel>();
        }
        public List<EmployeeDocumentViewModel> EmployeeDocumentViewModels { get; set; }
    }
}
