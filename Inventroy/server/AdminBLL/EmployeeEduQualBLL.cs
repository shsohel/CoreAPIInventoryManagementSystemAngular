using CommonBLL.Enums;
using CommonDAL.Models;
using CommonDAL.Repository;
using CommonDAL.ViewModels;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdminBLL
{
    public class EmployeeEduQualBLL
    {
        private readonly IRepository<EmployeeEduQual> repository;
        private readonly IRepository<Employee> emRepository;
        private readonly UserManager<User> userManager;

        public EmployeeEduQualBLL(IRepository<EmployeeEduQual> repository, IRepository<Employee> emRepository, UserManager<User> userManager)
        {
            this.repository = repository;
            this.emRepository = emRepository;
            this.userManager = userManager;
        }
        public async Task<IEnumerable<EmployeeEduQualViewModel>> GetEmployeeEduQuals()
        {
            try
            {
                IEnumerable<EmployeeEduQual> employeeEduQuals = await repository.GetAsync();
                List<EmployeeEduQualViewModel> employeeEduQualViewModels = new List<EmployeeEduQualViewModel>();
                if (employeeEduQuals != null)
                {
                    foreach (EmployeeEduQual employeeEdu in employeeEduQuals)
                    {
                        employeeEduQualViewModels.Add(assignDataToEmployeeEduQualViewModel(employeeEdu));
                    }
                    return employeeEduQualViewModels;
                }
            }
            catch (Exception e)
            {

            }
            return null;
        }
        public async Task<List<EmployeeEduQualViewModel>> GetEmployeeEduQual(long id)
        {
            try
            {
                Employee employee = await emRepository.GetAsync(id);
                IEnumerable<EmployeeEduQual> employeeEduQuals = await repository.GetAsync();
                List<EmployeeEduQual> filteredEmployeeEduQuals = employeeEduQuals.Where(x => x.EmployeeId == employee.Id).ToList();
                if (filteredEmployeeEduQuals != null)
                {
                    List<EmployeeEduQualViewModel> employeeEduQualViewModels = new List<EmployeeEduQualViewModel>();
                    foreach (EmployeeEduQual employeeEduQualem in filteredEmployeeEduQuals)
                    {
                        employeeEduQualViewModels.Add(assignDataToEmployeeEduQualViewModel(employeeEduQualem));
                    }
                    return employeeEduQualViewModels;
                }
            }
            catch (Exception e)
            {
                e.Message.Contains("Something Wrong");
            }
            return null;
        }
        public async Task<CreateEduQualViewModel> AddEmployeeEduQual(CreateEduQualViewModel models, ApplicationUser token)
        {
            try
            {
                List<EmployeeEduQual> employeeEduQuals = new List<EmployeeEduQual>();
                foreach (EmployeeEduQualViewModel model in models.EmployeeEduQualViewModels)
                {
                    EmployeeEduQual employeeEduQual = new EmployeeEduQual
                    {
                        BoardorUniversity = model.BoardorUniversity,
                        CreatedBy = token.Id,
                        CreatedDate = DateTime.Now,
                        EmployeeId =(int)model.EmployeeId,
                        PassingYear = Convert.ToDateTime(model.PassingYear),
                        RegistrationNo = model.RegistrationNo,
                        Result = model.Result,
                        ResultCgpa = model.ResultCgpa,
                        RollNo = model.RollNo,
                        Status = (byte)Status.Active,
                        SubjectId = model.SubjectId,
                        ClassTypeId=model.ClassTypeId,                  
                    };
                    employeeEduQuals.Add(employeeEduQual);
                }
              List<EmployeeEduQual> result = await repository.AddRangeAsync(employeeEduQuals);
                //  models.ToArray() = result.Id;
                if (result.Count > 0)
                {
                    CreateEduQualViewModel employeeEduQualViewModels = new CreateEduQualViewModel();
                    foreach (EmployeeEduQual employeeEduQual in result)
                    {
                        var data = assignDataToEmployeeEduQualViewModel(employeeEduQual);
                        employeeEduQualViewModels.EmployeeEduQualViewModels.Add(data);
                    }
                    return employeeEduQualViewModels;
                }
            }
            catch (Exception e)
            {

            }
            return null;
        }
        public async Task<CreateEduQualViewModel> UpdateEmployeeQual(CreateEduQualViewModel models, ApplicationUser token)
        {
            try
            {
                if (models != null)
                {
                    IEnumerable<EmployeeEduQual> employeeEduQuals = await repository.GetAsync();
                    List<EmployeeEduQual> filterEduQual = employeeEduQuals
                        .Where(x => x.EmployeeId == models.EmployeeEduQualViewModels[0].EmployeeId).ToList();
                    List<EmployeeEduQual> deletedEmployeeEduQul = new List<EmployeeEduQual>();
                    if (filterEduQual.Count>0)
                    {
                        foreach(EmployeeEduQual employeeEduQual in filterEduQual)
                        {
                            var resutl = models.EmployeeEduQualViewModels.Where(x => x.Id == employeeEduQual.Id).FirstOrDefault();
                            if(resutl == null)
                            {
                                deletedEmployeeEduQul.Add(employeeEduQual);
                            }
                        }
                        if(deletedEmployeeEduQul.Count > 0)
                        {
                            List<EmployeeEduQual> deletedResult = await repository.DeleteRangeAsync(deletedEmployeeEduQul);
                        }
                    }
                    List<EmployeeEduQual> updateEduQuals = new List<EmployeeEduQual>();
                    List<EmployeeEduQual> addEduQuals = new List<EmployeeEduQual>();
                    foreach (EmployeeEduQualViewModel model in models.EmployeeEduQualViewModels)
                    {
                        if (model.Id > 0)
                        {
                            EmployeeEduQual employeeEduQual = repository.GetAsync(model.Id).Result;
                            if (employeeEduQual !=null)
                            {
                                employeeEduQual.BoardorUniversity = model.BoardorUniversity;
                                employeeEduQual.PassingYear = Convert.ToDateTime(model.PassingYear);
                                employeeEduQual.RegistrationNo = model.RegistrationNo;
                                employeeEduQual.Result = model.Result;
                                employeeEduQual.ResultCgpa = model.ResultCgpa;
                                employeeEduQual.RollNo = model.RollNo;
                                employeeEduQual.SubjectId = model.SubjectId;
                                employeeEduQual.ClassTypeId = model.ClassTypeId;
                                employeeEduQual.UpdatedBy = token.Id;
                                employeeEduQual.UpdatedDate = DateTime.Now;
                            }
                            updateEduQuals.Add(employeeEduQual);
                        }
                        else
                        {
                            EmployeeEduQual employeeRefPerson = new EmployeeEduQual
                            {
                                BoardorUniversity = model.BoardorUniversity,
                                PassingYear = Convert.ToDateTime(model.PassingYear),
                                RegistrationNo = model.RegistrationNo,
                                Result = model.Result,
                                ResultCgpa = model.ResultCgpa,
                                RollNo = model.RollNo,
                                SubjectId = model.SubjectId,
                                ClassTypeId = model.ClassTypeId,
                                EmployeeId = (long)model.EmployeeId,
                                CreatedBy = token.Id,
                                CreatedDate = DateTime.Now,
                                Status = (byte)Status.Active
                                // Id=(long) model.Id
                            };
                            addEduQuals.Add(employeeRefPerson);
                        }
                    };
                    List<EmployeeEduQual> updateResult = await repository.UpdateRangeAsync(updateEduQuals);
                    if (addEduQuals.Count > 0)
                    {
                        List<EmployeeEduQual> addResult = await repository.AddRangeAsync(addEduQuals);
                    }
                    if (updateResult.Count > 0)
                    {
                        CreateEduQualViewModel employeeEduQualViewModels = new CreateEduQualViewModel();
                        foreach (EmployeeEduQual employeeEduQual in updateResult)
                        {
                            var data = assignDataToEmployeeEduQualViewModel(employeeEduQual);
                            employeeEduQualViewModels.EmployeeEduQualViewModels.Add(data);
                        }
                        return employeeEduQualViewModels;
                    }
                };

            }
            catch (Exception e)
            {

            }
            return null;
        }
        public async Task<List<EmployeeEduQualViewModel>> DeleteEmployeeEduQual(long id)
        {
            try
            {
                Employee employee = await emRepository.GetAsync((int)id);
                IEnumerable<EmployeeEduQual> employeeEduQuals = await repository.GetAsync();
                List<EmployeeEduQual> filteredEmployeeEduQuals = employeeEduQuals.Where(x => x.EmployeeId == employee.Id).ToList();
                if (filteredEmployeeEduQuals != null)
                {
                   List< EmployeeEduQual> result = await repository.DeleteRangeAsync(filteredEmployeeEduQuals);

                    //if (result != null)
                    //{
                    //    return assignDataToEmployeeEduQualViewModel(result);
                    //}
                }
            }
            catch (Exception e)
            {

            }
            return null;
        }
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
        public EmployeeEduQualViewModel assignDataToEmployeeEduQualViewModel(EmployeeEduQual employeeEduQual)
        {
            EmployeeEduQualViewModel employeeEduQualViewModel = new EmployeeEduQualViewModel
            {
                Id = employeeEduQual.Id,
                SubjectId=employeeEduQual.SubjectId,
                BoardorUniversity = employeeEduQual.BoardorUniversity,
                ClassTypeId = employeeEduQual.ClassTypeId,
                CreatedBy = employeeEduQual.CreatedBy,
                EmployeeId = employeeEduQual.EmployeeId,
                PassingYear = employeeEduQual.PassingYear,
                RegistrationNo = employeeEduQual.RegistrationNo,
                Result = employeeEduQual.Result,
                ResultCgpa = employeeEduQual.ResultCgpa,
                RollNo = employeeEduQual.RollNo,
                CreatedDate = Convert.ToDateTime(employeeEduQual.CreatedDate),
                UpdatedBy = employeeEduQual.UpdatedBy,
                UpdatedDate = Convert.ToDateTime(employeeEduQual.UpdatedDate),
                Status = (byte)employeeEduQual.Status
            };
            return employeeEduQualViewModel;
        }
    }
}