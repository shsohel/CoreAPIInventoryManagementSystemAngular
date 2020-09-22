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

namespace PurchaseBLL
{
    public class PurchasesBLL
    {
        private readonly IRepository<Purchase> repository;
        private readonly UserManager<User> userManager;
        private readonly IRepository<Employee> empRepository;
        private readonly IRepository<Supplier> supRepository;

        public PurchasesBLL(IRepository<Purchase> repository, UserManager<User> userManager, IRepository<Supplier> supRepository, IRepository<Employee> empRepository)
        {
            this.repository = repository;
            this.userManager = userManager;
            this.empRepository = empRepository;
            this.supRepository = supRepository;
        }
        public async Task<IEnumerable<PurchaseViewModel>> GetPurchases()
        {
            try
            {
                IEnumerable<Purchase> purchases = await repository.GetAsync();
                List<PurchaseViewModel> purchaseViewModels = new List<PurchaseViewModel>();
                if (purchases != null)
                {
                    foreach (Purchase purchase in purchases)
                    {
                        purchaseViewModels.Add(assignDataToPurchaseViewModel(purchase));
                    }
                    return purchaseViewModels;
                }
            }
            catch (Exception e)
            {

            }
            return null;
        }
        public async Task<PurchaseViewModel> GetPurchase(long id)
        {
            try
            {
                Purchase purchases = await repository.GetAsync(id);
                if (purchases != null)
                {
                    return assignDataToPurchaseViewModel(purchases);
                }
            }
            catch (Exception e)
            {

            }
            return null;
        }
        public async Task<PurchaseViewModel> AddPurchase(PurchaseViewModel model, ApplicationUser token)
        {
            try
            {
                Purchase purchase = new Purchase
                {
                    OrganizationId = token.OrganizationId,
                    ShopId = token.ShopId,
                    Date = DateTime.Now,
                    SupplierId = model.SupplierId,
                    LabourCost = model.LabourCost,
                    OthersCost = model.OthersCost,
                    PaidAmount = model.PaidAmount,
                    PaidByEmpId = model.PaidByEmpId,
                    PurchaseNo = DateTime.Now.ToString("ddMMyyhhmmssmmm"),
                    PurchaseOrderId = model.PurchaseOrderId,
                    ResponsibleEmpId = (int)model.ResponsibleEmpId,
                    TransportCost = model.TransportCost,
                    Vat = model.Vat,
                    IsLocked = (bool)model.IsLocked,
                    IsWarehoused = model.IsWarehoused,
                    WareHouseId = model.WareHouseId,
                    Amount = model.Amount,
                    Note = model.Note,
                    CreatedBy = token.Id,
                    CreatedDate = DateTime.Now,
                    Status = (byte)Status.InActive
                };
                Purchase result = await repository.AddAsync(purchase);
                model.Id = result.Id;
                if (result != null)
                {
                    return assignDataToPurchaseViewModel(result);
                }
            }
            catch (Exception e)
            {

            }
            return null;
        }
        public async Task<PurchaseViewModel> UpdatePurchase(PurchaseViewModel model, ApplicationUser token)
        {
            try
            {
                Purchase purchase = await repository.GetAsync((long)model.Id);
                if (purchase != null)
                {
                    purchase.TransportCost = model.TransportCost;
                    purchase.ResponsibleEmpId = (int)model.ResponsibleEmpId;
                    purchase.PurchaseOrderId = model.PurchaseOrderId;
                    purchase.PaidByEmpId = model.PaidByEmpId;
                    purchase.PaidAmount = model.PaidAmount;
                    purchase.OthersCost = model.OthersCost;
                    purchase.Vat = model.Vat;
                    purchase.Note = model.Note;
                    purchase.IsLocked = (bool)model.IsLocked;
                    purchase.IsWarehoused = (bool)model.IsWarehoused;
                    purchase.SupplierId = model.SupplierId;
                    purchase.LabourCost = model.LabourCost;
                    purchase.WareHouseId = model.WareHouseId;
                    purchase.Amount = model.Amount;
                    purchase.ModifiedBy = token.Id;
                    purchase.ModifiedDate = DateTime.Now;
                    purchase.Status = (byte)Status.Active;

                    Purchase result = await repository.UpdateAsync(purchase);
                    if (result != null)
                    {
                        return assignDataToPurchaseViewModel(result);
                    }
                }
            }
            catch (Exception e)
            {

            }
            return null;
        }
        public async Task<PurchaseViewModel> DeletePurchase(long id)
        {
            try
            {
                Purchase purchase = await repository.GetAsync(id);
                if (purchase != null)
                {
                    Purchase result = await repository.DeleteAsync(purchase);
                    if (result != null)
                    {
                        return assignDataToPurchaseViewModel(result);
                    }
                }
            }
            catch (Exception e)
            {

            }
            return null;
        }
        public async Task<PurchaseDetailsViewModel> GetDetails(long id)
        {
            try
            {
                Purchase purchase = await repository.GetAsync(id);
                if (purchase != null)
                {
                    PurchaseDetailsViewModel purchaseDetailsViewModel = new PurchaseDetailsViewModel()
                    {
                        Id = purchase.Id,
                        Note = purchase.Note,
                        ResponsibleEmpName = empRepository.GetAsync(purchase.ResponsibleEmpId).Result.Name,
                        PaidByEmpName = empRepository.GetAsync(purchase.PaidByEmpId).Result.Name,
                        PaidAmount = purchase.PaidAmount,
                        PurchaseNo = purchase.PurchaseNo,
                        PurchaseOrderId = purchase.PurchaseOrderId,
                        WareHouseId = purchase.WareHouseId,
                        TransportCost = purchase.TransportCost,
                        Vat = purchase.Vat,
                        OthersCost = purchase.OthersCost,
                        LabourCost = purchase.LabourCost,
                        IsWarehoused = purchase.IsWarehoused,
                        IsLocked = purchase.IsLocked,
                        Amount = purchase.Amount,                        
                        DateString = purchase.Date != null ? Formater.FormatDateddMMyyyy((DateTime)purchase.Date) : null,
                        SupplierName = supRepository.GetAsync(purchase.SupplierId).Result.Name,
                        CreatedByName = purchase.CreatedBy != null ? userManager.FindByIdAsync(purchase.CreatedBy).Result.UserName : null,
                        CreatedDateString = purchase.CreatedDate != null ? Formater.FormatDateddMMyyyy((DateTime)purchase.CreatedDate) : null,
                        ModifiedByName = purchase.ModifiedBy != null ? userManager.FindByIdAsync(purchase.ModifiedBy).Result.UserName : null,
                        ModifiedDateString = purchase.ModifiedDate != null ? Formater.FormatDateddMMyyyy((DateTime)purchase.ModifiedDate) : null,
                        Status = purchase.Status
                    };
                    return purchaseDetailsViewModel;
                }

            }
            catch (Exception e)
            {

            }
            return null;
        }
        public async Task<List<PurchaseDetailsViewModel>> GetTableData()
        {
            try
            {
                IEnumerable<Purchase> purchases = await repository.GetAsync();
                List<PurchaseDetailsViewModel> purchaseDetailsViewModels = new List<PurchaseDetailsViewModel>();
                foreach (Purchase purchase in purchases)
                {
                    PurchaseDetailsViewModel purchaseDetailsViewModel = new PurchaseDetailsViewModel
                    {
                        Id = purchase.Id,
                        PurchaseNo = purchase.PurchaseNo,
                        DateString = purchase.Date != null ? Formater.FormatDateddMMyyyy((DateTime)purchase.Date) : null,
                        PaidAmount = purchase.PaidAmount,
                        Amount = purchase.Amount,
                        PurchaseOrderId = purchase.PurchaseOrderId,
                        SupplierName = supRepository.GetAsync(Convert.ToInt64(purchase.SupplierId)).Result.Name,
                        ResponsibleEmpName = empRepository.GetAsync(Convert.ToInt64(purchase.ResponsibleEmpId)).Result.Name,
                        Status = purchase.Status
                    };
                    purchaseDetailsViewModels.Add(purchaseDetailsViewModel);
                }
                if (purchaseDetailsViewModels != null)
                {
                    return purchaseDetailsViewModels;
                }
            }
            catch (Exception e)
            {

            }
            return null;
        }
        public PurchaseViewModel assignDataToPurchaseViewModel(Purchase purchase)
        {
            PurchaseViewModel purchaseViewModel = new PurchaseViewModel
            {
                Id = purchase.Id,
                OrganizationId = purchase.OrganizationId,
                ShopId = purchase.ShopId,
                PaidAmount = purchase.PaidAmount,
                Date = purchase.Date,
                IsLocked = purchase.IsLocked,
                LabourCost = purchase.LabourCost,
                PurchaseNo = purchase.PurchaseNo,
                PaidByEmpId = purchase.PaidByEmpId,
                PurchaseOrderId = purchase.PurchaseOrderId,
                ResponsibleEmpId = purchase.ResponsibleEmpId,
                IsWarehoused = purchase.IsWarehoused,
                OthersCost = purchase.OthersCost,
                Note = purchase.Note,
                Amount = purchase.Amount,
                Vat = purchase.Vat,
                SupplierId = purchase.SupplierId,
                TransportCost = purchase.TransportCost,
                WareHouseId = purchase.WareHouseId,
                CreatedBy = purchase.CreatedBy,
                CreatedDate = purchase.CreatedDate,
                ModifiedDate = purchase.ModifiedDate,
                ModifiedBy = purchase.ModifiedBy,
                Status = purchase.Status,
            };
            return purchaseViewModel;
        }
    }
}
