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
    public class ExternalTransferBLL
    {
        private readonly IRepository<ExternalTransfer> repository;
        private readonly UserManager<User> userManager;

        public ExternalTransferBLL(IRepository<ExternalTransfer> repository, UserManager<User> userManager)
        {
            this.repository = repository;
            this.userManager = userManager;
        }
        public async Task<IEnumerable<ExternalTransferViewModel>> GetExternalTransfers()
        {
            try
            {
                IEnumerable<ExternalTransfer> externalTransfers = await repository.GetAsync();
                List<ExternalTransferViewModel> externalTransferViewModels = new List<ExternalTransferViewModel>();
                if (externalTransfers != null)
                {
                    foreach (ExternalTransfer externalTransfer in externalTransfers)
                    {
                        externalTransferViewModels.Add(assignDataToExternalTransferViewModel(externalTransfer));
                    }
                    return externalTransferViewModels;
                }
            }
            catch (Exception e)
            {

            }
            return null;
        }
        public async Task<ExternalTransferViewModel> GetExternalTransfer(long id)
        {
            try
            {
                ExternalTransfer externalTransfer = await repository.GetAsync(id);
                if (externalTransfer != null)
                {
                    return assignDataToExternalTransferViewModel(externalTransfer);
                }
            }
            catch (Exception e)
            {

            }
            return null;
        }
        public async Task<ExternalTransferViewModel> AddExternalTransfer(ExternalTransferViewModel model, ApplicationUser token)
        {
            try
            {
                ExternalTransfer externalTransfer = new ExternalTransfer
                {
                    OrganizationId = token.OrganizationId,
                    ShopId = token.ShopId,
                    ExternalTransferNo = DateTime.Now.ToString("ddMMyyhhmmssmmm"),
                    ExternalPersonId = model.ExternalPersonId,
                    BusinessRelativeId = model.BusinessRelativeId,
                    Amount = model.Amount,
                    Note = model.Note,
                    Paid = model.Paid,
                    Received = model.Received,                    
                    CapturedBy = token.Id,
                    CapturedDate = DateTime.Now,
                    Status = (byte)Status.InActive
                };
                ExternalTransfer result = await repository.AddAsync(externalTransfer);
                model.Id = result.Id;
                if (result != null)
                {
                    return assignDataToExternalTransferViewModel(result);
                }
            }
            catch (Exception e)
            {

            }
            return null;
        }
        public async Task<ExternalTransferViewModel> UpdateExternalTransfer(ExternalTransferViewModel model, ApplicationUser token)
        {
            try
            {
                ExternalTransfer externalTransfer = await repository.GetAsync((long)model.Id);
                if (externalTransfer != null)
                {
                    externalTransfer.Amount = model.Amount;
                    externalTransfer.Note = model.Note;
                    externalTransfer.ApprovedBy = token.Id;
                    externalTransfer.ApprovedDate = DateTime.Now;
                    externalTransfer.CanceledBy = token.Id;
                    externalTransfer.CanceledDate = DateTime.Now;
                    externalTransfer.RequestedBy = model.RequestedBy;
                    externalTransfer.RejectReason = model.RejectReason;
                    externalTransfer.UpdatedBy = token.Id;
                    externalTransfer.UpdatedDate = DateTime.Now;
                    externalTransfer.Status = (byte)Status.InActive;

                    ExternalTransfer result = await repository.UpdateAsync(externalTransfer);
                    if (result != null)
                    {
                        return assignDataToExternalTransferViewModel(result);
                    }
                }
            }
            catch (Exception e)
            {

            }
            return null;
        }
        public async Task<ExternalTransferViewModel> DeleteExternalTransfer(long id)
        {
            try
            {
                ExternalTransfer externalTransfer = await repository.GetAsync(id);
                if (externalTransfer != null)
                {
                    ExternalTransfer result = await repository.DeleteAsync(externalTransfer);
                    if (result != null)
                    {
                        return assignDataToExternalTransferViewModel(result);
                    }
                }
            }
            catch (Exception e)
            {

            }
            return null;
        }
        public async Task<ExternalTransferDetailsModel> GetDetails(long id)
        {
            try
            {
                ExternalTransfer externalTransfer = await repository.GetAsync(id);
                if (externalTransfer != null)
                {
                    ExternalTransferDetailsModel externalTransferDetailsModel = new ExternalTransferDetailsModel()
                    {
                        Id = externalTransfer.Id,
                        ExternalTransferNo = externalTransfer.ExternalTransferNo,
                        Amount = externalTransfer.Amount,
                        Note = externalTransfer.Note,
                        RequestByName = externalTransfer.RequestedBy,
                        CapturedByName = externalTransfer.CapturedBy != null ? userManager.FindByIdAsync(externalTransfer.CapturedBy).Result.UserName : null,
                        CaptureDateString = externalTransfer.CapturedDate != null ? Formater.FormatDateddMMyyyy((DateTime)externalTransfer.CapturedDate) : null,
                        UpdatedByName = externalTransfer.UpdatedBy != null ? userManager.FindByIdAsync(externalTransfer.UpdatedBy).Result.UserName : null,
                        UpdatedDateString = externalTransfer.UpdatedDate != null ? Formater.FormatDateddMMyyyy((DateTime)externalTransfer.UpdatedDate) : null,
                        ApprovedByName = externalTransfer.ApprovedBy != null ? userManager.FindByIdAsync(externalTransfer.ApprovedBy).Result.UserName : null,
                        ApproveDateString = externalTransfer.ApprovedDate != null ? Formater.FormatDateddMMyyyy((DateTime)externalTransfer.ApprovedDate) : null,
                        CanceledByName = externalTransfer.CanceledBy != null ? userManager.FindByIdAsync(externalTransfer.CanceledBy).Result.UserName : null,
                        CanceledDateString = externalTransfer.CanceledDate != null ? Formater.FormatDateddMMyyyy((DateTime)externalTransfer.CanceledDate) : null,
                        RejectReason = externalTransfer.RejectReason,
                        Status = externalTransfer.Status
                    };
                    return externalTransferDetailsModel;
                }

            }
            catch (Exception e)
            {

            }
            return null;
        }
        public async Task<List<ExternalTransferDetailsModel>> GetTableData()
        {
            try
            {
                IEnumerable<ExternalTransfer> externalTransfers = await repository.GetAsync();
                List<ExternalTransferDetailsModel> externalTransferDetailsModels = new List<ExternalTransferDetailsModel>();
                foreach (ExternalTransfer externalTransfer in externalTransfers)
                {
                    ExternalTransferDetailsModel externalTransferDetailsModel = new ExternalTransferDetailsModel
                    {
                        Id = externalTransfer.Id,
                        ExternalTransferNo = externalTransfer.ExternalTransferNo,
                        BusinessRelativeId = externalTransfer.BusinessRelativeId,
                        Amount = externalTransfer.Amount,
                        Note = externalTransfer.Note,
                        Paid = externalTransfer.Paid,
                        Received = externalTransfer.Received,
                        RequestedBy = externalTransfer.RequestedBy,
                        CaptureDateString = externalTransfer.CapturedDate != null ? Formater.FormatDateddMMyyyy((DateTime)externalTransfer.CapturedDate) : null,
                        Status = externalTransfer.Status
                    };
                    externalTransferDetailsModels.Add(externalTransferDetailsModel);
                }
                if (externalTransferDetailsModels != null)
                {
                    return externalTransferDetailsModels;
                }
            }
            catch (Exception e)
            {

            }
            return null;
        }
        public ExternalTransferViewModel assignDataToExternalTransferViewModel(ExternalTransfer externalTransfer)
        {
            ExternalTransferViewModel externalTransferViewModel = new ExternalTransferViewModel
            {
                Id = externalTransfer.Id,
                OrganizationId = externalTransfer.OrganizationId,
                ShopId = externalTransfer.ShopId,
                ExternalTransferNo = externalTransfer.ExternalTransferNo,
                Amount = externalTransfer.Amount,
                Note = externalTransfer.Note,
                ExternalPersonId = externalTransfer.ExternalPersonId,
                BusinessRelativeId = externalTransfer.BusinessRelativeId,
                Paid = externalTransfer.Paid,
                Received = externalTransfer.Received,
                RequestedBy = externalTransfer.RequestedBy,
                RequestedDate = externalTransfer.RequestedDate,
                RejectedBy = externalTransfer.RejectedBy,
                RejectedDate = externalTransfer.RejectedDate,
                CapturedBy = externalTransfer.CapturedBy,
                CapturedDate = externalTransfer.CapturedDate,
                UpdatedBy = externalTransfer.UpdatedBy,
                UpdatedDate = externalTransfer.UpdatedDate,
                ApprovedBy = externalTransfer.ApprovedBy,
                ApprovedDate = externalTransfer.ApprovedDate,
                CanceledBy = externalTransfer.CanceledBy,
                CanceledDate = externalTransfer.CanceledDate,
                RejectReason = externalTransfer.RejectReason,
                Status = externalTransfer.Status,
            };
            return externalTransferViewModel;
        }
    }
}
