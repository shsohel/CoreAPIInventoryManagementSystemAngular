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
    public class BankAccountBLL
    {
        private readonly IRepository<BankAccount> repository;
        private readonly UserManager<User> userManger;

        public BankAccountBLL(IRepository<BankAccount> repository, UserManager<User> userManger)
        {
            this.repository = repository;
            this.userManger = userManger;
        }
        public async Task<IEnumerable<BankAccountViewModel>> GetBankAccounts()
        {
            try
            {
                IEnumerable<BankAccount> bankAccounts = await repository.GetAsync();
                List<BankAccountViewModel> bankAccountViewModels = new List<BankAccountViewModel>();
                if (bankAccounts != null)
                {
                    foreach (BankAccount bankAccount in bankAccounts)
                    {
                        bankAccountViewModels.Add(assignDataToBankAccountViewModel(bankAccount));
                    }
                    return bankAccountViewModels;
                }
            }
            catch (Exception e)
            {

            }
            return null;
        }
        public async Task<BankAccountViewModel> GetBankAccount(long id)
        {
            try
            {
                BankAccount bankAccount = await repository.GetAsync(id);
                if (bankAccount != null)
                {
                    return assignDataToBankAccountViewModel(bankAccount);
                }
            }
            catch (Exception e)
            {

            }
            return null;
        }
        public async Task<BankAccountViewModel> AddBankAccount(BankAccountViewModel model, ApplicationUser token)
        {
            try
            {
                BankAccount bankAccount = new BankAccount
                {
                    OrganizationId = token.OrganizationId,
                    ShopId = token.ShopId,
                    BankAccountNo = DateTime.Now.ToString("ddMMyyhhmmssmmm"),
                    BankName = model.BankName,
                    BranchName = model.BranchName,
                    AccountNo = model.AccountNo,
                    AccountName = model.AccountName,
                    AccountType = model.AccountType,
                    TransectionType = model.TransectionType,
                    CapturedBy = token.Id,
                    CapturedDate = DateTime.Now,
                    Status = (byte)Status.InActive
                };
                BankAccount result = await repository.AddAsync(bankAccount);
                model.Id = result.Id;
                if (result != null)
                {
                    return assignDataToBankAccountViewModel(result);
                }
            }
            catch (Exception e)
            {

            }
            return null;
        }
        public async Task<BankAccountViewModel> UpdateBankAccount(BankAccountViewModel model, ApplicationUser toekn)
        {
            try
            {
                BankAccount bankAccount = await repository.GetAsync((long)model.Id);
                if (bankAccount != null)
                {
                    bankAccount.BankName = model.BankName;
                    bankAccount.BranchName = model.BranchName;
                    bankAccount.AccountNo = model.AccountNo;
                    bankAccount.AccountName = model.AccountName;
                    bankAccount.AccountType = model.AccountType;
                    bankAccount.TransectionType = model.TransectionType;
                    bankAccount.UpdatedBy = toekn.Id;
                    bankAccount.UpdatedDate = DateTime.Now;
                    bankAccount.Status = (byte)Status.Active;

                    BankAccount result = await repository.UpdateAsync(bankAccount);
                    if (result != null)
                    {
                        return assignDataToBankAccountViewModel(result);
                    }
                }
            }
            catch (Exception e)
            {

            }
            return null;
        }
        public async Task<BankAccountViewModel> DeleteBankAccount(long id)
        {
            try
            {
                BankAccount bankTransfer = await repository.GetAsync(id);
                if (bankTransfer != null)
                {
                    BankAccount result = await repository.DeleteAsync(bankTransfer);
                    if (result != null)
                    {
                        return assignDataToBankAccountViewModel(result);
                    }
                }
            }
            catch (Exception e)
            {

            }
            return null;
        }
        public async Task<BankAccountDetailsViewModel> GetDetails(long id)
        {
            try
            {
                BankAccount bankAccount = await repository.GetAsync(id);
                if (bankAccount != null)
                {
                    BankAccountDetailsViewModel bankAccountDetailsViewModel = new BankAccountDetailsViewModel()
                    {
                        Id = bankAccount.Id,
                        BankName = bankAccount.BankName,
                        BranchName = bankAccount.BranchName,
                        AccountNo = bankAccount.AccountNo,
                        AccountName = bankAccount.AccountName,
                        BankAccountNo = bankAccount.BankAccountNo,
                        AccountTypeName = Enum.GetName(typeof(CommonBLL.Enums.BankAccountType), bankAccount.AccountType),
                        TransectionTypeName = Enum.GetName(typeof(CommonBLL.Enums.AccountTransectionType), bankAccount.TransectionType),
                        UpdatedByName = bankAccount.UpdatedBy != null ? userManger.FindByIdAsync(bankAccount.UpdatedBy).Result.UserName : null,
                        CapturedByName = bankAccount.CapturedBy != null ? userManger.FindByIdAsync(bankAccount.CapturedBy).Result.UserName : null,
                        UpdatedDateString = bankAccount.UpdatedDate != null ? Formater.FormatDateddMMyyyy((DateTime)bankAccount.UpdatedDate) : null,
                        CaptureDateString = bankAccount.CapturedDate != null ? Formater.FormatDateddMMyyyy((DateTime)bankAccount.CapturedDate) : null,
                        Status = bankAccount.Status
                    };
                    return bankAccountDetailsViewModel;
                }

            }
            catch (Exception e)
            {

            }
            return null;
        }
        public async Task<List<BankAccountDetailsViewModel>> GetTableData()
        {
            try
            {
                IEnumerable<BankAccount> bankAccounts = await repository.GetAsync();
                List<BankAccountDetailsViewModel> bankAccountDetailsViewModels = new List<BankAccountDetailsViewModel>();
                foreach (BankAccount bankAccount in bankAccounts)
                {
                    BankAccountDetailsViewModel bankAccountDetailsViewModel = new BankAccountDetailsViewModel
                    {
                        Id = bankAccount.Id,
                        BankAccountNo = bankAccount.BankAccountNo,
                        BankName = bankAccount.BankName,
                        BranchName = bankAccount.BranchName,
                        AccountName = bankAccount.AccountName,
                        AccountNo = bankAccount.AccountNo,
                        Status = bankAccount.Status
                    };
                    bankAccountDetailsViewModels.Add(bankAccountDetailsViewModel);
                }
                if (bankAccountDetailsViewModels != null)
                {
                    return bankAccountDetailsViewModels;
                }
            }
            catch (Exception e)
            {

            }
            return null;
        }
        public BankAccountViewModel assignDataToBankAccountViewModel(BankAccount bankAccount)
        {
            BankAccountViewModel bankAccountViewModel = new BankAccountViewModel
            {
                Id = bankAccount.Id,
                OrganizationId = bankAccount.OrganizationId,
                ShopId = bankAccount.ShopId,
                BankAccountNo = bankAccount.BankAccountNo,
                BankName = bankAccount.BankName,
                BranchName = bankAccount.BranchName,
                AccountNo = bankAccount.AccountNo,
                AccountName = bankAccount.AccountName,
                AccountType = bankAccount.AccountType,
                TransectionType = bankAccount.TransectionType,
                CapturedBy = bankAccount.CapturedBy,
                CapturedDate = bankAccount.CapturedDate,
                UpdatedBy = bankAccount.UpdatedBy,
                UpdatedDate = bankAccount.UpdatedDate,
                Status = bankAccount.Status,
            };
            return bankAccountViewModel;
        }
    }
}
