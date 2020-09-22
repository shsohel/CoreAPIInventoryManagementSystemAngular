using CommonBLL.Enums;
using CommonBLL.Helper;
using CommonDAL.Models;
using CommonDAL.Repository;
using CommonDAL.ViewModels;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdminBLL
{
 public class EmployeeDocumentBLL
    {
        private readonly IRepository<EmployeeDocument> repository;
        private readonly IRepository<Employee> emRepository;
        private readonly UserManager<User> userManager;

        public EmployeeDocumentBLL(IRepository<EmployeeDocument> repository, IRepository<Employee> emRepository, UserManager<User> userManager)
        {
            this.repository = repository;
            this.emRepository = emRepository;
            this.userManager = userManager;
        }
        public async Task<IEnumerable<EmployeeDocumentViewModel>> GetEmployeeDocuments()
        {
            try
            {
                IEnumerable<EmployeeDocument> employeeDocuments = await repository.GetAsync();
                List<EmployeeDocumentViewModel> employeeDocumentViewModels = new List<EmployeeDocumentViewModel>();
                if (employeeDocuments != null)
                {
                    foreach (EmployeeDocument employeeDocument in employeeDocuments)
                    {
                        employeeDocumentViewModels.Add(assignDataToEmployeeDocumentViewModel(employeeDocument));
                    }
                    return employeeDocumentViewModels;
                }
            }
            catch (Exception e)
            {

            }
            return null;
        }
        public async Task<List<EmployeeDocumentViewModel>> GetEmployeeDocument(long id)
        {
            try
            {
                Employee employee = await emRepository.GetAsync(id);
                IEnumerable<EmployeeDocument> employeeDocuments = await repository.GetAsync();
                List<EmployeeDocument> filteredEmployeeDocuments = employeeDocuments.Where(x => x.EmployeeId == employee.Id).ToList();
                if (filteredEmployeeDocuments != null)
                {
                    List<EmployeeDocumentViewModel> employeeDocumentViewModels = new List<EmployeeDocumentViewModel>();
                    foreach (EmployeeDocument employeeDocument in filteredEmployeeDocuments)
                    {
                        employeeDocumentViewModels.Add(assignDataToEmployeeDocumentViewModel(employeeDocument));
                    }
                    return employeeDocumentViewModels;
                }
            }
            catch (Exception e)
            {
                e.Message.Contains("Something Wrong");
            }
            return null;
        }
        public async Task<CreateUpdateEmpDocumentViewModel> AddEmployeeDocument(CreateUpdateEmpDocumentViewModel models, IHostingEnvironment hostingEnvironment, ApplicationUser token)
        {
            try
            {
                List<EmployeeDocument> employeeDocuments = new List<EmployeeDocument>();
                foreach (EmployeeDocumentViewModel model in models.EmployeeDocumentViewModels)
                {
                    EmployeeDocument employeeDocument = new EmployeeDocument
                    {
                        EmployeeId=model.EmployeeId,
                        DocumentName=model.DocumentName,
                        FileName= FileUploader.Upload(model.File, "EmployeesImages", model.FileName, hostingEnvironment),
                        CreatedBy =token.Id,
                        CreatedDate=DateTime.Now,
                        Status = (byte)Status.Active
                    };
                    employeeDocuments.Add(employeeDocument);
                }
                List<EmployeeDocument> result = await repository.AddRangeAsync(employeeDocuments);
                if (result.Count > 0)
                {
                    CreateUpdateEmpDocumentViewModel employeeDocumentViewModels = new CreateUpdateEmpDocumentViewModel();
                    foreach (EmployeeDocument employeeDocument in result)
                    {
                        var data = assignDataToEmployeeDocumentViewModel(employeeDocument);
                        employeeDocumentViewModels.EmployeeDocumentViewModels.Add(data);
                    }

                    //CreateEduQualViewModel employeeEduQualViewModels = new CreateEduQualViewModel();
                    //foreach (EmployeeEduQual employeeEduQual in result)
                    //{
                    //    var data = assignDataToEmployeeEduQualViewModel(employeeEduQual);
                    //    employeeEduQualViewModels.EmployeeEduQualViewModels.Add(data);
                    //}
                    return employeeDocumentViewModels;
                }
            }
            catch (Exception e)
            {

            }
            return null;
        }
        public async Task<CreateUpdateEmpDocumentViewModel> UpdateEmployeeDocument(CreateUpdateEmpDocumentViewModel models, IHostingEnvironment hostingEnvironment, ApplicationUser token)
        {
            try
            {
                if (models != null)
                {
                    IEnumerable<EmployeeDocument> employeeDocuments = await repository.GetAsync();
                    List<EmployeeDocument> filterEmDocument = employeeDocuments
                        .Where(x => x.EmployeeId == models.EmployeeDocumentViewModels[0].EmployeeId).ToList();
                    List<EmployeeDocument> deletedEmployeeDocument = new List<EmployeeDocument>();

                    //List<CreateUpdateEmpDocumentViewModel> newFile = models.EmployeeDocumentViewModels;

                    if (filterEmDocument.Count > 0)
                    {
                        foreach (EmployeeDocument employeeDocument in filterEmDocument)
                        {
                            var resutl = models.EmployeeDocumentViewModels.Where(x => x.Id == employeeDocument.Id).FirstOrDefault();
                            if (resutl == null)
                            {
                                deletedEmployeeDocument.Add(employeeDocument);
                            }
                        }
                        if (deletedEmployeeDocument.Count > 0)
                        {
                            List<EmployeeDocument> deletedResult = await repository.DeleteRangeAsync(deletedEmployeeDocument);
                            foreach (EmployeeDocument employeeDocument in deletedResult)
                            {
                                FileDeleter.Delete(employeeDocument.FileName, "EmployeesImages", hostingEnvironment);
                            }
                        }
                    }
                    List<EmployeeDocument> updateEmDocuments = new List<EmployeeDocument>();
                    List<EmployeeDocument> addEmDocument = new List<EmployeeDocument>();
                    foreach (EmployeeDocumentViewModel model in models.EmployeeDocumentViewModels)
                    {
                        if (model.Id > 0)
                        {
                            EmployeeDocument employeeDocument = repository.GetAsync(model.Id).Result;
                            if (employeeDocument != null)
                            {
                                employeeDocument.UpdatedBy = token.Id;
                                employeeDocument.UpdatedDate = DateTime.Now;
                            }
                            updateEmDocuments.Add(employeeDocument);
                        }
                        else
                        {
                            EmployeeDocument employeeDocument = new EmployeeDocument
                            {
                                EmployeeId = model.EmployeeId,
                                DocumentName = model.DocumentName,
                                FileName = FileUploader.Upload(model.File, "EmployeesImages", model.FileName, hostingEnvironment),
                                CreatedBy = token.Id,
                                CreatedDate = DateTime.Now,
                                Status = (byte)Status.Active
                            };
                            addEmDocument.Add(employeeDocument);
                        }
                    };
                    List<EmployeeDocument> updateResult = await repository.UpdateRangeAsync(updateEmDocuments);
                    if (addEmDocument.Count > 0)
                    {
                        List<EmployeeDocument> addResult = await repository.AddRangeAsync(addEmDocument);
                    }
                    if (updateResult.Count > 0)
                    {
                        CreateUpdateEmpDocumentViewModel employeeDocumentViewModels = new CreateUpdateEmpDocumentViewModel();
                        foreach (EmployeeDocument employeeDocument in updateResult)
                        {
                            var data = assignDataToEmployeeDocumentViewModel(employeeDocument);
                            employeeDocumentViewModels.EmployeeDocumentViewModels.Add(data);
                        }
                        return employeeDocumentViewModels;
                        //CreateEduQualViewModel employeeEduQualViewModels = new CreateEduQualViewModel();
                        //foreach (EmployeeEduQual employeeEduQual in updateResult)
                        //{
                        //    var data = assignDataToEmployeeEduQualViewModel(employeeEduQual);
                        //    employeeEduQualViewModels.EmployeeEduQualViewModels.Add(data);
                        //}
                        //return employeeEduQualViewModels;
                    }
                };

            }
            catch (Exception e)
            {

            }
            return null;
        }
        //public async Task<List<EmployeeEduQualViewModel>> DeleteEmployeeEduQual(long id)
        //{
        //    try
        //    {
        //        Employee employee = await emRepository.GetAsync((int)id);
        //        IEnumerable<EmployeeEduQual> employeeEduQuals = await repository.GetAsync();
        //        List<EmployeeEduQual> filteredEmployeeEduQuals = employeeEduQuals.Where(x => x.EmployeeId == employee.Id).ToList();
        //        if (filteredEmployeeEduQuals != null)
        //        {
        //            List<EmployeeEduQual> result = await repository.DeleteRangeAsync(filteredEmployeeEduQuals);
        //            //if (result != null)
        //            //{
        //            //    return assignDataToEmployeeEduQualViewModel(result);
        //            //}
        //        }
        //    }
        //    catch (Exception e)
        //    {

        //    }
        //    return null;
        //}
        //public async Task<EmployeeViewModel> GetDetails(long id)
        //{
        //    try
        //    {
        //        Employee employee = await repository.GetAsync(id);
        //        if (employee != null)
        //        {
        //            EmployeeViewModel employeeViewModel = new EmployeeViewModel
        //            {
        //                Id = employee.Id,
        //                ShopId = employee.ShopId,
        //                Name = employee.Name,
        //                Phone = employee.Phone,
        //                Mobile = employee.Mobile,
        //                //   Address = employee.Address,
        //                Designation = employee.Designation,
        //                EmployeeNo = employee.EmployeeNo,
        //                Email = employee.Email,
        //                IsOwner = employee.IsOwner,
        //                /// Picture = employee.Picture,
        //                // CreatedBy = employee.CreatedBy,
        //                CreatedDate = Convert.ToDateTime(employee.CreatedDate),
        //                // ModifiedBy = employee.ModifiedBy,
        //                ModifiedDate = Convert.ToDateTime(employee.ModifiedDate),
        //                Status = (byte)employee.Status
        //            };
        //            return employeeViewModel;
        //        }
        //    }
        //    catch (Exception e)
        //    {

        //    }
        //    return null;
        //}
        //public async Task<List<EmployeeViewModel>> GetTableData()
        //{
        //    try
        //    {
        //        IEnumerable<Employee> employees = await repository.GetAsync();
        //        List<EmployeeViewModel> employeeViewModels = new List<EmployeeViewModel>();
        //        foreach (Employee employee in employees)
        //        {
        //            EmployeeViewModel employeeViewModel = new EmployeeViewModel
        //            {
        //                Id = employee.Id,
        //                ShopId = employee.ShopId,
        //                Name = employee.Name,
        //                Phone = employee.Phone,
        //                Mobile = employee.Mobile,
        //                ///   Address = employee.Address,
        //                Designation = employee.Designation,
        //                EmployeeNo = employee.EmployeeNo,
        //                Email = employee.Email,
        //                IsOwner = employee.IsOwner,
        //                //   Picture = employee.Picture,
        //                //    CreatedBy = employee.CreatedBy,
        //                CreatedDate = Convert.ToDateTime(employee.CreatedDate),
        //                //  ModifiedBy = employee.ModifiedBy,
        //                ModifiedDate = Convert.ToDateTime(employee.ModifiedDate),
        //                Status = (byte)employee.Status
        //            };
        //            employeeViewModels.Add(employeeViewModel);
        //        }
        //        if (employeeViewModels != null)
        //        {
        //            return employeeViewModels;
        //        }
        //    }
        //    catch (Exception e)
        //    {

        //    }
        //    return null;
        //}
        public EmployeeDocumentViewModel assignDataToEmployeeDocumentViewModel(EmployeeDocument  employeeDocument)
        {
            EmployeeDocumentViewModel employeeDocumentViewModel = new EmployeeDocumentViewModel
            {
                Id = employeeDocument.Id,
                CreatedBy= employeeDocument.CreatedBy,
                DocumentName=employeeDocument.DocumentName,
                EmployeeId=employeeDocument.EmployeeId,
                FileName=employeeDocument.FileName,
                CreatedDate = Convert.ToDateTime(employeeDocument.CreatedDate),
                UpdatedBy = employeeDocument.UpdatedBy,
                UpdatedDate = Convert.ToDateTime(employeeDocument.UpdatedDate),
                Status = (byte)employeeDocument.Status
            };
            return employeeDocumentViewModel;
        }
    }
}