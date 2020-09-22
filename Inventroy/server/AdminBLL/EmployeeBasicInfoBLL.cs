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
    public class EmployeeBasicInfoBLL
    {
        private readonly IRepository<EmployeeBasicInfo> repository;
        private readonly IRepository<Employee> emrepository;

        private readonly UserManager<User> userManager;

        public EmployeeBasicInfoBLL(IRepository<EmployeeBasicInfo> repository, IRepository<Employee> emrepository, UserManager<User> userManager)
        {
            this.repository = repository;
            this.emrepository = emrepository;
            this.userManager = userManager;
        }
        public async Task<IEnumerable<EmployeeBasicInfoViewModel>> GetEmployeeBasicInfos()
        {
            try
            {
                IEnumerable<EmployeeBasicInfo> employeeBasicInfos = await repository.GetAsync();
                List<EmployeeBasicInfoViewModel> employeeBasicInfoViewModels = new List<EmployeeBasicInfoViewModel>();
                if (employeeBasicInfos != null)
                {
                    foreach (EmployeeBasicInfo employee in employeeBasicInfos)
                    {
                        employeeBasicInfoViewModels.Add(assignDataToEmployeeBasicViewModel(employee));
                    }
                    return employeeBasicInfoViewModels;
                }
            }
            catch (Exception e)
            {

            }
            return null;
        }
        public async Task<EmployeeBasicInfoViewModel> GetEmployeeBasicInfo(long id)
        {
            try
            {
                Employee employee = await emrepository.GetAsync(id);
                IEnumerable<EmployeeBasicInfo> employeeBasics = await repository.GetAsync();
                EmployeeBasicInfo basicInfo = employeeBasics.Where(x => x.EmployeeId == employee.Id).FirstOrDefault();
                if (basicInfo != null)
                {
                    return assignDataToEmployeeBasicViewModel(basicInfo);
                }
            }
            catch (Exception e)
            {
                e.Message.Contains("Something Wrong");
            }
            return null;
        }
        public async Task<EmployeeBasicInfoViewModel> AddEmployeeBasic(EmployeeBasicInfoViewModel model, ApplicationUser token)
        {
            try
            {
                EmployeeBasicInfo employeeBasic = new EmployeeBasicInfo
                {
                    MothersName = model.MothersName,
                    Hight = model.Hight,
                    ReligionId = model.ReligionId,
                    DistictOfBirthId = model.DistictOfBirthId,
                    BirthRegNo = model.BirthRegNo,
                    BloodGroupId = model.BloodGroupId,
                    CitizenShipStatusId = model.CitizenShipStatusId,
                    CountryOfBirthId = model.CountryOfBirthId,
                    DateOfBirth = model.DateOfBirth,
                    EmployeeId = model.EmployeeId,
                    FathersName = model.FathersName,
                    FathersProfession = model.FathersProfession,
                    GenderId = model.GenderId,
                    MothersProfession = model.MothersProfession,
                    NationalIdno = model.NationalIdno,
                    NationalityId = model.NationalityId,
                    PassportNo = model.PassportNo,
                    CreatedBy = token.Id,
                    CreatedDate = DateTime.Now,
                    Status = (byte)Status.Active,
                };
                EmployeeBasicInfo result = await repository.AddAsync(employeeBasic);
                model.Id = result.Id;
                if (result != null)
                {
                    return assignDataToEmployeeBasicViewModel(result);
                }
            }
            catch (Exception e)
            {

            }
            return null;
        }
        public async Task<EmployeeBasicInfoViewModel> UpdateEmployeeBasic(EmployeeBasicInfoViewModel model, ApplicationUser token)
        {
            try
            {
                Employee employee = new Employee();
                EmployeeBasicInfo employeeBasic = await repository.GetAsync((long)model.Id);
                if (employeeBasic != null)
                {
                    employeeBasic.MothersName = model.MothersName;
                    employeeBasic.Hight = model.Hight;
                    employeeBasic.ReligionId = model.ReligionId;
                    employeeBasic.DistictOfBirthId = model.DistictOfBirthId;
                    employeeBasic.BirthRegNo = model.BirthRegNo;
                    employeeBasic.BloodGroupId = model.BloodGroupId;
                    employeeBasic.CitizenShipStatusId = model.CitizenShipStatusId;
                    employeeBasic.CountryOfBirthId = model.CountryOfBirthId;
                    employeeBasic.DateOfBirth = model.DateOfBirth;
                   // employeeBasic.EmployeeId = model.EmployeeId;
                    employeeBasic.FathersName = model.FathersName;
                    employeeBasic.FathersProfession = model.FathersProfession;
                    employeeBasic.GenderId = model.GenderId;
                    employeeBasic.MothersProfession = model.MothersProfession;
                    employeeBasic.NationalIdno = model.NationalIdno;
                    employeeBasic.NationalityId = model.NationalityId;
                    employeeBasic.PassportNo = model.PassportNo;
                    employeeBasic.CreatedBy = token.Id;
                    employeeBasic.CreatedDate = DateTime.Now;
                    employeeBasic.Status = (byte)Status.Active;
                    EmployeeBasicInfo result = await repository.UpdateAsync(employeeBasic);
                    if (result != null)
                    {
                        return assignDataToEmployeeBasicViewModel(result);
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
        public EmployeeBasicInfoViewModel assignDataToEmployeeBasicViewModel(EmployeeBasicInfo employeeBasicInfo)
        {
            EmployeeBasicInfoViewModel employeeViewModel = new EmployeeBasicInfoViewModel
            {
                Id = employeeBasicInfo.Id,
                BirthRegNo=employeeBasicInfo.BirthRegNo,
                BloodGroupId=employeeBasicInfo.BloodGroupId,
                CitizenShipStatusId=employeeBasicInfo.CitizenShipStatusId,
                CountryOfBirthId=employeeBasicInfo.CitizenShipStatusId,
                DateOfBirth=employeeBasicInfo.DateOfBirth,
                DistictOfBirthId=employeeBasicInfo.DistictOfBirthId,
                EmployeeId=employeeBasicInfo.EmployeeId,
                FathersName=employeeBasicInfo.FathersName,
                FathersProfession=employeeBasicInfo.FathersProfession,
                GenderId=employeeBasicInfo.GenderId,
                Hight=employeeBasicInfo.Hight,
                MothersName=employeeBasicInfo.MothersName,
                MothersProfession=employeeBasicInfo.MothersProfession,
                NationalIdno=employeeBasicInfo.NationalIdno,
                NationalityId=employeeBasicInfo.NationalityId,
                PassportNo=employeeBasicInfo.PassportNo,
                ReligionId=employeeBasicInfo.ReligionId,
                CreatedBy=employeeBasicInfo.CreatedBy,
                CreatedDate = Convert.ToDateTime(employeeBasicInfo.CreatedDate),
                UpdatedBy = employeeBasicInfo.UpdatedBy,
                UpdatedDate = Convert.ToDateTime(employeeBasicInfo.UpdatedDate),
                Status = (byte)employeeBasicInfo.Status
            };
            return employeeViewModel;
        }
    }
}