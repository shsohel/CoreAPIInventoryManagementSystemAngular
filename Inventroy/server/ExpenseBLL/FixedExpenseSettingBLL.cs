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

namespace ExpenseBLL
{
    public class FixedExpenseSettingBLL
    {
        private readonly IRepository<FixedExpenseSetting> repository;
        private readonly UserManager<User> userManager;

        public FixedExpenseSettingBLL(IRepository<FixedExpenseSetting> repository, UserManager<User> userManager)
        {
            this.repository = repository;
            this.userManager = userManager;
        }
        public async Task<IEnumerable<FixedExpenseSettingViewModel>> GetFixedExpenseSettings()
        {
            try
            {
                IEnumerable<FixedExpenseSetting> fixedExpenseSettings = await repository.GetAsync();
                List<FixedExpenseSettingViewModel> fixedExpenseSettingViewModels = new List<FixedExpenseSettingViewModel>();
                if (fixedExpenseSettings != null)
                {
                    foreach (FixedExpenseSetting fixedExpenseSetting in fixedExpenseSettings)
                    {
                        fixedExpenseSettingViewModels.Add(assignDataToFixedExpenseSettingViewModel(fixedExpenseSetting));
                    }
                    return fixedExpenseSettingViewModels;
                }
            }
            catch (Exception e)
            {

            }
            return null;
        }
        public async Task<FixedExpenseSettingViewModel> GetFixedExpenseSetting(long id)
        {
            try
            {
                FixedExpenseSetting fixedExpenseSetting = await repository.GetAsync(id);
                if (fixedExpenseSetting != null)
                {
                    return assignDataToFixedExpenseSettingViewModel(fixedExpenseSetting);
                }
            }
            catch (Exception e)
            {

            }
            return null;
        }
        public async Task<FixedExpenseSettingViewModel> AddFixedExpenseSetting(FixedExpenseSettingViewModel model, ApplicationUser token)
        {
            try
            {
                FixedExpenseSetting fixedExpenseSetting = new FixedExpenseSetting
                {
                    OrganizationId = token.OrganizationId,
                    ShopId = token.ShopId,
                    FixedExpenseSettingNo = DateTime.Now.ToString("ddMMyyhhmmssmmm"),
                    Amount = model.Amount,
                    PayableType = model.PayableType,
                    ValidFrom = model.ValidFrom,
                    ValidTo = model.ValidTo,
                    ServiceProviderId = model.ServiceProviderId,
                    ExpenseHeadId = model.ExpenseHeadId,
                    Note = model.Note,
                    CreatedBy = token.Id,
                    CreatedDate = DateTime.Now,
                    Status = (byte)Status.InActive
                };
                FixedExpenseSetting result = await repository.AddAsync(fixedExpenseSetting);
                model.Id = result.Id;
                if (result != null)
                {
                    return assignDataToFixedExpenseSettingViewModel(result);
                }
            }
            catch (Exception e)
            {

            }
            return null;
        }
        public async Task<FixedExpenseSettingViewModel> UpdateFixedExpenseSetting(FixedExpenseSettingViewModel model, ApplicationUser token)
        {
            try
            {
                FixedExpenseSetting fixedExpenseSetting = await repository.GetAsync((long)model.Id);
                if (fixedExpenseSetting != null)
                {
                    fixedExpenseSetting.Amount = model.Amount;
                    fixedExpenseSetting.Note = model.Note;
                    fixedExpenseSetting.ExpenseHeadId = model.ExpenseHeadId;
                    fixedExpenseSetting.ServiceProviderId = model.ServiceProviderId;
                    fixedExpenseSetting.PayableType = model.PayableType;
                    fixedExpenseSetting.ValidFrom = model.ValidFrom;
                    fixedExpenseSetting.ValidTo = model.ValidTo;
                    fixedExpenseSetting.UpdatedBy = token.Id;
                    fixedExpenseSetting.UpdatedDate = DateTime.Now;
                    fixedExpenseSetting.Status = (byte)Status.Active;

                    FixedExpenseSetting result = await repository.UpdateAsync(fixedExpenseSetting);
                    if (result != null)
                    {
                        return assignDataToFixedExpenseSettingViewModel(result);
                    }
                }
            }
            catch (Exception e)
            {

            }
            return null;
        }
        public async Task<FixedExpenseSettingViewModel> DeleteFixedExpenseSetting(long id)
        {
            try
            {
                FixedExpenseSetting fixedExpenseSetting = await repository.GetAsync(id);
                if (fixedExpenseSetting != null)
                {
                    FixedExpenseSetting result = await repository.DeleteAsync(fixedExpenseSetting);
                    if (result != null)
                    {
                        return assignDataToFixedExpenseSettingViewModel(result);
                    }
                }
            }
            catch (Exception e)
            {

            }
            return null;
        }
        public async Task<FixedExpenseSettingDetailsViewModel> GetDetails(long id)
        {
            try
            {
                FixedExpenseSetting fixedExpenseSetting = await repository.GetAsync(id);
                if (fixedExpenseSetting != null)
                {
                    FixedExpenseSettingDetailsViewModel fixedExpenseDetailsViewModel = new FixedExpenseSettingDetailsViewModel()
                    {
                        Id = fixedExpenseSetting.Id,
                        FixedExpenseSettingNo = fixedExpenseSetting.FixedExpenseSettingNo,
                        Amount = fixedExpenseSetting.Amount,
                        PaybleTypeName = Enum.GetName(typeof(CommonBLL.Enums.PaybleType), fixedExpenseSetting.PayableType),
                        ValidFromString = fixedExpenseSetting.ValidFrom != null ? Formater.FormatDateddMMyyyy((DateTime)fixedExpenseSetting.ValidFrom) : null,
                        ValidToString = fixedExpenseSetting.ValidTo != null ? Formater.FormatDateddMMyyyy((DateTime)fixedExpenseSetting.ValidTo) : null,
                        Note = fixedExpenseSetting.Note,
                        ExpenseHeadName = Enum.GetName(typeof(CommonBLL.Enums.ExpenseType), fixedExpenseSetting.ExpenseHeadId),
                        ServiceProviderId = fixedExpenseSetting.ServiceProviderId,
                        CreatedByName = fixedExpenseSetting.CreatedBy != null ? userManager.FindByIdAsync(fixedExpenseSetting.CreatedBy).Result.UserName : null,
                        CreatedDateString = fixedExpenseSetting.CreatedDate != null ? Formater.FormatDateddMMyyyy((DateTime)fixedExpenseSetting.CreatedDate) : null,
                        UpdatedByName = fixedExpenseSetting.UpdatedBy != null ? userManager.FindByIdAsync(fixedExpenseSetting.UpdatedBy).Result.UserName : null,
                        UpdatedDateString = fixedExpenseSetting.UpdatedDate != null ? Formater.FormatDateddMMyyyy((DateTime)fixedExpenseSetting.UpdatedDate) : null,
                        Status = fixedExpenseSetting.Status
                    };
                    return fixedExpenseDetailsViewModel;
                }

            }
            catch (Exception e)
            {

            }
            return null;
        }
        public async Task<List<FixedExpenseSettingDetailsViewModel>> GetTableData()
        {
            try
            {
                IEnumerable<FixedExpenseSetting> fixedExpenseSettings = await repository.GetAsync();
                List<FixedExpenseSettingDetailsViewModel> fixedExpenseSettingDetailsViewModels = new List<FixedExpenseSettingDetailsViewModel>();
                foreach (FixedExpenseSetting fixedExpenseSetting in fixedExpenseSettings)
                {
                    FixedExpenseSettingDetailsViewModel fixedExpenseSettingDetailsViewModel = new FixedExpenseSettingDetailsViewModel
                    {
                        Id = fixedExpenseSetting.Id,
                        FixedExpenseSettingNo = fixedExpenseSetting.FixedExpenseSettingNo,
                        ExpenseHeadName = Enum.GetName(typeof(CommonBLL.Enums.ExpenseType), fixedExpenseSetting.ExpenseHeadId),
                        ValidFromString = fixedExpenseSetting.ValidFrom != null ? Formater.FormatDateddMMyyyy((DateTime)fixedExpenseSetting.ValidFrom) : null,
                        ValidToString = fixedExpenseSetting.ValidTo != null ? Formater.FormatDateddMMyyyy((DateTime)fixedExpenseSetting.ValidTo) : null,
                        Amount = fixedExpenseSetting.Amount,
                        Status = fixedExpenseSetting.Status
                    };
                    fixedExpenseSettingDetailsViewModels.Add(fixedExpenseSettingDetailsViewModel);
                }
                if (fixedExpenseSettingDetailsViewModels != null)
                {
                    return fixedExpenseSettingDetailsViewModels;
                }
            }
            catch (Exception e)
            {

            }
            return null;
        }
        public FixedExpenseSettingViewModel assignDataToFixedExpenseSettingViewModel(FixedExpenseSetting fixedExpenseSetting)
        {
            FixedExpenseSettingViewModel fixedExpenseSettingViewModel = new FixedExpenseSettingViewModel
            {
                Id = fixedExpenseSetting.Id,
                OrganizationId = fixedExpenseSetting.OrganizationId,
                ShopId = fixedExpenseSetting.ShopId,
                FixedExpenseSettingNo = fixedExpenseSetting.FixedExpenseSettingNo,
                Amount = fixedExpenseSetting.Amount,
                ValidTo = fixedExpenseSetting.ValidTo,
                ValidFrom = fixedExpenseSetting.ValidFrom,
                PayableType = fixedExpenseSetting.PayableType,
                Note = fixedExpenseSetting.Note,
                ExpenseHeadId = fixedExpenseSetting.ExpenseHeadId,
                ServiceProviderId = fixedExpenseSetting.ServiceProviderId,
                CreatedBy = fixedExpenseSetting.CreatedBy,
                CreatedDate = fixedExpenseSetting.CreatedDate,
                UpdatedBy = fixedExpenseSetting.UpdatedBy,
                UpdatedDate = fixedExpenseSetting.UpdatedDate,
                Status = fixedExpenseSetting.Status,
            };
            return fixedExpenseSettingViewModel;
        }

    }
}
