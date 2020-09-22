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
    public class ExternalPersonBLL
    {
        private readonly IRepository<ExternalPerson> repository;
        private readonly UserManager<User> userManger;

        public ExternalPersonBLL(IRepository<ExternalPerson> repository, UserManager<User> userManger)
        {
            this.repository = repository;
            this.userManger = userManger;
        }
        public async Task<IEnumerable<ExternalPersonViewModel>> GetExternalPersons()
        {
            try
            {
                IEnumerable<ExternalPerson> externalPersons = await repository.GetAsync();
                List<ExternalPersonViewModel> externalPersonViewModels = new List<ExternalPersonViewModel>();
                if (externalPersons != null)
                {
                    foreach (ExternalPerson externalPerson in externalPersons)
                    {
                        externalPersonViewModels.Add(assignDataToExternalPersonViewModel(externalPerson));
                    }
                    return externalPersonViewModels;
                }
            }
            catch (Exception e)
            {

            }
            return null;
        }
        public async Task<ExternalPersonViewModel> GetExternalPerson(long id)
        {
            try
            {
                ExternalPerson externalPerson = await repository.GetAsync(id);
                if (externalPerson != null)
                {
                    return assignDataToExternalPersonViewModel(externalPerson);
                }
            }
            catch (Exception e)
            {

            }
            return null;
        }
        public async Task<ExternalPersonViewModel> AddExternalPerson(ExternalPersonViewModel model, ApplicationUser token)
        {
            try
            {
                ExternalPerson externalPerson = new ExternalPerson
                {
                    OrganizationId = token.OrganizationId,
                    ShopId = token.ShopId,
                    ExternalPersonNo = DateTime.Now.ToString("ddMMyyhhmmssmmm"),
                    Name = model.Name,
                    FathersName = model.FathersName,
                    MobileNo = model.MobileNo,
                    Email = model.Email,
                    Address = model.Address,
                    RelationshipId = model.RelationshipId,
                    CapturedBy = token.Id,
                    CapturedDate = DateTime.Now,
                    Status = (byte)Status.InActive
                };
                ExternalPerson result = await repository.AddAsync(externalPerson);
                model.Id = result.id;
                if (result != null)
                {
                    return assignDataToExternalPersonViewModel(result);
                }
            }
            catch (Exception e)
            {

            }
            return null;
        }
        public async Task<ExternalPersonViewModel> UpdateExternalPerson(ExternalPersonViewModel model, ApplicationUser toekn)
        {
            try
            {
                ExternalPerson externalPerson = await repository.GetAsync((long)model.Id);
                if (externalPerson != null)
                {
                    externalPerson.Name = model.Name;
                    externalPerson.MobileNo = model.MobileNo;
                    externalPerson.FathersName = model.FathersName;
                    externalPerson.Email = model.Email;
                    externalPerson.Address = model.Address;
                    externalPerson.RelationshipId = model.RelationshipId;
                    externalPerson.UpdatedBy = toekn.Id;
                    externalPerson.UpdatedDate = DateTime.Now;
                    externalPerson.Status = (byte)Status.Active;

                    ExternalPerson result = await repository.UpdateAsync(externalPerson);
                    if (result != null)
                    {
                        return assignDataToExternalPersonViewModel(result);
                    }
                }
            }
            catch (Exception e)
            {

            }
            return null;
        }
        public async Task<ExternalPersonViewModel> DeleteExternalPerson(long id)
        {
            try
            {
                ExternalPerson externalPerson = await repository.GetAsync(id);
                if (externalPerson != null)
                {
                    ExternalPerson result = await repository.DeleteAsync(externalPerson);
                    if (result != null)
                    {
                        return assignDataToExternalPersonViewModel(result);
                    }
                }
            }
            catch (Exception e)
            {

            }
            return null;
        }
        public async Task<ExternalPersonDetailsViewModel> GetDetails(long id)
        {
            try
            {
                ExternalPerson externalPerson = await repository.GetAsync(id);
                if (externalPerson != null)
                {
                    ExternalPersonDetailsViewModel externalPersonViewModel = new ExternalPersonDetailsViewModel()
                    {
                        Id = externalPerson.id,
                        ExternalPersonNo = externalPerson.ExternalPersonNo,
                        Name = externalPerson.Name,
                        FathersName = externalPerson.FathersName,
                        MobileNo = externalPerson.MobileNo,
                        Email = externalPerson.Email,
                        RelationshipName = Enum.GetName(typeof(CommonBLL.Enums.Relationship), externalPerson.RelationshipId),
                        Address = externalPerson.Address,
                        UpdatedByName = externalPerson.UpdatedBy != null ? userManger.FindByIdAsync(externalPerson.UpdatedBy).Result.UserName : null,
                        CapturedByName = externalPerson.CapturedBy != null ? userManger.FindByIdAsync(externalPerson.CapturedBy).Result.UserName : null,
                        UpdatedDateString = externalPerson.UpdatedDate != null ? Formater.FormatDateddMMyyyy((DateTime)externalPerson.UpdatedDate) : null,
                        CapturedDateString = externalPerson.CapturedDate != null ? Formater.FormatDateddMMyyyy((DateTime)externalPerson.CapturedDate) : null,
                        Status = externalPerson.Status
                    };
                    return externalPersonViewModel;
                }

            }
            catch (Exception e)
            {

            }
            return null;
        }
        public async Task<List<ExternalPersonDetailsViewModel>> GetTableData()
        {
            try
            {
                IEnumerable<ExternalPerson> externalPersons = await repository.GetAsync();
                List<ExternalPersonDetailsViewModel> externalPersonDetailsViewModels = new List<ExternalPersonDetailsViewModel>();
                foreach (ExternalPerson externalPerson in externalPersons)
                {
                    ExternalPersonDetailsViewModel externalPersonDetailsViewModel = new ExternalPersonDetailsViewModel
                    {
                        Id = externalPerson.id,
                        ExternalPersonNo = externalPerson.ExternalPersonNo,
                        Name = externalPerson.Name,
                        FathersName = externalPerson.FathersName,
                        MobileNo = externalPerson.MobileNo,
                        Address = externalPerson.Address,
                        Status = externalPerson.Status
                    };
                    externalPersonDetailsViewModels.Add(externalPersonDetailsViewModel);
                }
                if (externalPersonDetailsViewModels != null)
                {
                    return externalPersonDetailsViewModels;
                }
            }
            catch (Exception e)
            {

            }
            return null;
        }
        public ExternalPersonViewModel assignDataToExternalPersonViewModel(ExternalPerson externalPerson)
        {
            ExternalPersonViewModel externalPersonViewModel = new ExternalPersonViewModel
            {
                Id = externalPerson.id,
                OrganizationId = externalPerson.OrganizationId,
                ShopId = externalPerson.ShopId,
                ExternalPersonNo = externalPerson.ExternalPersonNo,
                Name = externalPerson.Name,
                FathersName = externalPerson.FathersName,
                MobileNo = externalPerson.MobileNo,
                Email = externalPerson.Email,
                Address = externalPerson.Address,
                RelationshipId = externalPerson.RelationshipId,
                CapturedBy = externalPerson.CapturedBy,
                CapturedDate = externalPerson.CapturedDate,
                UpdatedBy = externalPerson.UpdatedBy,
                UpdatedDate = externalPerson.UpdatedDate,
                Status = externalPerson.Status,
            };
            return externalPersonViewModel;
        }
    }
}
