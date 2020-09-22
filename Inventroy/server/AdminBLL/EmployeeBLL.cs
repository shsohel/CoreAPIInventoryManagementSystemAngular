using CommonBLL.Enums;
using CommonDAL.Models;
using CommonDAL.Repository;
using CommonDAL.ViewModels;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AdminBLL
{
  public  class EmployeeBLL
    {
        private readonly IRepository<Employee> repository;
        private readonly UserManager<User> userManager;

        public EmployeeBLL(IRepository<Employee> repository, UserManager<User> userManager)
        {
            this.repository = repository;
            this.userManager = userManager;
        }
        public async Task<IEnumerable<EmployeeViewModel>> GetEmployees()
        {
            try
            {
                IEnumerable<Employee> employees = await repository.GetAsync();
                List<EmployeeViewModel> employeeViewModels = new List<EmployeeViewModel>();
                if (employees != null)
                {
                    foreach (Employee employee in employees)
                    {
                        employeeViewModels.Add(assignDataToEmployeeViewModel(employee));
                    }
                    return employeeViewModels;
                }
            }
            catch (Exception e)
            {

            }
            return null;
        }
        public async Task<EmployeeViewModel> GetEmployee(long id)
        {
            try
            {
                Employee employee = await repository.GetAsync(id);
                if (employee != null)
                {
                    return assignDataToEmployeeViewModel(employee);
                }
            }
            catch (Exception e)
            {
                e.Message.Contains("Something Wrong");
            }
            return null;
        }
        public async Task<EmployeeViewModel> AddEmployee(EmployeeViewModel model, ApplicationUser token)
        {
            try
            {
                Employee employee = new Employee
                {
                    OrganizationId = token.OrganizationId,
                    ShopId = token.ShopId,
                    FirstName=model.FirstName,
                    LastName=model.LastName,
                    Name = model.FirstName+" "+model.LastName,
                    Phone = model.Phone,
                    Mobile = model.Mobile,
                    Designation = model.Designation,
                    EmployeeNo = DateTime.Now.ToString("ddMMyyhhmmssmmm"),
                    ResidanceMobileNo=model.ResidanceMobileNo,
                    SalaryTypeId=model.SalaryTypeId,
                    TerminationDate=model.TerminationDate,
                    JoiningDate=model.JoiningDate,
                    CreatedBy=token.Id,      
                    Email = model.Email,
                    IsOwner = model.IsOwner,
                    CreatedDate = DateTime.Now,
                    Status = (byte)Status.Active
                };
                Employee result = await repository.AddAsync(employee);
                model.Id = result.Id;
                if (result != null)
                {
                    return assignDataToEmployeeViewModel(result);
                }
            }
            catch (Exception e)
            {

            }
            return null;
        }
        public async Task<EmployeeViewModel> UpdateEmployee(EmployeeViewModel model, ApplicationUser token)
        {
            try
            {
                Employee employee = await repository.GetAsync(model.Id);
                if (employee != null)
                {
                    employee.FirstName = model.FirstName;
                     employee.LastName = model.LastName;
                     employee.Name = model.FirstName + " " + model.LastName;
                     employee.Phone = model.Phone;
                     employee.Mobile = model.Mobile;
                     employee.Designation = model.Designation;
                    // employee.EmployeeNo = DateTime.Now.ToString("ddMMyyhhmmssmmm");
                     employee.ResidanceMobileNo = model.ResidanceMobileNo;
                     employee.SalaryTypeId = model.SalaryTypeId;
                     employee.TerminationDate = model.TerminationDate;
                     employee.JoiningDate = model.JoiningDate;
                     employee.ModifiedBy = token.Id;      
                     employee.Email = model.Email;
                     employee.IsOwner = model.IsOwner;
                     employee.ModifiedDate = DateTime.Now;
                    Employee result = await repository.UpdateAsync(employee);
                    if (result != null)
                    {
                        return assignDataToEmployeeViewModel(result);
                    }
                }
            }
            catch (Exception e)
            {

            }
            return null;
        }
        public async Task<EmployeeViewModel> DeleteEmployee(long id)
        {
            try
            {
                Employee  employee = await repository.GetAsync(id);
                if (employee != null)
                {
                    Employee result = await repository.DeleteAsync(employee);
                    if (result != null)
                    {
                        return assignDataToEmployeeViewModel(result);
                    }
                }
            }
            catch (Exception e)
            {

            }
            return null;
        }
        public async Task<EmployeeViewModel> GetDetails(long id)
        {
            try
            {
                Employee employee = await repository.GetAsync(id);
                if (employee != null)
                {
                    EmployeeViewModel employeeViewModel = new EmployeeViewModel
                    {
                        Id = employee.Id,
                        ShopId = employee.ShopId,
                        Name = employee.Name,
                        Phone = employee.Phone,
                        Mobile = employee.Mobile,
                     //   Address = employee.Address,
                        Designation = employee.Designation,
                        EmployeeNo = employee.EmployeeNo,
                        Email = employee.Email,
                        IsOwner = employee.IsOwner,
                       /// Picture = employee.Picture,
                       // CreatedBy = employee.CreatedBy,
                        CreatedDate = Convert.ToDateTime(employee.CreatedDate),
                       // ModifiedBy = employee.ModifiedBy,
                        ModifiedDate = Convert.ToDateTime(employee.ModifiedDate),
                        Status =(byte) employee.Status
                    };
                    return employeeViewModel;
                }
            }
            catch (Exception e)
            {

            }
            return null;
        }
        public async Task<List<EmployeeViewModel>> GetTableData()
        {
            try
            {
                IEnumerable<Employee>  employees = await repository.GetAsync();
                List<EmployeeViewModel> employeeViewModels = new List<EmployeeViewModel>();
                foreach (Employee employee in employees)
                {
                    EmployeeViewModel employeeViewModel = new EmployeeViewModel
                    {
                        Id = employee.Id,
                        ShopId = employee.ShopId,
                        Name = employee.Name,
                        Phone = employee.Phone,
                        Mobile = employee.Mobile,
                     ///   Address = employee.Address,
                        Designation = employee.Designation,
                        EmployeeNo = employee.EmployeeNo,
                        Email = employee.Email,
                        IsOwner = employee.IsOwner,
                     //   Picture = employee.Picture,
                    //    CreatedBy = employee.CreatedBy,
                        CreatedDate = Convert.ToDateTime(employee.CreatedDate),
                      //  ModifiedBy = employee.ModifiedBy,
                        ModifiedDate = Convert.ToDateTime(employee.ModifiedDate),
                        Status = (byte)employee.Status
                    };
                    employeeViewModels.Add(employeeViewModel);
                }
                if (employeeViewModels != null)
                {
                    return employeeViewModels;
                }
            }
            catch (Exception e)
            {

            }
            return null;
        }
        public EmployeeViewModel assignDataToEmployeeViewModel(Employee employee)
        {
            EmployeeViewModel employeeViewModel = new EmployeeViewModel
            {
                Id = employee.Id,
                ShopId = employee.ShopId,
                Name = employee.Name,
                FirstName=employee.FirstName,
                LastName=employee.LastName,
                ResidanceMobileNo=employee.ResidanceMobileNo,
                SalaryTypeId=employee.SalaryTypeId,
                OrganizationId=employee.OrganizationId,
                JoiningDate=employee.JoiningDate,
                CreatedBy=employee.CreatedBy,
                ModifiedBy=employee.ModifiedBy,
                TerminationDate=employee.TerminationDate,
                Phone = employee.Phone,
                Mobile = employee.Mobile,
                Designation = employee.Designation,
                EmployeeNo = employee.EmployeeNo,
                Email = employee.Email,
                IsOwner = employee.IsOwner,
                CreatedDate = Convert.ToDateTime(employee.CreatedDate),
               // ModifiedBy = employee.ModifiedBy,
                ModifiedDate = Convert.ToDateTime(employee.ModifiedDate),
                Status=(byte)employee.Status
            };
            return employeeViewModel;
        }
    }
}
