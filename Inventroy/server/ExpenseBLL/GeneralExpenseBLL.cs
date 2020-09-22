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
    public class GeneralExpenseBLL
    {
        private readonly IRepository<GeneralExpense> repository;
        private readonly UserManager<User> userManger;

        public GeneralExpenseBLL(IRepository<GeneralExpense> repository, UserManager<User> userManger)
        {
            this.repository = repository;
            this.userManger = userManger;
        }
        public async Task<IEnumerable<GeneralExpenseViewModel>> GetGeneralExpenses()
        {
            try
            {
                IEnumerable<GeneralExpense> generalExpenses = await repository.GetAsync();
                List<GeneralExpenseViewModel> generalExpenseViewModels = new List<GeneralExpenseViewModel>();
                if (generalExpenses != null)
                {
                    foreach (GeneralExpense generalExpense in generalExpenses)
                    {
                        generalExpenseViewModels.Add(assignDataToGeneralExpenseViewModel(generalExpense));
                    }
                    return generalExpenseViewModels;
                }
            }
            catch (Exception e)
            {

            }
            return null;
        }
        public async Task<GeneralExpenseViewModel> GetGeneralExpense(long id)
        {
            try
            {
                GeneralExpense generalExpense = await repository.GetAsync(id);
                if (generalExpense != null)
                {
                    return assignDataToGeneralExpenseViewModel(generalExpense);
                }
            }
            catch (Exception e)
            {

            }
            return null;
        }
        public async Task<GeneralExpenseViewModel> AddGeneralExpense(GeneralExpenseViewModel model, ApplicationUser token)
        {
            try
            {
                GeneralExpense generalExpense = new GeneralExpense
                {
                    OrganizationId = token.OrganizationId,
                    ShopId = token.ShopId,                 
                    GeneralExpenseNo = DateTime.Now.ToString("ddMMyyhhmmssmmm"),
                    GeneralExpenseDate = model.GeneralExpenseDate,
                    Amount = model.Amount,
                    Note = model.Note,
                    VoucherId = model.VoucherId,
                    ExpenseHeadId = model.ExpenseHeadId,
                    CapturedBy = token.Id,
                    CapturedDate = DateTime.Now,
                    Status = (byte)Status.InActive
                };
                GeneralExpense result = await repository.AddAsync(generalExpense);
                model.Id = result.Id;
                if (result != null)
                {
                    return assignDataToGeneralExpenseViewModel(result);
                }
            }
            catch (Exception e)
            {

            }
            return null;
        }
        public async Task<GeneralExpenseViewModel> UpdateGeneralExpense(GeneralExpenseViewModel model, ApplicationUser toekn)
        {
            try
            {
                GeneralExpense generalExpense = await repository.GetAsync((long)model.Id);
                if (generalExpense != null)
                {
                    generalExpense.Amount = model.Amount;
                    generalExpense.Note = model.Note;
                    generalExpense.VoucherId = model.VoucherId;
                    generalExpense.GeneralExpenseDate = model.GeneralExpenseDate;
                    generalExpense.ExpenseHeadId = model.ExpenseHeadId;
                    generalExpense.UpdatedBy = toekn.Id;
                    generalExpense.UpdatedDate = DateTime.Now;
                    generalExpense.Status = (byte)Status.Active;

                    GeneralExpense result = await repository.UpdateAsync(generalExpense);
                    if (result != null)
                    {
                        return assignDataToGeneralExpenseViewModel(result);
                    }
                }
            }
            catch (Exception e)
            {

            }
            return null;
        }
        public async Task<GeneralExpenseViewModel> DeleteGeneralExpense(long id)
        {
            try
            {
                GeneralExpense generalExpense = await repository.GetAsync(id);
                if (generalExpense != null)
                {
                    GeneralExpense result = await repository.DeleteAsync(generalExpense);
                    if (result != null)
                    {
                        return assignDataToGeneralExpenseViewModel(result);
                    }
                }
            }
            catch (Exception e)
            {

            }
            return null;
        }
        public async Task<GeneralExpenseDetailsViewModel> GetDetails(long id)
        {
            try
            {
                GeneralExpense generalExpense = await repository.GetAsync(id);
                if (generalExpense != null)
                {
                    GeneralExpenseDetailsViewModel generalExpenseViewModel = new GeneralExpenseDetailsViewModel()
                    {
                        Id = generalExpense.Id,
                        GeneralExpenseNo = generalExpense.GeneralExpenseNo.ToString(),
                        Amount = generalExpense.Amount,
                        Note = generalExpense.Note,
                        VoucherId = generalExpense.VoucherId,                        
                        ExpenseDateString = generalExpense.GeneralExpenseDate != null ? Formater.FormatDateddMMyyyy((DateTime)generalExpense.GeneralExpenseDate) : null,
                        ExpenseHeadName = Enum.GetName(typeof(CommonBLL.Enums.ExpenseType), generalExpense.ExpenseHeadId),
                        CapturedByName = generalExpense.CapturedBy != null ? userManger.FindByIdAsync(generalExpense.CapturedBy).Result.UserName : null,
                        CapturedDateString = generalExpense.CapturedDate != null ? Formater.FormatDateddMMyyyy((DateTime)generalExpense.CapturedDate) : null,
                        UpdatedByName = generalExpense.UpdatedBy != null ? userManger.FindByIdAsync(generalExpense.UpdatedBy).Result.UserName : null,
                        UpdatedDateString = generalExpense.UpdatedDate != null ? Formater.FormatDateddMMyyyy((DateTime)generalExpense.UpdatedDate) : null,
                        Status = generalExpense.Status
                    };
                    return generalExpenseViewModel;
                }

            }
            catch (Exception e)
            {

            }
            return null;
        }
        public async Task<List<GeneralExpenseDetailsViewModel>> GetTableData()
        {
            try
            {
                IEnumerable<GeneralExpense> generalExpenses = await repository.GetAsync();
                List<GeneralExpenseDetailsViewModel> generalExpenseDetailsViewModels = new List<GeneralExpenseDetailsViewModel>();
                foreach (GeneralExpense generalExpense in generalExpenses)
                {
                    GeneralExpenseDetailsViewModel generalExpenseDetailsViewModel = new GeneralExpenseDetailsViewModel
                    {
                        Id = generalExpense.Id,
                        GeneralExpenseNo = generalExpense.GeneralExpenseNo,
                        Amount = generalExpense.Amount,
                        ExpenseDateString = generalExpense.GeneralExpenseDate != null ? Formater.FormatDateddMMyyyy((DateTime)generalExpense.GeneralExpenseDate) : null,
                        ExpenseHeadName = Enum.GetName(typeof(CommonBLL.Enums.ExpenseType), generalExpense.ExpenseHeadId),
                        VoucherId = generalExpense.VoucherId,
                        Status = generalExpense.Status,

                    };
                    generalExpenseDetailsViewModels.Add(generalExpenseDetailsViewModel);
                }
                if (generalExpenseDetailsViewModels != null)
                {
                    return generalExpenseDetailsViewModels;
                }
            }
            catch (Exception e)
            {

            }
            return null;
        }
        public GeneralExpenseViewModel assignDataToGeneralExpenseViewModel(GeneralExpense generalExpense)
        {
            GeneralExpenseViewModel generalExpenseViewModel = new GeneralExpenseViewModel
            {
                Id = generalExpense.Id,
                OrganizationId = generalExpense.OrganizationId,
                ShopId = generalExpense.ShopId,
                GeneralExpenseNo = generalExpense.GeneralExpenseNo,
                Amount = generalExpense.Amount,
                Note = generalExpense.Note,
                ExpenseHeadId = generalExpense.ExpenseHeadId,
                VoucherId = generalExpense.VoucherId,
                GeneralExpenseDate = generalExpense.GeneralExpenseDate,
                CapturedBy = generalExpense.CapturedBy,
                CapturedDate = generalExpense.CapturedDate,
                UpdatedBy = generalExpense.UpdatedBy,
                UpdatedDate = generalExpense.UpdatedDate,
                Status = generalExpense.Status,
            };
            return generalExpenseViewModel;
        }
    }
}
