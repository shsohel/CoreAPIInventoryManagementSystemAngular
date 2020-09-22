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
   public class VATBLL
    {
        private readonly IRepository<VAT> repository;
        private readonly UserManager<User> userManager;

        public VATBLL(IRepository<VAT> repository, UserManager<User> userManager)
        {
            this.repository = repository;
            this.userManager = userManager;
        }
        public async Task<IEnumerable<VATViewModel>> GetVATs()
        {
            try
            {
                IEnumerable<VAT> vATs = await repository.GetAsync();
                List<VATViewModel> vATViewModels = new List<VATViewModel>();
                if (vATs != null)
                {
                    foreach (VAT vAT in vATs)
                    {
                         vATViewModels.Add(assignDataToVATViewModel(vAT));
                    }
                    return vATViewModels;
                }
            }
            catch (Exception e)
            {

            }
            return null;
        }
        public async Task<VATViewModel> GetVAT(long id)
        {
            try
            {
                VAT vAT = await repository.GetAsync(id);
                if (vAT != null)
                {
                    return assignDataToVATViewModel(vAT);
                }
            }
            catch (Exception e)
            {
                e.Message.Contains("Something Wrong");
            }
            return null;
        }
        public async Task<VATViewModel> AddVAT(VATViewModel model, ApplicationUser token)
        {
            try
            {
                VAT vAT = new VAT
                {
                    Name = model.Name,
                    VatNo = DateTime.Now.ToString("ddMMyyhhmmssmmm"),
                    Amount = model.Amount,
                    Description = model.Description,
                    IsPercent = model.IsPercent,
                    CreatedBy = token.Id,
                    FromDate = model.FromDate,
                    ToDate = model.ToDate,
                    OrganizationId = token.OrganizationId,
                    ShopId = token.ShopId,      
                    CreatedDate = DateTime.Now,
                    Status = (byte)Status.Active
                };
                VAT result = await repository.AddAsync(vAT);
                model.Id = result.Id;
                if (result != null)
                {
                    return assignDataToVATViewModel(result);
                }
            }
            catch (Exception e)
            {

            }
            return null;
        }
        public async Task<VATViewModel> UpdateVAT(VATViewModel model, ApplicationUser token)
        {
            try
            {
                VAT vAT = await repository.GetAsync(model.Id);
                if (vAT != null)
                {
                    vAT.Name = model.Name;
                    vAT.Amount = model.Amount;
                    vAT.Description = model.Description;
                    vAT.IsPercent = model.IsPercent;
                    vAT.FromDate = model.FromDate;
                    vAT.ToDate = model.ToDate; 
                    vAT.ModifiedBy = token.Id;
                    vAT.ModifiedDate = DateTime.Now;
                    VAT result = await repository.UpdateAsync(vAT);
                    if (result != null)
                    {
                        return assignDataToVATViewModel(result);
                    }
                }
            }
            catch (Exception e)
            {

            }
            return null;
        }
        public async Task<VATViewModel> DeleteVAT(long id)
        {
            try
            {
                VAT vAT = await repository.GetAsync(id);
                if (vAT != null)
                {
                    VAT result = await repository.DeleteAsync(vAT);
                    if (result != null)
                    {
                        return assignDataToVATViewModel(result);
                    }
                }
            }
            catch (Exception e)
            {

            }
            return null;
        }
        public async Task<VATViewModel> GetDetails(long id)
        {
            try
            {
                VAT vAT = await repository.GetAsync(id);
                if (vAT != null)
                {
                    VATDetailsViewModel employeeViewModel = new VATDetailsViewModel
                    {
                        VatNo=vAT.VatNo,
                        Amount = vAT.Amount,
                        Description=vAT.Description,
                        IsPercent=vAT.IsPercent,
                        CreatedByName= vAT.CreatedBy != null ? userManager.FindByIdAsync(vAT.CreatedBy).Result.UserName : null,
                        CreatedDateString= vAT.CreatedDate != null ? Formater.FormatDateddMMyyyy((DateTime)vAT.CreatedDate) : null,
                        ModifiedByName= vAT.ModifiedBy != null ? userManager.FindByIdAsync(vAT.ModifiedBy).Result.UserName : null,
                        ModifiedDateString = vAT.ModifiedDate != null ? Formater.FormatDateddMMyyyy((DateTime)vAT.ModifiedDate) : null,
                        Name=vAT.Name,
                        OrganizationId=vAT.OrganizationId,
                        ShopId=vAT.ShopId,
                        Status=vAT.Status,
                    };
                    return employeeViewModel;
                }
            }
            catch (Exception e)
            {

            }
            return null;
        }
        public async Task<List<VATViewModel>> GetTableData()
        {
            try
            {
                IEnumerable<VAT> vATs = await repository.GetAsync();
                List<VATViewModel> vATViewModels = new List<VATViewModel>();
                foreach (VAT vAT in vATs)
                {
                    VATDetailsViewModel vATViewModel = new VATDetailsViewModel
                    {
                        Id = vAT.Id,
                        Amount=vAT.Amount,
                        OrganizationId=vAT.OrganizationId,
                        IsPercent=vAT.IsPercent,
                        ShopId=vAT.ShopId,
                         Description=vAT.Description,                        
                        Name = vAT.Name,
                        VatNo=vAT.VatNo,
                        FromDateString= Formater.FormatDateddMMyyyy(Convert.ToDateTime(vAT.FromDate)),
                        ToDateString = Formater.FormatDateddMMyyyy(Convert.ToDateTime(vAT.ToDate)),
                        Status = (byte)vAT.Status
                    };
                    vATViewModels.Add(vATViewModel);
                }
                if (vATViewModels != null)
                {
                    return vATViewModels;
                }
            }
            catch (Exception e)
            {

            }
            return null;
        }
        public VATViewModel assignDataToVATViewModel(VAT vAT)
        {
            VATViewModel vATViewModel = new VATViewModel
            {
                Id=vAT.Id,
                Name = vAT.Name,
                VatNo=vAT.VatNo,
                ShopId = vAT.ShopId,
                OrganizationId=vAT.OrganizationId,
                Amount = vAT.Amount,
                Description =vAT.Description,
                IsPercent=vAT.IsPercent,
                CreatedBy = vAT.CreatedBy,
                FromDate=Convert.ToDateTime(vAT.FromDate),
                ToDate=Convert.ToDateTime(vAT.ToDate),
                CreatedDate = Convert.ToDateTime(vAT.CreatedDate),
                ModifiedBy = vAT.ModifiedBy,
                ModifiedDate = Convert.ToDateTime(vAT.ModifiedDate),
                Status = (byte)vAT.Status
            };
            return vATViewModel;
        }
    }
}