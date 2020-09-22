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
    public class SupplierBLL
    {
        private readonly IRepository<Supplier> repository;
        private readonly UserManager<User> userManger;

        public SupplierBLL(IRepository<Supplier> repository, UserManager<User> userManger)
        {
            this.repository = repository;
            this.userManger = userManger;
        }
        public async Task<IEnumerable<SupplierViewModel>> GetSuppliers()
        {
            try
            {
                IEnumerable<Supplier> suppliers = await repository.GetAsync();
                List<SupplierViewModel> supplierViewModels = new List<SupplierViewModel>();
                if (suppliers != null)
                {
                    foreach (Supplier supplier in suppliers)
                    {
                        supplierViewModels.Add(assignDataToSupplierViewModel(supplier));
                    }
                    return supplierViewModels;
                }
            }
            catch (Exception e)
            {

            }
            return null;
        }
        public async Task<SupplierViewModel> GetSupplier(long id)
        {
            try
            {
                Supplier supplier = await repository.GetAsync(id);
                if (supplier != null)
                {
                    return assignDataToSupplierViewModel(supplier);
                }
            }
            catch (Exception e)
            {

            }
            return null;
        }
        public async Task<SupplierViewModel> AddSupplier(SupplierViewModel model, ApplicationUser token)
        {
            try
            {
                Supplier supplier = new Supplier
                {
                    OrganizationId = token.OrganizationId,
                    ShopId = token.ShopId,
                    SupplierNo = DateTime.Now.ToString("ddMMyyhhmmssmmm"),
                    Name = model.Name,
                    Email = model.Email,
                    Description = model.Description,
                    ContactNumber = model.ContactNumber,
                    ContactPerson = model.ContactPerson,                    
                    CreatedBy = token.Id,
                    CreatedDate = DateTime.Now,
                    Status = (byte)Status.InActive
                };
                Supplier result = await repository.AddAsync(supplier);
                model.Id = result.Id;
                if (result != null)
                {
                    return assignDataToSupplierViewModel(result);
                }
            }
            catch (Exception e)
            {

            }
            return null;
        }
        public async Task<SupplierViewModel> UpdateSupplier(SupplierViewModel model, ApplicationUser toekn)
        {
            try
            {
                Supplier supplier = await repository.GetAsync((long)model.Id);
                if (supplier != null)
                {
                    supplier.Name = model.Name;
                    supplier.Email = model.Email;
                    supplier.Description = model.Description;
                    supplier.ContactPerson = model.ContactPerson;
                    supplier.ContactNumber = model.ContactNumber;
                    supplier.ModifiedBy = toekn.Id;
                    supplier.ModifiedDate = DateTime.Now;

                    Supplier result = await repository.UpdateAsync(supplier);
                    if (result != null)
                    {
                        return assignDataToSupplierViewModel(result);
                    }
                }
            }
            catch (Exception e)
            {

            }
            return null;
        }
        public async Task<SupplierViewModel> DeleteSupplier(long id)
        {
            try
            {
                Supplier supplier = await repository.GetAsync(id);
                if (supplier != null)
                {
                    Supplier result = await repository.DeleteAsync(supplier);
                    if (result != null)
                    {
                        return assignDataToSupplierViewModel(result);
                    }
                }
            }
            catch (Exception e)
            {

            }
            return null;
        }
        public async Task<SupplierDetailsViewModel> GetDetails(long id)
        {
            try
            {
                Supplier supplier = await repository.GetAsync(id);
                if (supplier != null)
                {
                    SupplierDetailsViewModel supplierDetailsViewModel = new SupplierDetailsViewModel()
                    {
                        Id = supplier.Id,
                        SupplierNo = supplier.SupplierNo,
                        Name = supplier.Name,
                        Email = supplier.Email,
                        Description = supplier.Description,
                        ContactPerson = supplier.ContactPerson,
                        ContactNumber = supplier.ContactNumber,
                        ModifiedByName = supplier.ModifiedBy != null ? userManger.FindByIdAsync(supplier.ModifiedBy).Result.UserName : null,
                        CreatedByName = supplier.CreatedBy != null ? userManger.FindByIdAsync(supplier.CreatedBy).Result.UserName : null,
                        ModifiedDateString = supplier.ModifiedDate != null ? Formater.FormatDateddMMyyyy((DateTime)supplier.ModifiedDate) : null,
                        CreatedDateString = supplier.CreatedDate != null ? Formater.FormatDateddMMyyyy((DateTime)supplier.CreatedDate) : null,
                        Status = supplier.Status
                    };
                    return supplierDetailsViewModel;
                }

            }
            catch (Exception e)
            {

            }
            return null;
        }
        public async Task<List<SupplierDetailsViewModel>> GetTableData()
        {
            try
            {
                IEnumerable<Supplier> suppliers = await repository.GetAsync();
                List<SupplierDetailsViewModel> supplierDetailsViewModels = new List<SupplierDetailsViewModel>();
                foreach (Supplier supplier in suppliers)
                {
                    SupplierDetailsViewModel supplierDetailsViewModel = new SupplierDetailsViewModel
                    {
                        Id = supplier.Id,
                        SupplierNo = supplier.SupplierNo,
                        Name = supplier.Name,
                        Email = supplier.Email,
                        ContactNumber = supplier.ContactNumber,                        
                        Status = supplier.Status
                    };
                    supplierDetailsViewModels.Add(supplierDetailsViewModel);
                }
                if (supplierDetailsViewModels != null)
                {
                    return supplierDetailsViewModels;
                }
            }
            catch (Exception e)
            {

            }
            return null;
        }
        public SupplierViewModel assignDataToSupplierViewModel(Supplier supplier)
        {
            SupplierViewModel supplierViewModel = new SupplierViewModel
            {
                Id = supplier.Id,
                OrganizationId = supplier.OrganizationId,
                ShopId = supplier.ShopId,
                Name = supplier.Name,
                SupplierNo = supplier.SupplierNo,
                Email = supplier.Email,
                Description = supplier.Description,
                ContactNumber = supplier.ContactNumber,
                ContactPerson = supplier.ContactPerson,
                CreatedBy = supplier.CreatedBy,
                CreatedDate = supplier.CreatedDate,
                ModifiedBy = supplier.ModifiedBy,
                ModifiedDate = supplier.ModifiedDate,                
                Status = supplier.Status,
            };
            return supplierViewModel;
        }
    }
}
