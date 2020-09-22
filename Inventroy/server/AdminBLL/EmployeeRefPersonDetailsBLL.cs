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
 public class EmployeeRefPersonDetailsBLL
    {
        private readonly IRepository<EmployeeRefPersonDetails> repository;
        private readonly IRepository<Employee> emRepository;
        private readonly UserManager<User> userManager;

        public EmployeeRefPersonDetailsBLL(IRepository<EmployeeRefPersonDetails> repository, IRepository<Employee> emRepository, UserManager<User> userManager)
        {
            this.repository = repository;
            this.emRepository = emRepository;
            this.userManager = userManager;
        }
        public async Task<IEnumerable<EmployeeRefPersonDetailsViewModel>> GetEmployeeRefPersons()
        {
            try
            {
                IEnumerable<EmployeeRefPersonDetails> employeeRefPersonDetails = await repository.GetAsync();
                List<EmployeeRefPersonDetailsViewModel> employeeRefPersonDetailsViewModels = new List<EmployeeRefPersonDetailsViewModel>();
                if (employeeRefPersonDetails != null)
                {
                    foreach (EmployeeRefPersonDetails employeeRefPerson in employeeRefPersonDetails)
                    {
                        employeeRefPersonDetailsViewModels.Add(assignDataToEmployeeRefPersonViewModel(employeeRefPerson));
                    }
                    return employeeRefPersonDetailsViewModels;
                }
            }
            catch (Exception e)
            {

            }
            return null;
        }
        public async Task<List<EmployeeRefPersonDetailsViewModel>> GetEmployeeRefPerson(long id)
        {
            try
            {
                Employee employee = await emRepository.GetAsync(id);
                IEnumerable<EmployeeRefPersonDetails> employeeRefPersonDetails = await repository.GetAsync();
                List<EmployeeRefPersonDetails> filterRefPersion = employeeRefPersonDetails.Where(x => x.EmployeeId == employee.Id).ToList();
                if (filterRefPersion != null)
                {
                    List<EmployeeRefPersonDetailsViewModel> personDetailsViewModels = new List<EmployeeRefPersonDetailsViewModel>();
                    foreach (EmployeeRefPersonDetails refPersonDetails in filterRefPersion)
                    {
                        personDetailsViewModels.Add(assignDataToEmployeeRefPersonViewModel(refPersonDetails));
                    }
                    return personDetailsViewModels;
                }
            }
            catch (Exception e)
            {
                e.Message.Contains("Something Wrong");
            }
            return null;
        }
        public async Task<EmpRefPersonCreateUpdateViewModel> AddEmployeeRefPerson(EmpRefPersonCreateUpdateViewModel models, ApplicationUser token)
        {
            try
            {
                List<EmployeeRefPersonDetails> employeeRefPersonDetails = new List<EmployeeRefPersonDetails>();
                foreach (EmployeeRefPersonDetailsViewModel model in models.EmpRefPersonCreateUpdateViewModels)
                {
                    EmployeeRefPersonDetails employeeRefPerson = new EmployeeRefPersonDetails
                    {
                        CountryId = model.CountryId,
                        CreatedBy =token.Id,
                        CreatedDate = DateTime.Now,
                        DistictId = model.DistictId,
                        Email = model.Email,
                        EmployeeId =(long) model.EmployeeId,
                        HouseVillage = model.HouseVillage,
                        MobileNo = model.MobileNo,
                        PoliceStationId = model.PoliceStationId,
                        PostCode = model.PostCode,
                        PostOffice = model.PostOffice,
                        ProfessionId = model.ProfessionId,
                        RefPersonName = model.RefPersonName,
                        ReletionShipId = model.ReletionShipId,
                        RoadBlockSector = model.RoadBlockSector,
                        Status = (byte)Status.Active,
                    };
                    employeeRefPersonDetails.Add(employeeRefPerson);
                }
                List<EmployeeRefPersonDetails> result = await repository.AddRangeAsync(employeeRefPersonDetails);
                //  models.ToArray() = result.Id;
                if (result.Count > 0)
                {
                    EmpRefPersonCreateUpdateViewModel employeeEduQualViewModels = new EmpRefPersonCreateUpdateViewModel();
                    foreach (EmployeeRefPersonDetails employeeEduQual in result)
                    {
                        var data = assignDataToEmployeeRefPersonViewModel(employeeEduQual);
                        employeeEduQualViewModels.EmpRefPersonCreateUpdateViewModels.Add(data);
                    }
                    return employeeEduQualViewModels;
                }
            }
            catch (Exception e)
            {

            }
            return null;
        }
        public async Task<EmpRefPersonCreateUpdateViewModel> UpdateEmployeeRefPerson(EmpRefPersonCreateUpdateViewModel models, ApplicationUser token)
        {
            try
            {
                if (models != null)
                {
                    IEnumerable<EmployeeRefPersonDetails> employeeRefPersonDetails = await repository.GetAsync();
                    List<EmployeeRefPersonDetails> filterRefPerson =
                    employeeRefPersonDetails.Where(x => x.EmployeeId == models.EmpRefPersonCreateUpdateViewModels[0].EmployeeId).ToList();
                    List<EmployeeRefPersonDetails> deletedEmployeePerson = new List<EmployeeRefPersonDetails>();

                    if (filterRefPerson != null)
                    {
                        foreach (EmployeeRefPersonDetails employeeRefPerson in filterRefPerson)
                        {
                            var resutl = models.EmpRefPersonCreateUpdateViewModels.Where(x => x.Id == employeeRefPerson.Id).FirstOrDefault();
                            if (resutl == null)
                            {
                                deletedEmployeePerson.Add(employeeRefPerson);
                            }
                        }
                        if (deletedEmployeePerson.Count > 0)
                        {
                            List<EmployeeRefPersonDetails> deletedResult = await repository.DeleteRangeAsync(deletedEmployeePerson);
                        }
                    }
                    List<EmployeeRefPersonDetails> updatePersonDetails = new List<EmployeeRefPersonDetails>();
                    List<EmployeeRefPersonDetails> addPersonDetails = new List<EmployeeRefPersonDetails>();
                    foreach (EmployeeRefPersonDetailsViewModel model in models.EmpRefPersonCreateUpdateViewModels)
                    {
                        if (model.Id > 0)
                        {
                            EmployeeRefPersonDetails employeeRefPerson = repository.GetAsync(model.Id).Result;
                            if (employeeRefPerson != null)
                            {
                                employeeRefPerson.CountryId = model.CountryId;
                                employeeRefPerson.DistictId = model.DistictId;
                                employeeRefPerson.Email = model.Email;
                                employeeRefPerson.EmployeeId = (long)model.EmployeeId;
                                employeeRefPerson.HouseVillage = model.HouseVillage;
                                employeeRefPerson.MobileNo = model.MobileNo;
                                employeeRefPerson.PoliceStationId = model.PoliceStationId;
                                employeeRefPerson.PostCode = model.PostCode;
                                employeeRefPerson.PostOffice = model.PostOffice;
                                employeeRefPerson.ProfessionId = model.ProfessionId;
                                employeeRefPerson.RefPersonName = model.RefPersonName;
                                employeeRefPerson.ReletionShipId = model.ReletionShipId;
                                employeeRefPerson.RoadBlockSector = model.RoadBlockSector;
                                employeeRefPerson.UpdatedBy = model.UpdatedBy;
                                employeeRefPerson.UpdatedDate = DateTime.Now;
                            }
                            updatePersonDetails.Add(employeeRefPerson);
                        }
                        else
                        {
                            EmployeeRefPersonDetails employeeRefPerson = new EmployeeRefPersonDetails
                            {
                                CountryId = model.CountryId,
                                DistictId = model.DistictId,
                                Email = model.Email,
                                EmployeeId = (long)model.EmployeeId,
                                HouseVillage = model.HouseVillage,
                                MobileNo = model.MobileNo,
                                PoliceStationId = model.PoliceStationId,
                                PostCode = model.PostCode,
                                PostOffice = model.PostOffice,
                                ProfessionId = model.ProfessionId,
                                RefPersonName = model.RefPersonName,
                                ReletionShipId = model.ReletionShipId,
                                RoadBlockSector = model.RoadBlockSector,
                                CreatedBy = token.Id,
                                Status = (byte)Status.Active,
                                CreatedDate = DateTime.Now
                            };
                            addPersonDetails.Add(employeeRefPerson);
                        }
                    };
                    List<EmployeeRefPersonDetails> updateResult = await repository.UpdateRangeAsync(updatePersonDetails);
                    if (addPersonDetails.Count > 0)
                    {
                        List<EmployeeRefPersonDetails> addResult = await repository.AddRangeAsync(addPersonDetails);
                    }
                    if (updateResult.Count > 0)
                    {
                        EmpRefPersonCreateUpdateViewModel employeeEduQualViewModels = new EmpRefPersonCreateUpdateViewModel();
                        foreach (EmployeeRefPersonDetails employeeEduQual in updateResult)
                        {
                            var data = assignDataToEmployeeRefPersonViewModel(employeeEduQual);
                            employeeEduQualViewModels.EmpRefPersonCreateUpdateViewModels.Add(data);
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
        public EmployeeRefPersonDetailsViewModel assignDataToEmployeeRefPersonViewModel(EmployeeRefPersonDetails employeeRef)
        {
            EmployeeRefPersonDetailsViewModel employeeRefPersonDetails = new EmployeeRefPersonDetailsViewModel
            {
                CountryId = employeeRef.CountryId,
                CreatedBy = employeeRef.CreatedBy,
                CreatedDate = Convert.ToDateTime(employeeRef.CreatedDate),
                DistictId = employeeRef.DistictId,
                Email = employeeRef.Email,
                EmployeeId = employeeRef.EmployeeId,
                HouseVillage = employeeRef.HouseVillage,
                Id = employeeRef.Id,
                MobileNo = employeeRef.MobileNo,
                PoliceStationId = employeeRef.PoliceStationId,
                PostCode = employeeRef.PostCode,
                PostOffice = employeeRef.PostOffice,
                ProfessionId = employeeRef.ProfessionId,
                RefPersonName = employeeRef.RefPersonName,
                ReletionShipId = employeeRef.ReletionShipId,
                RoadBlockSector = employeeRef.RoadBlockSector,
                UpdatedBy = employeeRef.UpdatedBy,
                Status = employeeRef.Status,
                UpdatedDate = Convert.ToDateTime(employeeRef.UpdatedDate),
            };
            return employeeRefPersonDetails;
        }
    }
}
