using CommonBLL.Enums;
using CommonBLL.Helper;
using CommonDAL.Models;
using CommonDAL.Repository;
using CommonDAL.ViewModels;
using FinanceBLL;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AdminBLL
{
    public class VendorBLL
    {
        private readonly IRepository<Vendor> repository;
        private readonly UserManager<User> userManager;
        private readonly IRepository<ExternalPerson> exPersonBLL;

        public VendorBLL(IRepository<Vendor> repository, UserManager<User> userManager, IRepository<ExternalPerson> exPersonBLL)
        {
            this.repository = repository;
            this.userManager = userManager;
            this.exPersonBLL = exPersonBLL;
        }
        public async Task<IEnumerable<VendorViewModel>> GetVendors()
        {
            try
            {
                IEnumerable<Vendor> vendors = await repository.GetAsync();
                List<VendorViewModel> vendorViewModels = new List<VendorViewModel>();
                if (vendors != null)
                {
                    foreach (Vendor vendor in vendors)
                    {
                        vendorViewModels.Add(assignDataToVendorViewModel(vendor));
                    }
                    return vendorViewModels;
                }
            }
            catch (Exception e)
            {

            }
            return null;
        }
        public async Task<VendorViewModel> GetVendor(long id)
        {
            try
            {
                Vendor vendor = await repository.GetAsync(id);
                if (vendor != null)
                {
                    return assignDataToVendorViewModel(vendor);
                }
            }
            catch (Exception e)
            {

            }
            return null;
        }
        public async Task<VendorViewModel> AddVendor(VendorViewModel model, ApplicationUser token)
        {
            try
            {
                Vendor vendor = new Vendor
                {
                    OrganizationId = token.OrganizationId,
                    ShopId = token.ShopId,
                    VendorNo = DateTime.Now.ToString("ddMMyyhhmmssmmm"),
                    GuarantorId = model.GuarantorId,
                    Name = model.Name,
                    MobileNo = model.MobileNo,
                    Address = model.Address,
                    Email = model.Email,
                    CreditLimit = model.CreditLimit,
                    DayOfPayment = model.DayOfPayment,
                    DiscountPercent = model.DiscountPercent,
                    RegistrationNo = model.RegistrationNo,
                    Tin = model.Tin,
                    //Picture = FileUploader.Upload(model.Picture, "VendorImages", model.Picture, hostingEnvironment),
                    CreatedBy = token.Id,
                    CreatedDate = DateTime.Now,
                    Status = (byte)Status.InActive
                };
                Vendor result = await repository.AddAsync(vendor);
                model.Id = result.Id;
                if (result != null)
                {
                    return assignDataToVendorViewModel(result);
                }
            }
            catch (Exception e)
            {

            }
            return null;
        }
        public async Task<VendorViewModel> UpdateVendor(VendorViewModel model, ApplicationUser token)
        {
            try
            {
                Vendor vendor = await repository.GetAsync((long)model.Id);
                if (vendor != null)
                {
                    vendor.GuarantorId = model.GuarantorId;
                    vendor.Name = model.Name;
                    vendor.MobileNo = model.MobileNo;
                    vendor.Address = model.Address;
                    vendor.Email = model.Email;
                    vendor.CreditLimit = model.CreditLimit;
                    vendor.DayOfPayment = model.DayOfPayment;
                    vendor.DiscountPercent = model.DiscountPercent;
                    vendor.RegistrationNo = model.RegistrationNo;
                    vendor.Tin = model.Tin;
                    vendor.Picture = model.Picture;
                    vendor.ModifiedBy = token.Id;
                    vendor.ModifiedDate = DateTime.Now;
                    vendor.Status = (byte)Status.InActive;
                    Vendor result = await repository.UpdateAsync(vendor);
                    if (result != null)
                    {
                        return assignDataToVendorViewModel(result);
                    }
                }
            }
            catch (Exception e)
            {

            }
            return null;
        }
        public async Task<VendorViewModel> DeleteVendor(long id)
        {
            try
            {
                Vendor vendor = await repository.GetAsync(id);
                if (vendor != null)
                {
                    Vendor result = await repository.DeleteAsync(vendor);
                    if (result != null)
                    {
                        return assignDataToVendorViewModel(result);
                    }
                }
            }
            catch (Exception e)
            {

            }
            return null;
        }
        public async Task<VendorViewModel> GetDetails(long id)
        {
            try
            {
                Vendor vendor = await repository.GetAsync(id);
                if (vendor != null)
                {
                    VedorDetailsViewModel vedorDetailsViewModel = new VedorDetailsViewModel()
                    {
                        VendorNo = vendor.VendorNo,
                        Name = vendor.Name,
                        MobileNo = vendor.MobileNo,
                        Email = vendor.Email,
                        Address = vendor.Address,
                        DiscountPercent = vendor.DiscountPercent,
                        RegistrationNo = vendor.RegistrationNo,
                        Tin = vendor.Tin,
                        GurantorName =  exPersonBLL.GetAsync(Convert.ToInt64(vendor.GuarantorId)).Result.Name,
                        CreditLimit = vendor.CreditLimit,
                        DayOfPaymentString = vendor.DayOfPayment != null ? Formater.FormatDateddMMyyyy(Convert.ToDateTime(vendor.DayOfPayment)) : null,
                        CreatedByName = vendor.CreatedBy != null ? userManager.FindByIdAsync(vendor.CreatedBy).Result.UserName : null,
                        CreatedDateString = vendor.CreatedDate != null ? Formater.FormatDateddMMyyyy((DateTime)vendor.CreatedDate) : null,
                        ModifiedByName = vendor.CreatedBy != null ? userManager.FindByIdAsync(vendor.CreatedBy).Result.UserName : null,
                        ModifiedDateString = vendor.ModifiedDate != null ? Formater.FormatDateddMMyyyy((DateTime)vendor.ModifiedDate) : null,
                        Status = vendor.Status
                    };
                    return vedorDetailsViewModel;
                }

            }
            catch (Exception e)
            {

            }
            return null;
        }
        public async Task<List<VedorDetailsViewModel>> GetTableData()
        {
            try
            {
                IEnumerable<Vendor> vendors = await repository.GetAsync();
                List<VedorDetailsViewModel> vedorDetailsViewModels = new List<VedorDetailsViewModel>();
                foreach (Vendor vendor in vendors)
                {
                    VedorDetailsViewModel vedorDetailsViewModel = new VedorDetailsViewModel
                    {
                        Id = vendor.Id,
                        Email = vendor.Email,
                        VendorNo = vendor.VendorNo,
                        Name = vendor.Name,
                        MobileNo = vendor.MobileNo,
                        Address = vendor.Address,
                        Status = vendor.Status,
                    };
                    vedorDetailsViewModels.Add(vedorDetailsViewModel);
                }
                if (vedorDetailsViewModels != null)
                {
                    return vedorDetailsViewModels;
                }
            }
            catch (Exception e)
            {

            }
            return null;
        }
        public VendorViewModel assignDataToVendorViewModel(Vendor vendor)
        {
            VendorViewModel vendorViewModel = new VendorViewModel
            {
                Id = vendor.Id,
                Email = vendor.Email,                
                OrganizationId = vendor.OrganizationId,
                ShopId = vendor.ShopId,
                VendorNo = vendor.VendorNo,
                GuarantorId = vendor.GuarantorId,
                Name = vendor.Name,
                MobileNo = vendor.MobileNo,
                Address = vendor.Address,
                CreditLimit = vendor.CreditLimit,
                DayOfPayment = vendor.DayOfPayment,
                DiscountPercent = vendor.DiscountPercent,
                RegistrationNo = vendor.RegistrationNo,
                Tin = vendor.Tin,
                Picture = vendor.Picture,
                CreatedBy = vendor.CreatedBy,
                CreatedDate = vendor.CreatedDate,
                ModifiedBy = vendor.ModifiedBy,
                ModifiedDate = vendor.ModifiedDate,
                Status = vendor.Status,
            };
            return vendorViewModel;
        }
    }
}
