using CommonBLL.Enums;
using CommonBLL.Helper;
using CommonDAL.Models;
using CommonDAL.Repository;
using CommonDAL.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AdminBLL
{
    public class OrganizationTypeBLL
    {
        private readonly IRepository<OrganizationType> repository;
        public OrganizationTypeBLL(IRepository<OrganizationType> repository)
        {
            this.repository = repository;
        }
        public async Task<IEnumerable<OrganizationTypeViewModel>> GetOrganizationTypes()
        {
            try
            {
                IEnumerable<OrganizationType> organizationTypes = await repository.GetAsync();
                List<OrganizationTypeViewModel> organizationTypeViewModels = new List<OrganizationTypeViewModel>();
                if (organizationTypes != null)
                {
                    foreach (OrganizationType organizationType in organizationTypes)
                    {
                        organizationTypeViewModels.Add(assignDataToOrganizationViewModel(organizationType));
                    }
                    return organizationTypeViewModels;
                }
            }
            catch (Exception e)
            {

            }
            return null;
        }
        public async Task<OrganizationTypeViewModel> GetOrganizationType(int id)
        {
            try
            {
                OrganizationType organizationType = await repository.GetAsync(id);
                if (organizationType != null)
                {
                    return assignDataToOrganizationViewModel(organizationType);
                }
            }
            catch (Exception e)
            {
                e.Message.Contains("Something Wrong");
            }
            return null;
        }
        public async Task<OrganizationTypeViewModel> AddOrganizationType(OrganizationTypeViewModel model)
        {
            try
            {
                OrganizationType organizationType = new OrganizationType
                {
                    Name = model.Name,
                    TypeNo = model.TypeNo,
                    CapturedBy = 1,
                    CapturedDate = DateTime.Now,
                    Status = (byte)Status.Active
                };
                OrganizationType result = await repository.AddAsync(organizationType);
                model.Id = result.Id;
                if (result != null)
                {
                    return assignDataToOrganizationViewModel(result);
                }
            }
            catch (Exception e)
            {

            }
            return null;
        }
        public async Task<OrganizationTypeViewModel> UpdateOrganizationType(OrganizationTypeViewModel model)
        {
            try
            {
                OrganizationType organizationType = await repository.GetAsync(model.Id);
                if (organizationType != null)
                {
                    organizationType.Name = model.Name;
                    organizationType.TypeNo = model.TypeNo;
                    organizationType.UpdatedBy = 1;
                    organizationType.UpdatedDate = DateTime.Now;
                    OrganizationType result = await repository.UpdateAsync(organizationType);
                    if (result != null)
                    {
                        return assignDataToOrganizationViewModel(result);
                    }
                }
            }
            catch (Exception e)
            {

            }
            return null;
        }
        public async Task<OrganizationTypeViewModel> DeleteOrganizationType(int id)
        {
            try
            {
                OrganizationType organizationType = await repository.GetAsync(id);
                if (organizationType != null)
                {
                    OrganizationType result = await repository.DeleteAsync(organizationType);
                    if (result != null)
                    {
                        return assignDataToOrganizationViewModel(result);
                    }
                }
            }
            catch (Exception e)
            {

            }
            return null;
        }
        public async Task<OrganizationTypeViewModel> GetDetails(int id)
        {
            try
            {
                OrganizationType organizationType = await repository.GetAsync(id);
                if (organizationType != null)
                {
                    OrganizationTypeDetailsViewModel categoryViewModel = new OrganizationTypeDetailsViewModel
                    {
                        Id = organizationType.Id,
                        Name = organizationType.Name,
                        TypeNo = organizationType.TypeNo,
                        CapturedBy = organizationType.CapturedBy,
                        CreatedDateString = organizationType.CapturedDate != null ? Formater.FormatDateddMMyyyy((DateTime)organizationType.CapturedDate) : null,
                        UpdatedBy = organizationType.UpdatedBy,
                        ModifiedDateString = organizationType.UpdatedDate != null ? Formater.FormatDateddMMyyyy((DateTime)organizationType.UpdatedDate) : null,
                        Status = organizationType.Status
                    };
                    return categoryViewModel;
                }
            }
            catch (Exception e)
            {

            }
            return null;
        }
        public async Task<List<OrganizationTypeViewModel>> GetTableData()
        {
            try
            {
                IEnumerable<OrganizationType> organizationTypes = await repository.GetAsync();
                List<OrganizationTypeViewModel> organizationTypeViewModels = new List<OrganizationTypeViewModel>();
                foreach (OrganizationType type in organizationTypes)
                {
                    OrganizationTypeViewModel categoryViewModel = new OrganizationTypeViewModel
                    {
                        Id = type.Id,
                        Name = type.Name,
                        TypeNo = type.TypeNo,
                        Status = type.Status
                    };
                    organizationTypeViewModels.Add(categoryViewModel);
                }
                if (organizationTypeViewModels != null)
                {
                    return organizationTypeViewModels;
                }
            }
            catch (Exception e)
            {

            }
            return null;
        }
        public OrganizationTypeViewModel assignDataToOrganizationViewModel(OrganizationType type)
        {
            OrganizationTypeViewModel organizationTypeView = new OrganizationTypeViewModel
            {
                Id = type.Id,
                Name = type.Name,
                TypeNo = type.TypeNo,
                CapturedBy = type.CapturedBy,
                CapturedDate = Convert.ToDateTime(type.CapturedDate),
                UpdatedBy = type.UpdatedBy,
                UpdatedDate = Convert.ToDateTime(type.UpdatedDate),
                Status = type.Status
            };
            return organizationTypeView;
        }
    }
}