using CommonBLL.Enums;
using CommonBLL.Helper;
using CommonDAL.Models;
using CommonDAL.Repository;
using CommonDAL.ViewModels;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FinanceBLL
{
    public class BusinessRelativeBLL
    {
        private readonly IRepository<BusinessRelative> repository;
        private readonly UserManager<User> userManger;

        public BusinessRelativeBLL(IRepository<BusinessRelative> repository, UserManager<User> userManger)
        {
            this.repository = repository;
            this.userManger = userManger;
        }
        public async Task<IEnumerable<BusinessRelativeViewModel>> GetBusinessRelatives()
        {
            try
            {
                IEnumerable<BusinessRelative> businessRelatives = await repository.GetAsync();
                List<BusinessRelativeViewModel> businessRelativeViewModels = new List<BusinessRelativeViewModel>();
                if (businessRelatives != null)
                {
                    foreach (BusinessRelative businessRelative in businessRelatives)
                    {
                        businessRelativeViewModels.Add(assignDataToBusinessRelativeViewModel(businessRelative));
                    }
                    return businessRelativeViewModels;
                }
            }
            catch (Exception e)
            {

            }
            return null;
        }

        public async Task<BusinessRelativeViewModel> GetBusinessRelative(int id)
        {
            try
            {
                BusinessRelative businessRelative = await repository.GetAsync(id);
                if (businessRelative != null)
                {
                    return assignDataToBusinessRelativeViewModel(businessRelative);
                }
            }
            catch (Exception e)
            {

            }
            return null;
        }
        public async Task<BusinessRelativeViewModel> AddBusinessRelative(BusinessRelativeViewModel model, ApplicationUser token)
        {
            try
            {
                BusinessRelative businessRelative = new BusinessRelative
                {
                    OrganizationId = token.OrganizationId,
                    ShopId = token.ShopId,
                    BusinessRelativeNo = DateTime.Now.ToString("ddMMyyhhmmssmmm"),
                    Name = model.Name,
                    RelationshipId = model.RelationshipId,
                    MobileNo = model.MobileNo,
                    Email = model.Email,
                    Description = model.Description,
                    Address = model.Address,
                    CreatedBy = token.Id,
                    CreatedDate = DateTime.Now,
                    Status = (byte)Status.InActive
                };
                BusinessRelative result = await repository.AddAsync(businessRelative);
                model.Id = result.Id;
                if (result != null)
                {
                    return assignDataToBusinessRelativeViewModel(result);
                }
            }
            catch (Exception e)
            {

            }
            return null;
        }
        public async Task<BusinessRelativeViewModel> UpdateBusinessRelative(BusinessRelativeViewModel model, ApplicationUser toekn)
        {
            try
            {
                BusinessRelative businessRelative = await repository.GetAsync((int)model.Id);
                if (businessRelative != null)
                {
                    businessRelative.Name = model.Name;
                    businessRelative.RelationshipId = model.RelationshipId;
                    businessRelative.MobileNo = model.MobileNo;
                    businessRelative.Email = model.Email;
                    businessRelative.Address = model.Address;
                    businessRelative.Description = model.Description;
                    businessRelative.UpdatedBy = toekn.Id;
                    businessRelative.UpdatedDate = DateTime.Now;
                    businessRelative.Status = (byte)Status.Active;

                    BusinessRelative result = await repository.UpdateAsync(businessRelative);
                    if (result != null)
                    {
                        return assignDataToBusinessRelativeViewModel(result);
                    }
                }
            }
            catch (Exception e)
            {

            }
            return null;
        }
        public async Task<BusinessRelativeViewModel> DeleteBusinessRelative(int id)
        {
            try
            {
                BusinessRelative businessRelative = await repository.GetAsync(id);
                if (businessRelative != null)
                {
                    BusinessRelative result = await repository.DeleteAsync(businessRelative);
                    if (result != null)
                    {
                        return assignDataToBusinessRelativeViewModel(result);
                    }
                }
            }
            catch (Exception e)
            {

            }
            return null;
        }
        public async Task<BusinessRelativeDetailsViewModel> GetDetails(int id)
        {
            try
            {
                BusinessRelative businessRelative = await repository.GetAsync(id);
                if (businessRelative != null)
                {
                    BusinessRelativeDetailsViewModel businessRelativeViewModel = new BusinessRelativeDetailsViewModel()
                    {
                        Id = businessRelative.Id,
                        BusinessRelativeNo = businessRelative.BusinessRelativeNo,
                        Name = businessRelative.Name,
                        RelationshipName = Enum.GetName(typeof(CommonBLL.Enums.Relationship), businessRelative.RelationshipId),
                        MobileNo = businessRelative.MobileNo,
                        Email = businessRelative.Email,
                        Description = businessRelative.Description,
                        Address = businessRelative.Address,
                        UpdatedByName = businessRelative.UpdatedBy != null ? userManger.FindByIdAsync(businessRelative.UpdatedBy).Result.UserName : null,
                        CreatedByName = businessRelative.CreatedBy != null ? userManger.FindByIdAsync(businessRelative.CreatedBy).Result.UserName : null,
                        UpdatedDateString = businessRelative.UpdatedDate != null ? Formater.FormatDateddMMyyyy((DateTime)businessRelative.UpdatedDate) : null,
                        CreatedDateString = businessRelative.CreatedDate != null ? Formater.FormatDateddMMyyyy((DateTime)businessRelative.CreatedDate) : null,
                        Status = businessRelative.Status
                    };
                    return businessRelativeViewModel;
                }

            }
            catch (Exception e)
            {

            }
            return null;
        }
        public async Task<List<BusinessRelativeDetailsViewModel>> GetTableData()
        {
            try
            {
                IEnumerable<BusinessRelative> businessRelatives = await repository.GetAsync();
                List<BusinessRelativeDetailsViewModel> businessRelativeDetailsViewModels = new List<BusinessRelativeDetailsViewModel>();
                foreach (BusinessRelative businessRelative in businessRelatives)
                {
                    BusinessRelativeDetailsViewModel businessRelativeDetailsViewModel = new BusinessRelativeDetailsViewModel
                    {
                        Id = businessRelative.Id,
                        BusinessRelativeNo = businessRelative.BusinessRelativeNo,
                        Name = businessRelative.Name,
                        RelationshipId = businessRelative.RelationshipId,
                        MobileNo = businessRelative.MobileNo,
                        Address = businessRelative.Address,
                        Status = businessRelative.Status
                    };
                    businessRelativeDetailsViewModels.Add(businessRelativeDetailsViewModel);
                }
                if (businessRelativeDetailsViewModels != null)
                {
                    return businessRelativeDetailsViewModels;
                }
            }
            catch (Exception e)
            {

            }
            return null;
        }
        public BusinessRelativeViewModel assignDataToBusinessRelativeViewModel(BusinessRelative businessRelative)
        {
            BusinessRelativeViewModel businessRelativeViewModel = new BusinessRelativeViewModel
            {
                Id = businessRelative.Id,
                OrganizationId = businessRelative.OrganizationId,
                ShopId = businessRelative.ShopId,
                BusinessRelativeNo = businessRelative.BusinessRelativeNo,
                Name = businessRelative.Name,
                RelationshipId = businessRelative.RelationshipId,
                MobileNo = businessRelative.MobileNo,
                Email = businessRelative.Email,
                Address = businessRelative.Address,
                Description = businessRelative.Description,
                CreatedBy = businessRelative.CreatedBy,
                CreatedDate = businessRelative.CreatedDate,
                UpdatedBy = businessRelative.UpdatedBy,
                UpdatedDate = businessRelative.UpdatedDate,
                Status = businessRelative.Status,
            };
            return businessRelativeViewModel;
        }
    }
}
