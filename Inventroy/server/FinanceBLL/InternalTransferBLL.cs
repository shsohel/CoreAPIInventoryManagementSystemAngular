using CommonBLL.Enums;
using CommonBLL.Helper;
using CommonDAL.Models;
using CommonDAL.Repository;
using CommonDAL.ViewModels;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace FinanceBLL
{
    public class InternalTransferBLL
    {
        private readonly IRepository<InternalTransfer> repository;
        private readonly UserManager<User> userManger;
        public InternalTransferBLL(IRepository<InternalTransfer> repository, UserManager<User> userManger)
        {
            this.repository = repository;
            this.userManger = userManger;
        }
        public async Task<IEnumerable<InternalTransferViewModel>> GetInternalTransfers()
        {
            try
            {
                IEnumerable<InternalTransfer> internalTransfers = await repository.GetAsync();
                List<InternalTransferViewModel> internalTransferViewModels = new List<InternalTransferViewModel>();
                if (internalTransfers != null)
                {
                    foreach (InternalTransfer internalTransfer in internalTransfers)
                    {
                        internalTransferViewModels.Add(assignDataToInternalTransferViewModel(internalTransfer));
                    }
                    return internalTransferViewModels;
                }
            }
            catch (Exception e)
            {

            }
            return null;
        }
        public async Task<InternalTransferViewModel> GetInternalTransfer(long id)
        {
            try
            {
                InternalTransfer internalTransfer = await repository.GetAsync(id);
                if (internalTransfer != null)
                {
                    return assignDataToInternalTransferViewModel(internalTransfer);
                }
            }
            catch (Exception e)
            {

            }
            return null;
        }
        public async Task<InternalTransferViewModel> AddInternalTransfer(InternalTransferViewModel model, ApplicationUser token)
        {
            try
            {
                InternalTransfer internalTransfer = new InternalTransfer
                {
                    OrganizationId = token.OrganizationId,
                    ShopId = token.ShopId,
                    InternalTransferNo = DateTime.Now.ToString("ddMMyyhhmmssmmm"),
                    Amount = model.Amount,                    
                    Note = model.Note,
                    SentBy = token.Id,
                    SentTo = model.SentTo,
                    SentDate = model.SentDate,
                    CapturedBy = token.Id,
                    CapturedDate = DateTime.Now,
                    Status = (byte)Status.InActive
                };
                InternalTransfer result = await repository.AddAsync(internalTransfer);
                model.Id = result.Id;
                if (result != null)
                {
                    return assignDataToInternalTransferViewModel(result);
                }
            }
            catch (Exception e)
            {

            }
            return null;
        }
        public async Task<InternalTransferViewModel> UpdateInternalTransfer(InternalTransferViewModel model, ApplicationUser token)
        {
            try
            {
                InternalTransfer internalTransfer = await repository.GetAsync((long)model.Id);
                if (internalTransfer != null)
                {
                    internalTransfer.Amount = model.Amount;
                    internalTransfer.Note = model.Note;
                    internalTransfer.SentBy = model.SentBy;
                    internalTransfer.SentTo = model.SentTo;
                    internalTransfer.SentDate = model.SentDate;
                    internalTransfer.ApprovedBy = token.Id;
                    internalTransfer.ApproveDate = DateTime.Now;
                    internalTransfer.CanceledBy = token.Id;
                    internalTransfer.CanceledDate = DateTime.Now;
                    internalTransfer.RejectReason = model.RejectReason;
                    internalTransfer.UpdatedBy = token.Id;
                    internalTransfer.UpdateDate = DateTime.Now;
                    internalTransfer.Status = (byte)Status.InActive;

                    InternalTransfer result = await repository.UpdateAsync(internalTransfer);
                    if (result != null)
                    {
                        return assignDataToInternalTransferViewModel(result);
                    }
                }
            }
            catch (Exception e)
            {

            }
            return null;
        }
        public async Task<InternalTransferViewModel> DeleteInternalTransfer(long id)
        {
            try
            {
                InternalTransfer internalTransfer = await repository.GetAsync(id);
                if (internalTransfer != null)
                {
                    InternalTransfer result = await repository.DeleteAsync(internalTransfer);
                    if (result != null)
                    {
                        return assignDataToInternalTransferViewModel(result);
                    }
                }
            }
            catch (Exception e)
            {

            }
            return null;
        }
        public async Task<InternalTransferDetailsModel> GetDetails(long id)
        {
            try
            {
                InternalTransfer internalTransfer = await repository.GetAsync(id);
                if (internalTransfer != null)
                {
                    InternalTransferDetailsModel internalTransferDetailsModel = new InternalTransferDetailsModel()
                    {
                        Id = internalTransfer.Id,
                        InternalTransferNo = internalTransfer.InternalTransferNo,
                        Amount = internalTransfer.Amount,
                        Note = internalTransfer.Note,
                        SentByName = internalTransfer.SentBy != null ? userManger.FindByIdAsync(internalTransfer.SentBy).Result.UserName : null,
                        SentTo = internalTransfer.SentTo,
                        SentDateString = internalTransfer.SentDate != null ? Formater.FormatDateddMMyyyy((DateTime)internalTransfer.SentDate) : null,
                        CapturedByName = internalTransfer.CapturedBy != null ? userManger.FindByIdAsync(internalTransfer.CapturedBy).Result.UserName : null,
                        CapturedDateString = internalTransfer.CapturedDate != null ? Formater.FormatDateddMMyyyy((DateTime)internalTransfer.CapturedDate) : null,
                        UpdateByName = internalTransfer.UpdatedBy != null ? userManger.FindByIdAsync(internalTransfer.UpdatedBy).Result.UserName : null,
                        UpdateDateString = internalTransfer.UpdateDate != null ? Formater.FormatDateddMMyyyy((DateTime)internalTransfer.UpdateDate) : null,
                        ApproveByName = internalTransfer.ApprovedBy != null ? userManger.FindByIdAsync(internalTransfer.ApprovedBy).Result.UserName : null,
                        ApproveDateString = internalTransfer.ApproveDate != null ? Formater.FormatDateddMMyyyy((DateTime)internalTransfer.ApproveDate) : null,
                        CancelByName = internalTransfer.CanceledBy != null ? userManger.FindByIdAsync(internalTransfer.CanceledBy).Result.UserName : null,
                        CancelDateString = internalTransfer.CanceledDate != null ? Formater.FormatDateddMMyyyy((DateTime)internalTransfer.CanceledDate) : null,
                        RejectReason = internalTransfer.RejectReason,
                        Status = internalTransfer.Status
                    };
                    return internalTransferDetailsModel;
                }

            }
            catch (Exception e)
            {

            }
            return null;
        }
        public async Task<List<InternalTransferDetailsModel>> GetTableData()
        {
            try
            {
                IEnumerable<InternalTransfer> internalTransfers = await repository.GetAsync();
                List<InternalTransferDetailsModel> internalTransferDetailsModels = new List<InternalTransferDetailsModel>();
                foreach (InternalTransfer internalTransfer in internalTransfers)
                {
                    InternalTransferDetailsModel internalTransferDetailsModel = new InternalTransferDetailsModel
                    {
                        Id = internalTransfer.Id,
                        InternalTransferNo = internalTransfer.InternalTransferNo,
                        Amount = internalTransfer.Amount,
                        Note = internalTransfer.Note,
                        SentByName = internalTransfer.SentBy != null ? userManger.FindByIdAsync(internalTransfer.SentBy).Result.UserName : null,
                        SentTo = internalTransfer.SentTo,
                        //SentToName = internalTransfer.SentTo != null ? userManger.FindByIdAsync(internalTransfer.SentTo).Result.UserName : null,
                        SentDateString = internalTransfer.SentDate != null ? Formater.FormatDateddMMyyyy((DateTime)internalTransfer.SentDate) : null,
                        Status = internalTransfer.Status,
                    };
                    internalTransferDetailsModels.Add(internalTransferDetailsModel);
                }
                if (internalTransferDetailsModels != null)
                {
                    return internalTransferDetailsModels;
                }
            }
            catch (Exception e)
            {

            }
            return null;
        }
        public InternalTransferViewModel assignDataToInternalTransferViewModel(InternalTransfer internalTransfer)
        {
            InternalTransferViewModel internalTransferViewModel = new InternalTransferViewModel
            {
                Id = internalTransfer.Id,
                OrganizationId = internalTransfer.OrganizationId,
                ShopId = internalTransfer.ShopId,
                InternalTransferNo = internalTransfer.InternalTransferNo,
                Amount = internalTransfer.Amount,
                Note = internalTransfer.Note,
                SentBy = internalTransfer.SentBy,
                SentTo = internalTransfer.SentTo,
                SentDate = internalTransfer.SentDate,
                CapturedBy = internalTransfer.CapturedBy,
                CapturedDate = internalTransfer.CapturedDate,
                UpdatedBy = internalTransfer.UpdatedBy,
                UpdateDate = internalTransfer.UpdateDate,
                ApprovedBy = internalTransfer.ApprovedBy,
                ApproveDate = internalTransfer.ApproveDate,
                CanceledBy = internalTransfer.CanceledBy,
                CanceledDate = internalTransfer.CanceledDate,
                RejectReason = internalTransfer.RejectReason,
                Status = internalTransfer.Status,
            };
            return internalTransferViewModel;
        }
    }
}
