using CommonBLL.Enums;
using CommonBLL.Helper;
using CommonDAL.Models;
using CommonDAL.Repository;
using CommonDAL.ViewModels;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StockBLL
{
    public class WarehouseBLL
    {
        private readonly IRepository<Warehouse> repository;
        private readonly UserManager<User> userManger;

        public WarehouseBLL(IRepository<Warehouse> repository, UserManager<User> userManger)
        {
            this.repository = repository;
            this.userManger = userManger;
        }
        public async Task<IEnumerable<WarehouseViewModel>> GetWarehouses()
        {
            try
            {
                IEnumerable<Warehouse> warehouses = await repository.GetAsync();
                List<WarehouseViewModel> warehouseViewModels = new List<WarehouseViewModel>();
                if (warehouses != null)
                {
                    foreach (Warehouse warehouse in warehouses)
                    {
                        warehouseViewModels.Add(assignDataToWarehouseViewModel(warehouse));
                    }
                    return warehouseViewModels;
                }
            }
            catch (Exception e)
            {

            }
            return null;
        }
        public async Task<WarehouseViewModel> GetWarehouse(int id)
        {
            try
            {
                Warehouse warehouse = await repository.GetAsync(id);
                if (warehouse != null)
                {
                    return assignDataToWarehouseViewModel(warehouse);
                }
            }
            catch (Exception e)
            {

            }
            return null;
        }
        public async Task<WarehouseViewModel> AddWarehouse(WarehouseViewModel model, ApplicationUser token)
        {
            try
            {
                Warehouse warehouse = new Warehouse
                {
                    OrganizationId = token.OrganizationId,
                    ShopId = token.ShopId,
                    WarehouseNo = DateTime.Now.ToString("ddMMyyhhmmssmmm"),
                    Name = model.Name,
                    MobileNo = model.MobileNo,
                    Email = model.Email,
                    Address = model.Address,
                    ContactPerson = model.ContactPerson,
                    Description = model.Description,
                    IsDefault = (bool)model.IsDefault,
                    CreatedBy = token.Id,
                    CreatedDate = DateTime.Now,
                    Status = (byte)Status.InActive
                };
                Warehouse result = await repository.AddAsync(warehouse);
                model.Id = result.Id;
                if (result != null)
                {
                    return assignDataToWarehouseViewModel(result);
                }
            }
            catch (Exception e)
            {

            }
            return null;
        }
        public async Task<WarehouseViewModel> UpdateWarehouse(WarehouseViewModel model, ApplicationUser toekn)
        {
            try
            {
                Warehouse warehouse = await repository.GetAsync((int)model.Id);
                if (warehouse != null)
                {
                    warehouse.Name = model.Name;
                    warehouse.MobileNo = model.MobileNo;
                    warehouse.Email = model.Email;
                    warehouse.Address = model.Address;
                    warehouse.ContactPerson = model.ContactPerson;
                    warehouse.Description = model.Description;
                    warehouse.IsDefault = (bool)model.IsDefault;
                    warehouse.UpdatedBy = toekn.Id;
                    warehouse.UpdatedDate = DateTime.Now;
                    warehouse.Status = (byte)Status.Active;

                    Warehouse result = await repository.UpdateAsync(warehouse);
                    if (result != null)
                    {
                        return assignDataToWarehouseViewModel(result);
                    }
                }
            }
            catch (Exception e)
            {

            }
            return null;
        }
        public async Task<WarehouseViewModel> DeleteWarehouse(int id)
        {
            try
            {
                Warehouse Warehouse = await repository.GetAsync(id);
                if (Warehouse != null)
                {
                    Warehouse result = await repository.DeleteAsync(Warehouse);
                    if (result != null)
                    {
                        return assignDataToWarehouseViewModel(result);
                    }
                }
            }
            catch (Exception e)
            {

            }
            return null;
        }
        public async Task<WarehouseDetailsViewModel> GetDetails(int id)
        {
            try
            {
                Warehouse warehouse = await repository.GetAsync(id);
                if (warehouse != null)
                {
                    WarehouseDetailsViewModel WarehouseDetailsViewModel = new WarehouseDetailsViewModel()
                    {
                        Id = warehouse.Id,
                        WarehouseNo = warehouse.WarehouseNo,
                        Name = warehouse.Name,
                        MobileNo = warehouse.MobileNo,
                        Email = warehouse.Email,
                        Address = warehouse.Address,
                        ContactPerson = warehouse.ContactPerson,
                        Description = warehouse.Description,
                        IsDefault = warehouse.IsDefault,
                        CreatedByName = warehouse.CreatedBy != null ? userManger.FindByIdAsync(warehouse.CreatedBy).Result.UserName : null,
                        CreatedDateString = warehouse.CreatedDate != null ? Formater.FormatDateddMMyyyy((DateTime)warehouse.CreatedDate) : null,
                        UpdatedByName = warehouse.UpdatedBy != null ? userManger.FindByIdAsync(warehouse.UpdatedBy).Result.UserName : null,
                        UpdatedDateString = warehouse.UpdatedDate != null ? Formater.FormatDateddMMyyyy((DateTime)warehouse.UpdatedDate) : null,
                        Status = warehouse.Status
                    };
                    return WarehouseDetailsViewModel;
                }

            }
            catch (Exception e)
            {

            }
            return null;
        }
        public async Task<List<WarehouseDetailsViewModel>> GetTableData()
        {
            try
            {
                IEnumerable<Warehouse> warehouses = await repository.GetAsync();
                List<WarehouseDetailsViewModel> WarehouseDetailsViewModels = new List<WarehouseDetailsViewModel>();
                foreach (Warehouse warehouse in warehouses)
                {
                    WarehouseDetailsViewModel WarehouseDetailsViewModel = new WarehouseDetailsViewModel
                    {
                        Id = warehouse.Id,
                        WarehouseNo = warehouse.WarehouseNo,
                        Name = warehouse.Name,
                        MobileNo = warehouse.MobileNo,
                        Address = warehouse.Address,
                        ContactPerson = warehouse.ContactPerson,
                        Status = warehouse.Status
                    };
                    WarehouseDetailsViewModels.Add(WarehouseDetailsViewModel);
                }
                if (WarehouseDetailsViewModels != null)
                {
                    return WarehouseDetailsViewModels;
                }
            }
            catch (Exception e)
            {

            }
            return null;
        }
        public WarehouseViewModel assignDataToWarehouseViewModel(Warehouse warehouse)
        {
            WarehouseViewModel warehouseViewModel = new WarehouseViewModel
            {
                Id = warehouse.Id,
                OrganizationId = warehouse.OrganizationId,
                ShopId = warehouse.ShopId,
                WarehouseNo = warehouse.WarehouseNo,
                Name = warehouse.Name,
                MobileNo = warehouse.MobileNo,
                Email = warehouse.Email,
                Address = warehouse.Address,
                ContactPerson = warehouse.ContactPerson,
                Description = warehouse.Description,
                IsDefault = warehouse.IsDefault,
                CreatedBy = warehouse.CreatedBy,
                CreatedDate = warehouse.CreatedDate,
                UpdatedBy = warehouse.UpdatedBy,
                UpdatedDate = warehouse.UpdatedDate,
                Status = warehouse.Status,
            };
            return warehouseViewModel;
        }
    }
}
