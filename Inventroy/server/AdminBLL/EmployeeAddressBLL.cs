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
   public class EmployeeAddressBLL
    {
        private readonly IRepository<EmployeeAddress> repository;
        private readonly IRepository<Employee> emRepository;
        private readonly UserManager<User> userManager;
        public EmployeeAddressBLL(IRepository<EmployeeAddress> repository, IRepository<Employee> emRepository,  UserManager<User> userManager)
        {
            this.repository = repository;
            this.emRepository = emRepository;
            this.userManager = userManager;
        }
        public async Task<IEnumerable<EmployeeAddressViewModel>> GetEmployeeAddresses()
        {
            try
            {
                IEnumerable<EmployeeAddress> employeeAddresses = await repository.GetAsync();
                List<EmployeeAddressViewModel> employeeAddressViewModels = new List<EmployeeAddressViewModel>();
                if (employeeAddresses != null)
                {
                    foreach (EmployeeAddress employeeAddress in employeeAddresses)
                    {
                        employeeAddressViewModels.Add(assignDataToEmployeeAddresssViewModel(employeeAddress));
                    }
                    return employeeAddressViewModels;
                }
            }
            catch (Exception e)
            {

            }
            return null;
        }
        public async Task<EmployeeAddressViewModel> GetEmployeeAddress(long id)
        {
            try
            {
                Employee employee = await emRepository.GetAsync(id);
                IEnumerable<EmployeeAddress> employeeAddresses = await repository.GetAsync();
                EmployeeAddress employeeAddress = employeeAddresses.Where(x => x.EmployeeId == employee.Id).FirstOrDefault();
                if (employeeAddress != null)
                {
                    return assignDataToEmployeeAddresssViewModel(employeeAddress);
                }
            }
            catch (Exception e)
            {
                e.Message.Contains("Something Wrong");
            }
            return null;
        }
        public async Task<EmployeeAddressViewModel> AddEmployeeAddress(EmployeeAddressViewModel model, ApplicationUser token)
        {
            try
            {
                EmployeeAddress employeeBasic = new EmployeeAddress
                {
                    PresentVillageHouse=model.PresentVillageHouse,
                    PermanentUpazila=model.PermanentUpazila,
                    EmployeeId=model.EmployeeId,
                    PermanentDistrict=model.PermanentDistrict,
                    PermanentPostCode=model.PermanentPostCode,
                    PermanentPostOffice=model.PermanentPostOffice,
                    PermanentRoadBlockSector=model.PermanentRoadBlockSector,
                    PermanentVillageHouse=model.PermanentVillageHouse,
                    PresentDistrict=model.PresentDistrict,
                    PresentPostCode=model.PresentPostCode,
                    PresentPostOffice=model.PresentPostOffice,
                    PresentRoadBlockSector=model.PresentRoadBlockSector,
                    PresentUpazila=model.PresentUpazila,                   
                    CapturedBy = token.Id,
                    CapturedDate = DateTime.Now,
                    Status = (byte)Status.Active,
                };
                EmployeeAddress result = await repository.AddAsync(employeeBasic);
                model.Id = result.Id;
                if (result != null)
                {
                    return assignDataToEmployeeAddresssViewModel(result);
                }
            }
            catch (Exception e)
            {

            }
            return null;
        }
        public async Task<EmployeeAddressViewModel> UpdateEmployeeAddress(EmployeeAddressViewModel model, ApplicationUser token)
        {
            try
            {
                EmployeeAddress employeeAddress = await repository.GetAsync((long)model.Id);
                if (employeeAddress != null)
                {
                    employeeAddress.EmployeeId = model.EmployeeId;
                    employeeAddress.PermanentDistrict = model.PermanentDistrict;
                    employeeAddress.PermanentPostCode = model.PermanentPostCode;
                    employeeAddress.PermanentPostOffice = model.PermanentPostOffice;
                    employeeAddress.PermanentRoadBlockSector = model.PermanentRoadBlockSector;
                    employeeAddress.PermanentUpazila = model.PermanentUpazila;
                    employeeAddress.PermanentVillageHouse = model.PermanentVillageHouse;
                    employeeAddress.PresentDistrict = model.PresentDistrict;
                    employeeAddress.PresentPostCode = model.PresentPostCode;
                    employeeAddress.PresentPostOffice = model.PresentPostOffice;
                    employeeAddress.PresentRoadBlockSector = model.PresentRoadBlockSector;
                    employeeAddress.PresentUpazila = model.PresentUpazila;
                    employeeAddress.PresentVillageHouse = model.PresentVillageHouse;
                    employeeAddress.UpdatedBy = token.Id;
                    employeeAddress.UpdatedDate = DateTime.Now;
                    EmployeeAddress result = await repository.UpdateAsync(employeeAddress);
                    if (result != null)
                    {
                        return assignDataToEmployeeAddresssViewModel(result);
                    }
                }
            }
            catch (Exception e)
            {

            }
            return null;
        }
        //public async Task<EmployeeViewModel> DeleteEmployee(long id)
        //{
        //    try
        //    {
        //        Employee employee = await repository.GetAsync(id);
        //        if (employee != null)
        //        {
        //            Employee result = await repository.DeleteAsync(employee);
        //            if (result != null)
        //            {
        //                return assignDataToEmployeeViewModel(result);
        //            }
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
        public EmployeeAddressViewModel assignDataToEmployeeAddresssViewModel(EmployeeAddress employeeAddress)
        {
            EmployeeAddressViewModel employeeViewModel = new EmployeeAddressViewModel
            {
                Id = employeeAddress.Id,
                EmployeeId=employeeAddress.EmployeeId,
                PermanentDistrict=employeeAddress.PermanentDistrict,
                PermanentPostCode=employeeAddress.PermanentPostCode,
                PermanentPostOffice=employeeAddress.PermanentPostOffice,
                PermanentRoadBlockSector=employeeAddress.PermanentRoadBlockSector,
                PermanentUpazila=employeeAddress.PermanentUpazila,
                PermanentVillageHouse=employeeAddress.PermanentVillageHouse,
                PresentDistrict=employeeAddress.PresentDistrict,
                PresentPostCode=employeeAddress.PresentPostCode,
                PresentPostOffice=employeeAddress.PresentPostOffice,
                PresentRoadBlockSector=employeeAddress.PresentRoadBlockSector,
                PresentUpazila=employeeAddress.PresentUpazila,
                CapturedBy=employeeAddress.CapturedBy,
                PresentVillageHouse=employeeAddress.PresentVillageHouse,
                CapturedDate = Convert.ToDateTime(employeeAddress.CapturedDate),
                UpdatedBy = employeeAddress.UpdatedBy,
                UpdatedDate = Convert.ToDateTime(employeeAddress.UpdatedDate),
                Status = (byte)employeeAddress.Status
            };
            return employeeViewModel;
        }
    }
}