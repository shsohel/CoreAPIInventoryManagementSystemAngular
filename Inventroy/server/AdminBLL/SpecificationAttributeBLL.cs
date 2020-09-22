using CommonBLL.Enums;
using CommonBLL.Helper;
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
  public  class SpecificationAttributeBLL
    {
        private readonly IRepository<SpecificationAttribute> attrRepository;
        private readonly IRepository<SpecificationAttrValue> attrValueRepository;
        private readonly UserManager<User> userManager;

        public SpecificationAttributeBLL(IRepository<SpecificationAttribute> attrRepository, IRepository<SpecificationAttrValue> attrValueRepository,
            UserManager<User> userManager)
        {
            this.attrRepository = attrRepository;
            this.attrValueRepository = attrValueRepository;
            this.userManager = userManager;
        }
        public async Task<IEnumerable<SpecificationAttributeViewModel>> GetSpAttributes()
        {
            try
            {
                IEnumerable<SpecificationAttribute> specificationAttributes = await attrRepository.GetAsync();
                List<SpecificationAttributeViewModel> specificationAttributeViewModels = new List<SpecificationAttributeViewModel>();
                if (specificationAttributes != null)
                {
                    foreach (SpecificationAttribute specificationAttribute in specificationAttributes)
                    {
                        specificationAttributeViewModels.Add(assignDataToSpAttributeViewModel(specificationAttribute));
                    }
                    return specificationAttributeViewModels;
                }
            }
            catch (Exception e)
            {

            }
            return null;
        }
        public async Task<SpecificationAttributeViewModel> GetSpecificationAttribute(int id)
        {
            try
            {
                SpecificationAttribute specificationAttribute = await attrRepository.GetAsync(id);
                if (specificationAttribute != null)
                {
                    return assignDataToSpAttributeViewModel(specificationAttribute);
                }
            }
            catch (Exception e)
            {
                e.Message.Contains("Something Wrong");
            }
            return null;
        }
        public async Task<SpecificationAttributeViewModel> AddSpecificationAttribute(SpecificationAttributeViewModel model, ApplicationUser token)
        {
            try
            {
                SpecificationAttribute specificationAttribute = new SpecificationAttribute
                {
                    AttributeNo = DateTime.Now.ToString("ddMMyyhhmmssmmm"),
                    Name = model.Name,
                    OrganizationId = token.OrganizationId,
                    ShopId = token.ShopId,
                    Sequence=model.Sequence,
                    CreatedBy = token.Id,
                    CreatedDate = DateTime.Now,
                    Status = (byte)Status.Active
                };
                SpecificationAttribute result = await attrRepository.AddAsync(specificationAttribute);
                model.Id = result.Id;
                if (result != null)
                {
                    return assignDataToSpAttributeViewModel(result);
                }
            }
            catch (Exception e)
            {

            }
            return null;
        }
        public async Task<SpecificationAttributeViewModel> UpdateSpecificationAttribute(SpecificationAttributeViewModel model, ApplicationUser token)
        {
            try
            {
                SpecificationAttribute specificationAttribute = await attrRepository.GetAsync(model.Id);
                if (specificationAttribute != null)
                {
                    specificationAttribute.Name = model.Name;
                    specificationAttribute.Sequence = model.Sequence;
                    specificationAttribute.ModifiedBy = token.Id;
                    specificationAttribute.ModifiedDate = DateTime.Now;
                    SpecificationAttribute result = await attrRepository.UpdateAsync(specificationAttribute);
                    if (result != null)
                    {
                        return assignDataToSpAttributeViewModel(result);
                    }
                }
            }
            catch (Exception e)
            {

            }
            return null;
        }
        public async Task<SpecificationAttributeViewModel> DeleteSpecificationAttribute(int id)
        {
            try
            {
                SpecificationAttribute specificationAttribute = await attrRepository.GetAsync(id);
                if (specificationAttribute != null)
                {
                    SpecificationAttribute result = await attrRepository.DeleteAsync(specificationAttribute);
                    if (result != null)
                    {
                        return assignDataToSpAttributeViewModel(result);
                    }
                }
            }
            catch (Exception e)
            {

            }
            return null;
        }
        public async Task<FullAttributeDetailsViewModel> GetDetails(int id)
        {
            try
            {
                SpecificationAttribute specificationAttribute = await attrRepository.GetAsync(id);
                if (specificationAttribute != null)
                {


                    SpecificationAttributeDetailsViewModel specificationAttributeDetailsView = new SpecificationAttributeDetailsViewModel
                    {
                        CreatedByName = specificationAttribute.CreatedBy != null ? userManager.FindByIdAsync(specificationAttribute.CreatedBy).Result.UserName : null,
                        CreatedDateString = specificationAttribute.CreatedDate != null ? Formater.FormatDateddMMyyyy((DateTime)specificationAttribute.CreatedDate) : null,
                        ModifiedByName = specificationAttribute.ModifiedBy != null ? userManager.FindByIdAsync(specificationAttribute.ModifiedBy).Result.UserName : null,
                        ModifiedDateString = specificationAttribute.ModifiedDate != null ? Formater.FormatDateddMMyyyy((DateTime)specificationAttribute.ModifiedDate) : null,
                        Name = specificationAttribute.Name,
                        Sequence= specificationAttribute.Sequence,
                        AttributeNo = specificationAttribute.AttributeNo,
                        OrganizationId = specificationAttribute.OrganizationId,
                        ShopId = specificationAttribute.ShopId,
                        Status = specificationAttribute.Status,
                    };

                    IEnumerable<SpecificationAttrValue> specificationAttrValues = await attrValueRepository.GetAsync();
                    List<SpecificationAttrValue> filterByAttr = specificationAttrValues.Where(x => x.SpecificationAttrId == specificationAttribute.Id).ToList();
                    List<SpecificationAttrValueViewModel> specificationAttrValueViews = new List<SpecificationAttrValueViewModel>();
                    foreach(var value in filterByAttr)
                    {
                        SpecificationAttrValueViewModel attrValueViewModel = new SpecificationAttrValueViewModel
                        {
                            AttrValue = value.AttrValue,
                            AttributeValueNo=value.AttributeValueNo
                        };
                        specificationAttrValueViews.Add(attrValueViewModel);
                    }

                    FullAttributeDetailsViewModel fullAttributeDetailsViewModels = new FullAttributeDetailsViewModel
                    {
                        specificationAttribute = specificationAttributeDetailsView,
                        specificationAttrValues = specificationAttrValueViews
                    };
                    return fullAttributeDetailsViewModels;

                }
            }
            catch (Exception e)
            {

            }
            return null;
        }
        public async Task<List<SpecificationAttributeViewModel>> GetTableData()
        {
            try
            {
                IEnumerable<SpecificationAttribute> specificationAttributes = await attrRepository.GetAsync();
                List<SpecificationAttributeViewModel> manufacturerViewModels = new List<SpecificationAttributeViewModel>();
                foreach (SpecificationAttribute specificationAttribute in specificationAttributes)
                {
                    SpecificationAttributeViewModel productDetailsViewModel = new SpecificationAttributeViewModel
                    {
                        Id = specificationAttribute.Id,
                        AttributeNo = specificationAttribute.AttributeNo,
                        OrganizationId = specificationAttribute.OrganizationId,
                        ShopId = specificationAttribute.ShopId,
                        Name = specificationAttribute.Name,                       
                        Sequence=specificationAttribute.Sequence,
                        Status = (byte)specificationAttribute.Status
                    };
                    manufacturerViewModels.Add(productDetailsViewModel);
                }
                if (manufacturerViewModels != null)
                {
                    return manufacturerViewModels;
                }
            }
            catch (Exception e)
            {

            }
            return null;
        }
        public SpecificationAttributeViewModel assignDataToSpAttributeViewModel(SpecificationAttribute specificationAttribute)
        {
            SpecificationAttributeViewModel manufacturerViewModel = new SpecificationAttributeViewModel
            {
                Id=specificationAttribute.Id,
                Name=specificationAttribute.Name,
                OrganizationId=specificationAttribute.OrganizationId,
                ShopId=specificationAttribute.ShopId,
                CreatedBy=specificationAttribute.CreatedBy,
                Sequence=specificationAttribute.Sequence,
                CreatedDate=specificationAttribute.CreatedDate,
                ModifiedBy=specificationAttribute.ModifiedBy,
                ModifiedDate=specificationAttribute.ModifiedDate,
                Status=(byte)specificationAttribute.Status
            };
            return manufacturerViewModel;
        }
    }
}