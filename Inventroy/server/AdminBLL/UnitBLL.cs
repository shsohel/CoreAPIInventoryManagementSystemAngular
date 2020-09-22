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

namespace AdminBLL
{
 public   class UnitBLL
    {
        private readonly IRepository<Unit> repository;
        private readonly UserManager<User> userManager;

        public UnitBLL(IRepository<Unit> repository, UserManager<User> userManager)
        {
            this.repository = repository;
            this.userManager = userManager;
        }
        public async Task<IEnumerable<UnitViewModel>> GetUnits()
        {
            try
            {
                IEnumerable<Unit> units = await repository.GetAsync();
                List<UnitViewModel> unitViewModels = new List<UnitViewModel>();
                if (units != null)
                {
                    foreach (Unit unit in units)
                    {
                        unitViewModels.Add(assignDataToUnitViewModel(unit));
                    }
                    return unitViewModels;
                }
            }
            catch (Exception e)
            {

            }
            return null;
        }
        public async Task<UnitViewModel> GetUnit(int id)
        {
            try
            {
                Unit unit = await repository.GetAsync(id);
                if (unit != null)
                {
                    return assignDataToUnitViewModel(unit);
                }
            }
            catch (Exception e)
            {
                e.Message.Contains("Something Wrong");
            }
            return null;
        }
        public async Task<UnitViewModel> AddUnit(UnitViewModel model, ApplicationUser token)
        {
            try
            {
                Unit unit = new Unit
                {
                    IsInteger = model.IsInteger,
                    UnitNo= DateTime.Now.ToString("ddMMyyhhmmssmmm"),
                    Name = model.Name,
                    Description = model.Description,
                    OrganizationId=token.OrganizationId,
                    ShopId=token.ShopId,
                    CreatedBy = token.Id,
                    CreatedDate = DateTime.Now,
                    Status = (byte)Status.Active
                };
                Unit result = await repository.AddAsync(unit);
                model.Id = result.Id;
                if (result != null)
                {
                    return assignDataToUnitViewModel(result);
                }
            }
            catch (Exception e)
            {

            }
            return null;
        }
        public async Task<UnitViewModel> UpdateUnit(UnitViewModel model, ApplicationUser token)
        {
            try
            {
                Unit unit = await repository.GetAsync(model.Id);
                if (unit != null)
                {
                    unit.Name = model.Name;
                   // unit.UnitNo = model.UnitNo;
                    unit.IsInteger = model.IsInteger;
                    unit.Description = model.Description;
                    unit.ModifiedBy = token.Id;
                    unit.ModifiedDate = DateTime.Now;
                    Unit result = await repository.UpdateAsync(unit);
                    if (result != null)
                    {
                        return assignDataToUnitViewModel(result);
                    }
                }
            }
            catch (Exception e)
            {

            }
            return null;
        }
        public async Task<UnitViewModel> DeleteUnit(int id)
        {
            try
            {
                Unit unit = await repository.GetAsync(id);
                if (unit != null)
                {
                    Unit result = await repository.DeleteAsync(unit);
                    if (result != null)
                    {
                        return assignDataToUnitViewModel(result);
                    }
                }
            }
            catch (Exception e)
            {

            }
            return null;
        }
        public async Task<UnitViewModel> GetDetails(int id)
        {
            try
            {
                Unit unit = await repository.GetAsync(id);
                if (unit != null)
                {
                    UnitDetailsViewModel unitDetailsViewModel = new UnitDetailsViewModel
                    {
                        Id = unit.Id,
                        Name = unit.Name,
                        UnitNo=unit.UnitNo,
                        Description = unit.Description,
                        IsInteger = unit.IsInteger,
                        CreatedByName = unit.CreatedBy != null ? userManager.FindByIdAsync(unit.CreatedBy).Result.UserName : null,
                        CreatedDateString = unit.CreatedDate != null ? Formater.FormatDateddMMyyyy((DateTime)unit.CreatedDate) : null,
                        ModifiedByName = unit.ModifiedBy != null ? userManager.FindByIdAsync(unit.ModifiedBy).Result.UserName : null,
                        ModifiedDateString = unit.ModifiedDate != null ? Formater.FormatDateddMMyyyy((DateTime)unit.ModifiedDate) : null,
                        Status = unit.Status
                    };
                    return unitDetailsViewModel;
                }
            }
            catch (Exception e)
            {

            }
            return null;
        }
        public async Task<List<UnitViewModel>> GetTableData()
        {
            try
            {
                IEnumerable<Unit> units = await repository.GetAsync();
                List<UnitViewModel> unitViewModels = new List<UnitViewModel>();
                foreach (Unit unit in units)
                {
                    UnitViewModel unitViewModel = new UnitViewModel
                    {
                        Id = unit.Id,
                        Name = unit.Name,
                        UnitNo=unit.UnitNo,
                        Status = unit.Status
                    };
                    unitViewModels.Add(unitViewModel);
                }
                if (unitViewModels != null)
                {
                    return unitViewModels;
                }
            }
            catch (Exception e)
            {

            }
            return null;
        }
        public UnitViewModel assignDataToUnitViewModel(Unit unit)
        {
            UnitViewModel unitViewModel = new UnitViewModel
            {
                Id = unit.Id,
                IsInteger = unit.IsInteger,
                Name =unit.Name,
                UnitNo=unit.UnitNo,
                Description = unit.Description,
                CreatedBy = unit.CreatedBy,
                CreatedDate = Convert.ToDateTime(unit.CreatedDate),
                ModifiedBy = unit.ModifiedBy,
                ModifiedDate = Convert.ToDateTime(unit.ModifiedDate),
                Status = unit.Status
            };
            return unitViewModel;
        }
    }
}