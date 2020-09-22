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
    public class FixedExpenseBLL
    {
        private readonly IRepository<FixedExpense> repository;
        private readonly UserManager<User> userManager;

        public FixedExpenseBLL(IRepository<FixedExpense> repository, UserManager<User> userManager)
        {
            this.repository = repository;
            this.userManager = userManager;
        }
        public async Task<IEnumerable<FixedExpenseViewModel>> GetFixedExpenses()
        {
            try
            {
                IEnumerable<FixedExpense> fixedExpenses = await repository.GetAsync();
                List<FixedExpenseViewModel> fixedExpenseViewModels = new List<FixedExpenseViewModel>();
                if (fixedExpenses != null)
                {
                    foreach (FixedExpense fixedExpense in fixedExpenses)
                    {
                        fixedExpenseViewModels.Add(assignDataToFixedExpenseViewModel(fixedExpense));
                    }
                    return fixedExpenseViewModels;
                }
            }
            catch (Exception e)
            {

            }
            return null;
        }
        public async Task<FixedExpenseViewModel> GetFixedExpense(long id)
        {
            try
            {
                FixedExpense fixedExpense = await repository.GetAsync(id);
                if (fixedExpense != null)
                {
                    return assignDataToFixedExpenseViewModel(fixedExpense);
                }
            }
            catch (Exception e)
            {

            }
            return null;
        }
        public async Task<FixedExpenseViewModel> AddFixedExpense(FixedExpenseViewModel model, ApplicationUser token)
        {
            try
            {
                FixedExpense fixedExpense = new FixedExpense
                {
                    OrganizationId = token.OrganizationId,
                    ShopId = token.ShopId,
                    FixedExpenseNo = DateTime.Now.ToString("ddMMyyhhmmssmmm"),
                    Amount = model.Amount,
                    VoucherId = model.VoucherId,
                    ServiceProviderId = model.ServiceProviderId,
                    FixedExpenseDate = DateTime.Now,
                    ExpenseHeadId = model.ExpenseHeadId,
                    Note = model.Note,                    
                    CapturedBy = token.Id,
                    CapturedDate = DateTime.Now,
                    Status = (byte)Status.InActive
                };
                FixedExpense result = await repository.AddAsync(fixedExpense);
                model.Id = result.Id;
                if (result != null)
                {
                    return assignDataToFixedExpenseViewModel(result);
                }
            }
            catch (Exception e)
            {

            }
            return null;
        }
        public async Task<FixedExpenseViewModel> UpdateFixedExpense(FixedExpenseViewModel model, ApplicationUser token)
        {
            try
            {
                FixedExpense fixedExpense = await repository.GetAsync((long)model.Id);
                if (fixedExpense != null)
                {
                    fixedExpense.Amount = model.Amount;
                    fixedExpense.Note = model.Note;
                    fixedExpense.VoucherId = model.VoucherId;
                    fixedExpense.ExpenseHeadId = model.ExpenseHeadId;
                    fixedExpense.ServiceProviderId = model.ServiceProviderId;
                    fixedExpense.UpdatedBy = token.Id;
                    fixedExpense.UpdatedDate = DateTime.Now;
                    fixedExpense.Status = (byte)Status.Active;

                    FixedExpense result = await repository.UpdateAsync(fixedExpense);
                    if (result != null)
                    {
                        return assignDataToFixedExpenseViewModel(result);
                    }
                }
            }
            catch (Exception e)
            {

            }
            return null;
        }
        public async Task<FixedExpenseViewModel> DeleteFixedExpense(long id)
        {
            try
            {
                FixedExpense fixedExpense = await repository.GetAsync(id);
                if (fixedExpense != null)
                {
                    FixedExpense result = await repository.DeleteAsync(fixedExpense);
                    if (result != null)
                    {
                        return assignDataToFixedExpenseViewModel(result);
                    }
                }
            }
            catch (Exception e)
            {

            }
            return null;
        }
        public async Task<FixedExpenseDetailsViewModel> GetDetails(long id)
        {
            try
            {
                FixedExpense fixedExpense = await repository.GetAsync(id);
                if (fixedExpense != null)
                {
                    FixedExpenseDetailsViewModel fixedExpenseDetailsViewModel = new FixedExpenseDetailsViewModel()
                    {
                        Id = fixedExpense.Id,
                        FixedExpenseNo = fixedExpense.FixedExpenseNo,
                        Amount = fixedExpense.Amount,
                        VoucherId = fixedExpense.VoucherId,
                        FixedExpenseDateString = fixedExpense.FixedExpenseDate != null ? Formater.FormatDateddMMyyyy((DateTime)fixedExpense.FixedExpenseDate) : null,
                        Note = fixedExpense.Note,
                        ExpenseHeadName = Enum.GetName(typeof(CommonBLL.Enums.ExpenseType), fixedExpense.ExpenseHeadId),
                        ServiceProviderId = fixedExpense.ServiceProviderId,
                        CreatedByName = fixedExpense.CapturedBy != null ? userManager.FindByIdAsync(fixedExpense.CapturedBy).Result.UserName : null,
                        CreatedDateString = fixedExpense.CapturedDate != null ? Formater.FormatDateddMMyyyy((DateTime)fixedExpense.CapturedDate) : null,
                        UpdatedByName = fixedExpense.UpdatedBy != null ? userManager.FindByIdAsync(fixedExpense.UpdatedBy).Result.UserName : null,
                        UpdatedDateString = fixedExpense.UpdatedDate != null ? Formater.FormatDateddMMyyyy((DateTime)fixedExpense.UpdatedDate) : null,
                        Status = fixedExpense.Status
                    };
                    return fixedExpenseDetailsViewModel;
                }

            }
            catch (Exception e)
            {

            }
            return null;
        }
        public async Task<List<FixedExpenseDetailsViewModel>> GetTableData()
        {
            try
            {
                IEnumerable<FixedExpense> fixedExpenses = await repository.GetAsync();
                List<FixedExpenseDetailsViewModel> fixedExpenseDetailsViewModels = new List<FixedExpenseDetailsViewModel>();
                foreach (FixedExpense fixedExpense in fixedExpenses)
                {
                    FixedExpenseDetailsViewModel fixedExpenseDetailsViewModel = new FixedExpenseDetailsViewModel
                    {
                        Id = fixedExpense.Id,
                        FixedExpenseNo = fixedExpense.FixedExpenseNo,
                        ExpenseHeadName = Enum.GetName(typeof(CommonBLL.Enums.ExpenseType), fixedExpense.ExpenseHeadId),
                        FixedExpenseDate = fixedExpense.FixedExpenseDate,
                        VoucherId = fixedExpense.VoucherId,
                        Amount = fixedExpense.Amount,
                        Status = fixedExpense.Status
                    };
                    fixedExpenseDetailsViewModels.Add(fixedExpenseDetailsViewModel);
                }
                if (fixedExpenseDetailsViewModels != null)
                {
                    return fixedExpenseDetailsViewModels;
                }
            }
            catch (Exception e)
            {

            }
            return null;
        }
        public FixedExpenseViewModel assignDataToFixedExpenseViewModel(FixedExpense fixedExpenses)
        {
            FixedExpenseViewModel fixedExpensesViewModel = new FixedExpenseViewModel
            {
                Id = fixedExpenses.Id,
                OrganizationId = fixedExpenses.OrganizationId,
                ShopId = fixedExpenses.ShopId,
                FixedExpenseNo = fixedExpenses.FixedExpenseNo,
                Amount = fixedExpenses.Amount,
                Note = fixedExpenses.Note,
                ExpenseHeadId = fixedExpenses.ExpenseHeadId,
                FixedExpenseDate = fixedExpenses.FixedExpenseDate,
                ServiceProviderId = fixedExpenses.ServiceProviderId,
                VoucherId = fixedExpenses.VoucherId,
                CapturedBy = fixedExpenses.CapturedBy,
                CapturedDate = fixedExpenses.CapturedDate,
                UpdatedBy = fixedExpenses.UpdatedBy,
                UpdatedDate = fixedExpenses.UpdatedDate,
                Status = fixedExpenses.Status,
            };
            return fixedExpensesViewModel;
        }
    }
}
