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
    public class ExpenseHeadBLL
    {
        private readonly IRepository<ExpenseHead> repository;
        private readonly UserManager<User> userManger;

        public ExpenseHeadBLL(IRepository<ExpenseHead> repository, UserManager<User> userManger)
        {
            this.repository = repository;
            this.userManger = userManger;
        }
        public async Task<IEnumerable<ExpenseHeadViewModel>> GetExpenseHeads()
        {
            try
            {
                IEnumerable<ExpenseHead> expenseHeads = await repository.GetAsync();
                List<ExpenseHeadViewModel> expenseHeadViewModels = new List<ExpenseHeadViewModel>();
                if (expenseHeads != null)
                {
                    foreach (ExpenseHead expenseHead in expenseHeads)
                    {
                        expenseHeadViewModels.Add(assignDataToExpenseHeadViewModel(expenseHead));
                    }
                    return expenseHeadViewModels;
                }
            }
            catch (Exception e)
            {

            }
            return null;
        }
        public async Task<ExpenseHeadViewModel> GetExpenseHead(int id)
        {
            try
            {
                ExpenseHead expenseHead = await repository.GetAsync(id);
                if (expenseHead != null)
                {
                    return assignDataToExpenseHeadViewModel(expenseHead);
                }
            }
            catch (Exception e)
            {

            }
            return null;
        }
        public async Task<ExpenseHeadViewModel> AddExpenseHead(ExpenseHeadViewModel model, ApplicationUser token)
        {
            try
            {
                ExpenseHead expenseHead = new ExpenseHead
                {
                    OrganizationId = token.OrganizationId,
                    ShopId = token.ShopId,
                    ExpenseHeadNo = DateTime.Now.ToString("ddMMyyhhmmssmmm"),
                    ExpenseTypeId = model.ExpenseTypeId,
                    ParentId = model.ParentId,
                    Name = model.Name,
                    Description = model.Description,
                    CreatedBy = token.Id,
                    CreatedDate = DateTime.Now,
                    Status = (byte)CommonBLL.Enums.Status.InActive
                };
                ExpenseHead result = await repository.AddAsync(expenseHead);
                model.Id = result.Id;
                if (result != null)
                {
                    return assignDataToExpenseHeadViewModel(result);
                }
            }
            catch (Exception e)
            {

            }
            return null;
        }
        public async Task<ExpenseHeadViewModel> UpdateExpenseHead(ExpenseHeadViewModel model, ApplicationUser toekn)
        {
            try
            {
                ExpenseHead expenseHead = await repository.GetAsync((int)model.Id);
                if (expenseHead != null)
                {
                    expenseHead.Name = model.Name;
                    expenseHead.ExpenseTypeId = model.ExpenseTypeId;
                    expenseHead.ParentId = model.ParentId;
                    expenseHead.Description = model.Description;
                    expenseHead.UpdatedBy = toekn.Id;
                    expenseHead.UpdatedDate = DateTime.Now;
                    expenseHead.Status = (byte)CommonBLL.Enums.Status.Active;

                    ExpenseHead result = await repository.UpdateAsync(expenseHead);
                    if (result != null)
                    {
                        return assignDataToExpenseHeadViewModel(result);
                    }
                }
            }
            catch (Exception e)
            {

            }
            return null;
        }
        public async Task<ExpenseHeadViewModel> DeleteExpenseHead(int id)
        {
            try
            {
                ExpenseHead expenseHead = await repository.GetAsync(id);
                if (expenseHead != null)
                {
                    ExpenseHead result = await repository.DeleteAsync(expenseHead);
                    if (result != null)
                    {
                        return assignDataToExpenseHeadViewModel(result);
                    }
                }
            }
            catch (Exception e)
            {

            }
            return null;
        }
        public async Task<ExpenseHeadDetailsViewModel> GetDetails(int id)
        {
            try
            {
                ExpenseHead expenseHead = await repository.GetAsync(id);
                if (expenseHead != null)
                {
                    ExpenseHeadDetailsViewModel expenseHeadDetailsViewModel = new ExpenseHeadDetailsViewModel()
                    {
                        Id = expenseHead.Id,
                        Name = expenseHead.Name,
                        ExpenseHeadNo = expenseHead.ExpenseHeadNo,
                        ExpenseTypeName = Enum.GetName(typeof(CommonBLL.Enums.ExpenseType), expenseHead.ExpenseTypeId),
                        ParentTypeName = Enum.GetName(typeof(CommonBLL.Enums.ExpenseType), expenseHead.ExpenseTypeId),
                        Description = expenseHead.Description,
                        UpdatedByName = expenseHead.UpdatedBy != null ? userManger.FindByIdAsync(expenseHead.UpdatedBy).Result.UserName : null,
                        CreatedByName = expenseHead.CreatedBy != null ? userManger.FindByIdAsync(expenseHead.CreatedBy).Result.UserName : null,
                        UpdatedDateString = expenseHead.UpdatedDate != null ? Formater.FormatDateddMMyyyy((DateTime)expenseHead.UpdatedDate) : null,
                        CreatedDateString = expenseHead.CreatedDate != null ? Formater.FormatDateddMMyyyy((DateTime)expenseHead.CreatedDate) : null,
                        Status = expenseHead.Status
                    };
                    return expenseHeadDetailsViewModel;
                }

            }
            catch (Exception e)
            {

            }
            return null;
        }
        public async Task<List<ExpenseHeadDetailsViewModel>> GetTableData()
        {
            try
            {
                IEnumerable<ExpenseHead> expenseHeads = await repository.GetAsync();
                List<ExpenseHeadDetailsViewModel> expenseHeadDetailsViewModels = new List<ExpenseHeadDetailsViewModel>();
                foreach (ExpenseHead expenseHead in expenseHeads)
                {
                    ExpenseHeadDetailsViewModel expenseHeadDetailsViewModel = new ExpenseHeadDetailsViewModel
                    {
                        Id = expenseHead.Id,
                        ExpenseHeadNo = expenseHead.ExpenseHeadNo,
                        Name = expenseHead.Name,
                        Description = expenseHead.Description,
                        ExpenseTypeName = Enum.GetName(typeof(CommonBLL.Enums.ExpenseType), expenseHead.ExpenseTypeId),
                        Status = expenseHead.Status
                    };
                    expenseHeadDetailsViewModels.Add(expenseHeadDetailsViewModel);
                }
                if (expenseHeadDetailsViewModels != null)
                {
                    return expenseHeadDetailsViewModels;
                }
            }
            catch (Exception e)
            {

            }
            return null;
        }
        public ExpenseHeadViewModel assignDataToExpenseHeadViewModel(ExpenseHead expenseHead)
        {
            ExpenseHeadViewModel expenseHeadViewModel = new ExpenseHeadViewModel
            {
                Id = expenseHead.Id,
                OrganizationId = expenseHead.OrganizationId,
                ExpenseHeadNo = expenseHead.ExpenseHeadNo,
                ExpenseTypeId = expenseHead.ExpenseTypeId,
                ParentId = expenseHead.ParentId,
                Name = expenseHead.Name,
                Description = expenseHead.Description,
                ShopId = expenseHead.ShopId,
                CreatedBy = expenseHead.CreatedBy,
                CreatedDate = expenseHead.CreatedDate,
                UpdatedBy = expenseHead.UpdatedBy,
                UpdatedDate = expenseHead.UpdatedDate,
                Status = expenseHead.Status,
            };
            return expenseHeadViewModel;
        }
    }
}
