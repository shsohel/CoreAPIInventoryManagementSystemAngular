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
    public class ExpenseTypeBLL
    {
        private readonly IRepository<ExpenseType> repository;
        private readonly UserManager<User> userManger;

        public ExpenseTypeBLL(IRepository<ExpenseType> repository, UserManager<User> userManger)
        {
            this.repository = repository;
            this.userManger = userManger;
        }
        public async Task<IEnumerable<ExpenseTypeViewModel>> GetExpenseTypes()
        {
            try
            {
                IEnumerable<ExpenseType> expenseTypes = await repository.GetAsync();
                List<ExpenseTypeViewModel> expenseTypeViewModels = new List<ExpenseTypeViewModel>();
                if (expenseTypes != null)
                {
                    foreach (ExpenseType expenseType in expenseTypes)
                    {
                        expenseTypeViewModels.Add(assignDataToExpenseTypeViewModel(expenseType));
                    }
                    return expenseTypeViewModels;
                }
            }
            catch (Exception e)
            {

            }
            return null;
        }
        public async Task<ExpenseTypeViewModel> GetExpenseType(int id)
        {
            try
            {
                ExpenseType expenseType = await repository.GetAsync(id);
                if (expenseType != null)
                {
                    return assignDataToExpenseTypeViewModel(expenseType);
                }
            }
            catch (Exception e)
            {

            }
            return null;
        }
        public async Task<ExpenseTypeViewModel> AddExpenseType(ExpenseTypeViewModel model, ApplicationUser token)
        {
            try
            {
                ExpenseType expenseType = new ExpenseType
                {
                    OrganizationId = token.OrganizationId,
                    ShopId = token.ShopId,
                    ExpenseTypeNo = DateTime.Now.ToString("ddMMyyhhmmssmmm"),
                    Name = model.Name,
                    Description = model.Description,
                    IsFixed = model.IsFixed,
                    CreatedBy = token.Id,
                    CreatedDate = DateTime.Now,
                    Status = (byte)CommonBLL.Enums.Status.InActive
                };
                ExpenseType result = await repository.AddAsync(expenseType);
                model.Id = result.Id;
                if (result != null)
                {
                    return assignDataToExpenseTypeViewModel(result);
                }
            }
            catch (Exception e)
            {

            }
            return null;
        }
        public async Task<ExpenseTypeViewModel> UpdateExpenseType(ExpenseTypeViewModel model, ApplicationUser toekn)
        {
            try
            {
                ExpenseType expenseType = await repository.GetAsync((int)model.Id);
                if (expenseType != null)
                {
                    expenseType.Name = model.Name;
                    expenseType.Description = model.Description;
                    expenseType.IsFixed = model.IsFixed;
                    expenseType.ModifiedBy = toekn.Id;
                    expenseType.ModifiedDate = DateTime.Now;
                    expenseType.Status = (byte)CommonBLL.Enums.Status.Active;
                    ExpenseType result = await repository.UpdateAsync(expenseType);
                    if (result != null)
                    {
                        return assignDataToExpenseTypeViewModel(result);
                    }
                }
            }
            catch (Exception e)
            {

            }
            return null;
        }
        public async Task<ExpenseTypeViewModel> DeleteExpenseType(int id)
        {
            try
            {
                ExpenseType expenseType = await repository.GetAsync(id);
                if (expenseType != null)
                {
                    ExpenseType result = await repository.DeleteAsync(expenseType);
                    if (result != null)
                    {
                        return assignDataToExpenseTypeViewModel(result);
                    }
                }
            }
            catch (Exception e)
            {

            }
            return null;
        }
        public async Task<ExpenseTypeDetailsViewModel> GetDetails(int id)
        {
            try
            {
                ExpenseType expenseType = await repository.GetAsync(id);
                if (expenseType != null)
                {
                    ExpenseTypeDetailsViewModel expenseTypeDetailsViewModel = new ExpenseTypeDetailsViewModel()
                    {
                        Id = expenseType.Id,
                        Name = expenseType.Name,
                        ExpenseTypeNo = expenseType.ExpenseTypeNo,
                        IsFixed = expenseType.IsFixed,
                        Description = expenseType.Description,
                        ModifiedByName = expenseType.ModifiedBy != null ? userManger.FindByIdAsync(expenseType.ModifiedBy).Result.UserName : null,
                        CreatedByName = expenseType.CreatedBy != null ? userManger.FindByIdAsync(expenseType.CreatedBy).Result.UserName : null,
                        ModifiedDateString = expenseType.ModifiedDate != null ? Formater.FormatDateddMMyyyy((DateTime)expenseType.ModifiedDate) : null,
                        CreatedDateString = expenseType.CreatedDate != null ? Formater.FormatDateddMMyyyy((DateTime)expenseType.CreatedDate) : null,
                        Status = expenseType.Status
                    };
                    return expenseTypeDetailsViewModel;
                }

            }
            catch (Exception e)
            {

            }
            return null;
        }
        public async Task<List<ExpenseTypeDetailsViewModel>> GetTableData()
        {
            try
            {
                IEnumerable<ExpenseType> expenseTypes = await repository.GetAsync();
                List<ExpenseTypeDetailsViewModel> expenseTypeDetailsViewModels = new List<ExpenseTypeDetailsViewModel>();
                foreach (ExpenseType expenseType in expenseTypes)
                {
                    ExpenseTypeDetailsViewModel expenseTypeDetailsViewModel = new ExpenseTypeDetailsViewModel
                    {
                        Id = expenseType.Id,
                        ExpenseTypeNo = expenseType.ExpenseTypeNo,
                        Name = expenseType.Name,
                        Description = expenseType.Description,
                        IsFixed = expenseType.IsFixed,
                        Status = expenseType.Status
                    };
                    expenseTypeDetailsViewModels.Add(expenseTypeDetailsViewModel);
                }
                if (expenseTypeDetailsViewModels != null)
                {
                    return expenseTypeDetailsViewModels;
                }
            }
            catch (Exception e)
            {

            }
            return null;
        }
        public ExpenseTypeViewModel assignDataToExpenseTypeViewModel(ExpenseType expenseType)
        {
            ExpenseTypeViewModel expenseTypeViewModel = new ExpenseTypeViewModel
            {
                Id = expenseType.Id,
                OrganizationId = expenseType.OrganizationId,
                ExpenseTypeNo = expenseType.ExpenseTypeNo,
                Name = expenseType.Name,
                Description = expenseType.Description,
                IsFixed = expenseType.IsFixed,
                ShopId = expenseType.ShopId,
                CreatedBy = expenseType.CreatedBy,
                CreatedDate = expenseType.CreatedDate,
                ModifiedBy = expenseType.ModifiedBy,
                ModifiedDate = expenseType.ModifiedDate,
                Status = expenseType.Status,
            };
            return expenseTypeViewModel;
        }
    }
}
