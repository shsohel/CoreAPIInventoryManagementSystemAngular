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
    public class BankTransferBLL
    {
        private readonly IRepository<BankTransfer> repository;
        private readonly UserManager<User> userManger;

        public BankTransferBLL(IRepository<BankTransfer> repository, UserManager<User> userManger)
        {
            this.repository = repository;
            this.userManger = userManger;
        }
        public async Task<IEnumerable<BankTransferViewModel>> GetBankTransfers()
        {
            try
            {
                IEnumerable<BankTransfer> bankTransfers = await repository.GetAsync();
                List<BankTransferViewModel> bankTransferViewModels = new List<BankTransferViewModel>();
                if (bankTransfers != null)
                {
                    foreach (BankTransfer bankTransfer in bankTransfers)
                    {
                        bankTransferViewModels.Add(assignDataToBankTransferViewModel(bankTransfer));
                    }
                    return bankTransferViewModels;
                }
            }
            catch (Exception e)
            {

            }
            return null;
        }
        public async Task<BankTransferViewModel> GetBankTransfer(long id)
        {
            try
            {
                BankTransfer bankTransfer = await repository.GetAsync(id);
                if (bankTransfer != null)
                {
                    return assignDataToBankTransferViewModel(bankTransfer);
                }
            }
            catch (Exception e)
            {

            }
            return null;
        }
        public async Task<BankTransferViewModel> AddBankTransfer(BankTransferViewModel model, ApplicationUser token)
        {
            try
            {
                BankTransfer externalTransfer = new BankTransfer
                {
                    OrganizationId = token.OrganizationId,
                    ShopId = token.ShopId,
                    BankAccountId = model.BankAccountId,
                    ResponsiblePersonId = model.ResponsiblePersonId,
                    TransferPurpose = model.TransferPurpose,                    
                    Amount = model.Amount,
                    Note = model.Note,
                    BankTransferNo = DateTime.Now.ToString("ddMMyyhhmmssmmm"),
                    CapturedBy = token.Id,
                    CapturedDate = DateTime.Now,
                    Status = (byte)Status.InActive                 
                };
                BankTransfer result = await repository.AddAsync(externalTransfer);
                model.Id = result.Id;
                if (result != null)
                {
                    return assignDataToBankTransferViewModel(result);
                }
            }
            catch (Exception e)
            {

            }
            return null;
        }
        public async Task<BankTransferViewModel> UpdateBankTransfer(BankTransferViewModel model, ApplicationUser toekn)
        {
            try
            {
                BankTransfer bankTransfer = await repository.GetAsync((long)model.Id);
                if (bankTransfer != null)
                {
                    bankTransfer.Amount = model.Amount;
                    bankTransfer.Note = model.Note;
                    bankTransfer.BankAccountId = model.BankAccountId;
                    bankTransfer.ResponsiblePersonId = model.ResponsiblePersonId;
                    bankTransfer.TransferPurpose = model.TransferPurpose;
                    bankTransfer.ApprovedBy = toekn.Id;
                    bankTransfer.ApprovedDate = DateTime.Now;
                    bankTransfer.CanceledBy = toekn.Id;
                    bankTransfer.CanceledDate = DateTime.Now;
                    bankTransfer.RequestedBy = toekn.Id;
                    bankTransfer.RejectReason = model.RejectReason;
                    bankTransfer.UpdatedBy = toekn.Id;
                    bankTransfer.UpdatedDate = DateTime.Now;
                    bankTransfer.Status = (byte)Status.Active;

                    BankTransfer result = await repository.UpdateAsync(bankTransfer);
                    if (result != null)
                    {
                        return assignDataToBankTransferViewModel(result);
                    }
                }
            }
            catch (Exception e)
            {

            }
            return null;
        }
        public async Task<BankTransferViewModel> DeleteBankTransfer(long id)
        {
            try
            {
                BankTransfer bankTransfer = await repository.GetAsync(id);
                if (bankTransfer != null)
                {
                    BankTransfer result = await repository.DeleteAsync(bankTransfer);
                    if (result != null)
                    {
                        return assignDataToBankTransferViewModel(result);
                    }
                }
            }
            catch (Exception e)
            {

            }
            return null;
        }
        public async Task<BankTransferDetailsModel> GetDetails(long id)
        {
            try
            {
                BankTransfer bankTransfer = await repository.GetAsync(id);
                if (bankTransfer != null)
                {
                    BankTransferDetailsModel bankTransferDetailsModel = new BankTransferDetailsModel()
                    {
                        Id = bankTransfer.Id,
                        BankTransferNo = bankTransfer.BankTransferNo.ToString(),
                        Amount = bankTransfer.Amount,
                        Note = bankTransfer.Note,
                        BankAccountId = bankTransfer.BankAccountId,                       
                        //Withdraw = bankTransfer.Withdraw,
                        //Deposit = bankTransfer.Deposit,
                        TransferPurpose = bankTransfer.TransferPurpose,
                        ResponsiblePersonId = bankTransfer.ResponsiblePersonId,
                        //ResponsiblePersonName = bankTransfer.ResponsiblePersonId,
                        RequestedBy = bankTransfer.RequestedBy != null ? userManger.FindByIdAsync(bankTransfer.RequestedBy).Result.UserName : null,
                        CapturedByName = bankTransfer.CapturedBy != null ? userManger.FindByIdAsync(bankTransfer.CapturedBy).Result.UserName : null,
                        CaptureDateString = bankTransfer.CapturedDate != null ? Formater.FormatDateddMMyyyy((DateTime)bankTransfer.CapturedDate) : null,
                        UpdatedByName = bankTransfer.UpdatedBy != null ? userManger.FindByIdAsync(bankTransfer.UpdatedBy).Result.UserName : null,
                        UpdatedDateString = bankTransfer.UpdatedDate != null ? Formater.FormatDateddMMyyyy((DateTime)bankTransfer.UpdatedDate) : null,
                        ApprovedByName = bankTransfer.ApprovedBy != null ? userManger.FindByIdAsync(bankTransfer.ApprovedBy).Result.UserName : null,
                        ApproveDateString = bankTransfer.ApprovedDate != null ? Formater.FormatDateddMMyyyy((DateTime)bankTransfer.ApprovedDate) : null,
                        CanceledByName = bankTransfer.CanceledBy != null ?userManger.FindByIdAsync(bankTransfer.CanceledBy).Result.UserName : null,
                        CanceledDateString = bankTransfer.CanceledDate != null ? Formater.FormatDateddMMyyyy((DateTime)bankTransfer.CanceledDate) : null,
                        RejectReason = bankTransfer.RejectReason,
                        Status = bankTransfer.Status
                    };
                    return bankTransferDetailsModel;
                }

            }
            catch (Exception e)
            {

            }
            return null;
        }
        public async Task<List<BankTransferDetailsModel>> GetTableData()
        {
            try
            {
                IEnumerable<BankTransfer> bankTransfers = await repository.GetAsync();
                List<BankTransferDetailsModel> bankTransferDetailsModels = new List<BankTransferDetailsModel>();
                foreach (BankTransfer bankTransfer in bankTransfers)
                {
                    BankTransferDetailsModel bankTransferDetailsModel = new BankTransferDetailsModel
                    {
                        Id = bankTransfer.Id,
                        BankTransferNo = bankTransfer.BankTransferNo,
                        BankAccountId = bankTransfer.BankAccountId,
                        ResponsiblePersonId = bankTransfer.ResponsiblePersonId,
                        TransferPurpose = bankTransfer.TransferPurpose,
                        Amount = bankTransfer.Amount,
                        Note = bankTransfer.Note,
                        
                        CaptureDateString = bankTransfer.CapturedDate != null ? Formater.FormatDateddMMyyyy((DateTime)bankTransfer.CapturedDate) : null,
                        Status = bankTransfer.Status
                    };
                    bankTransferDetailsModels.Add(bankTransferDetailsModel);
                }
                if (bankTransferDetailsModels != null)
                {
                    return bankTransferDetailsModels;
                }
            }
            catch (Exception e)
            {

            }
            return null;
        }
        public BankTransferViewModel assignDataToBankTransferViewModel(BankTransfer bankTransfer)
        {
            BankTransferViewModel bankTransferViewModel = new BankTransferViewModel
            {
                Id = bankTransfer.Id,
                OrganizationId = bankTransfer.OrganizationId,
                ShopId = bankTransfer.ShopId,
                BankTransferNo = bankTransfer.BankTransferNo,
                Amount = bankTransfer.Amount,
                Note = bankTransfer.Note,
                BankAccountId = bankTransfer.BankAccountId,
                ResponsiblePersonId = bankTransfer.ResponsiblePersonId,
                TransferPurpose = bankTransfer.TransferPurpose,
                Deposit = bankTransfer.Deposit,
                Withdraw = bankTransfer.Withdraw,
                RequestedBy = bankTransfer.RequestedBy,
                RequestedDate = bankTransfer.RequestedDate,
                RejectedBy = bankTransfer.RejectedBy,
                RejectedDate = bankTransfer.RejectedDate,
                CapturedBy = bankTransfer.CapturedBy,
                CapturedDate = bankTransfer.CapturedDate,
                UpdatedBy = bankTransfer.UpdatedBy,
                UpdatedDate = bankTransfer.UpdatedDate,
                ApprovedBy = bankTransfer.ApprovedBy,
                ApprovedDate = bankTransfer.ApprovedDate,
                CanceledBy = bankTransfer.CanceledBy,
                CanceledDate = bankTransfer.CanceledDate,
                RejectReason = bankTransfer.RejectReason,
                Status = bankTransfer.Status,
            };
            return bankTransferViewModel;
        }
    }
}
