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
   public class SpecificationAttrValueBLL
    {
        private readonly IRepository<SpecificationAttribute> attriRepository;
        private readonly IRepository<SpecificationAttrValue> attrValueRepository;
        private readonly UserManager<User> userManager;
        public SpecificationAttrValueBLL(IRepository<SpecificationAttribute> attriRepository, IRepository<SpecificationAttrValue> attrValueRepository,
            UserManager<User> userManager)
        {
            this.attriRepository = attriRepository;
            this.attrValueRepository = attrValueRepository;
            this.userManager = userManager;
        }
        public async Task<IEnumerable<SpecificationAttrValueViewModel>> GetAttrValues()
        {
            try
            {
                IEnumerable<SpecificationAttrValue> specificationAttrValues = await attrValueRepository.GetAsync();
                List<SpecificationAttrValueViewModel> specificationAttrValueViewModels = new List<SpecificationAttrValueViewModel>();
                if (specificationAttrValues != null)
                {
                    foreach (SpecificationAttrValue specificationAttrValue in specificationAttrValues)
                    {
                        specificationAttrValueViewModels.Add(assignDataToSpeAttriViewModel(specificationAttrValue));
                    }
                    return specificationAttrValueViewModels;
                }
            }
            catch (Exception e)
            {

            }
            return null;
        }
        public async Task<List<SpecificationAttrValueViewModel>> GetAttriValuebyAttributeId(int id)
        {
            try
            {
                SpecificationAttribute  specificationAttr = await attriRepository.GetAsync(id);
                IEnumerable<SpecificationAttrValue> specificationAttrValues = await attrValueRepository.GetAsync();
                List<SpecificationAttrValue> filterAttrValue = specificationAttrValues.Where(x => x.SpecificationAttrId == specificationAttr.Id).ToList();
                if (filterAttrValue != null)
                {
                    List<SpecificationAttrValueViewModel> specificationAttrValueViewModels = new List<SpecificationAttrValueViewModel>();
                    foreach (SpecificationAttrValue specificationAttrValue in filterAttrValue)
                    {
                        specificationAttrValueViewModels.Add(assignDataToSpeAttriViewModel(specificationAttrValue));
                    }
                    return specificationAttrValueViewModels;
                }
            }
            catch (Exception e)
            {
                e.Message.Contains("Something Wrong");
            }
            return null;
        }
        public async Task<ExtraSpAttrValueViewModel> AddSpAttrValue(ExtraSpAttrValueViewModel models, ApplicationUser token)
        {
            try
            {
                List<SpecificationAttrValue> specificationAttrValues = new List<SpecificationAttrValue>();
                foreach (SpecificationAttrValueViewModel model in models.specificationAttrValueViewModels)
                {
                    SpecificationAttrValue specificationAttrValue = new SpecificationAttrValue
                    {
                        CreatedBy = token.Id,
                        AttributeValueNo = DateTime.Now.ToString("ddMMyyhhmmssmmm"),
                        AttrValue=model.AttrValue,
                        SpecificationAttrId=model.SpecificationAttrId,
                        CreatedDate = DateTime.Now,
                        Status = (byte)Status.Active
                    };
                    specificationAttrValues.Add(specificationAttrValue);
                }
                List<SpecificationAttrValue> result = await attrValueRepository.AddRangeAsync(specificationAttrValues);
                if (result.Count > 0)
                {
                    ExtraSpAttrValueViewModel extraSpAttrValueViewModels = new ExtraSpAttrValueViewModel();
                    foreach (SpecificationAttrValue specificationAttrValue in result)
                    {
                        var data = assignDataToSpeAttriViewModel(specificationAttrValue);
                        extraSpAttrValueViewModels.specificationAttrValueViewModels.Add(data);
                    }
                    return extraSpAttrValueViewModels;
                }
            }
            catch (Exception e)
            {

            }
            return null;
        }
        public async Task<ExtraSpAttrValueViewModel> UpdateSpAttrValue(ExtraSpAttrValueViewModel models, ApplicationUser token)
        {
            try
            {
                if (models != null)
                {
                    IEnumerable<SpecificationAttrValue> specificationAttrValues = await attrValueRepository.GetAsync();
                    List<SpecificationAttrValue> filterAttriValue = specificationAttrValues
                        .Where(x => x.SpecificationAttrId == models.specificationAttrValueViewModels[0].SpecificationAttrId).ToList();
                    List<SpecificationAttrValue> deletedAttriValue = new List<SpecificationAttrValue>();
                    if (filterAttriValue.Count > 0)
                    {
                        foreach (SpecificationAttrValue specificationAttrValue in filterAttriValue)
                        {
                            var resutl = models.specificationAttrValueViewModels.Where(x => x.Id == specificationAttrValue.Id).FirstOrDefault();
                            if (resutl == null)
                            {
                                deletedAttriValue.Add(specificationAttrValue);
                            }
                        }
                        if (deletedAttriValue.Count > 0)
                        {
                            List<SpecificationAttrValue> deletedResult = await attrValueRepository.DeleteRangeAsync(deletedAttriValue);
                        }
                    }
                    List<SpecificationAttrValue> updateAttriValues = new List<SpecificationAttrValue>();
                    List<SpecificationAttrValue> addAttrValues = new List<SpecificationAttrValue>();
                    foreach (SpecificationAttrValueViewModel model in models.specificationAttrValueViewModels)
                    {
                        if (model.Id > 0)
                        {
                            SpecificationAttrValue attributeValue = attrValueRepository.GetAsync(model.Id).Result;
                            if (attributeValue != null)
                            {
                                attributeValue.AttrValue = model.AttrValue;
                                attributeValue.SpecificationAttrId = model.SpecificationAttrId;
                                attributeValue.ModifiedDate = DateTime.Now;
                                attributeValue.ModifiedBy = token.Id;
                            }
                            updateAttriValues.Add(attributeValue);
                        }
                        else
                        {
                            SpecificationAttrValue attributeValue = new SpecificationAttrValue
                            {
                                CreatedBy = token.Id,
                                AttributeValueNo = DateTime.Now.ToString("ddMMyyhhmmssmmm"),
                                AttrValue = model.AttrValue,
                                SpecificationAttrId = model.SpecificationAttrId,
                                CreatedDate = DateTime.Now,
                                Status = (byte)Status.Active
                            };
                            addAttrValues.Add(attributeValue);
                        }
                    };
                    List<SpecificationAttrValue> updateResult = await attrValueRepository.UpdateRangeAsync(updateAttriValues);
                    if (addAttrValues.Count > 0)
                    {
                        List<SpecificationAttrValue> addResult = await attrValueRepository.AddRangeAsync(addAttrValues);
                    }
                    if (updateResult.Count > 0)
                    {
                        ExtraSpAttrValueViewModel extraSpAttrValues = new ExtraSpAttrValueViewModel();
                        foreach (SpecificationAttrValue specificationAttrValue in updateResult)
                        {
                            var data = assignDataToSpeAttriViewModel(specificationAttrValue);
                            extraSpAttrValues.specificationAttrValueViewModels.Add(data);
                        }
                        return extraSpAttrValues;
                    }
                };
            }
            catch (Exception e)
            {

            }
            return null;
        }
        public async Task<List<SpecificationAttrValueViewModel>> DeleteSpAttrValue(int id)
        {
            try
            {
                SpecificationAttribute specificationAttribute = await attriRepository.GetAsync(id);
                IEnumerable<SpecificationAttrValue> specificationAttrValues = await attrValueRepository.GetAsync();
                List<SpecificationAttrValue> filteredSpAttrValues = specificationAttrValues.Where(x => x.SpecificationAttrId == specificationAttribute.Id).ToList();
                if (filteredSpAttrValues.Count > 0)
                {
                    List<SpecificationAttrValue> result = await attrValueRepository.DeleteRangeAsync(filteredSpAttrValues);
                    List<SpecificationAttrValueViewModel> spAttrValues = new List<SpecificationAttrValueViewModel>();
                    if (result != null)
                    {
                        foreach (SpecificationAttrValue specificationAttrValue in result)
                        {
                            var data = assignDataToSpeAttriViewModel(specificationAttrValue);
                            spAttrValues.Add(data);
                        }
                        return spAttrValues;
                    }
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
        public SpecificationAttrValueViewModel assignDataToSpeAttriViewModel(SpecificationAttrValue specificationAttrValue)
        {
            SpecificationAttrValueViewModel specificationAttrValueViewModel = new SpecificationAttrValueViewModel
            {
                Id = specificationAttrValue.Id,
                CreatedBy = specificationAttrValue.CreatedBy,
                SpecificationAttrId = specificationAttrValue.SpecificationAttrId,
                AttributeValueNo= specificationAttrValue.AttributeValueNo,
                AttrValue= specificationAttrValue.AttrValue,
                CreatedDate = Convert.ToDateTime(specificationAttrValue.CreatedDate),
                ModifiedBy = specificationAttrValue.ModifiedBy,
                ModifiedDate = Convert.ToDateTime(specificationAttrValue.ModifiedDate),
                Status = (byte)specificationAttrValue.Status
            };
            return specificationAttrValueViewModel;
        }
    }
}