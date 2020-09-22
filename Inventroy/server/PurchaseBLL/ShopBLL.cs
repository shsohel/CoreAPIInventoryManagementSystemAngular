using CommonBLL.Enums;
using CommonBLL.Helper;
using CommonDAL.Models;
using CommonDAL.Repository;
using CommonDAL.ViewModels;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PurchaseBLL
{
    public class ShopBLL
    {
        private readonly IRepository<Shop> repository;
        private readonly UserManager<User> userManger;

        public ShopBLL(IRepository<Shop> repository, UserManager<User> userManger)
        {
            this.repository = repository;
            this.userManger = userManger;
        }
        public async Task<IEnumerable<ShopViewModel>> GetShops()
        {
            try
            {
                IEnumerable<Shop> shops = await repository.GetAsync();
                List<ShopViewModel> shopViewModels = new List<ShopViewModel>();
                if (shops != null)
                {
                    foreach (Shop shop in shops)
                    {
                        shopViewModels.Add(assignDataToShopViewModel(shop));
                    }
                    return shopViewModels;
                }
            }
            catch (Exception e)
            {

            }
            return null;
        }
        public async Task<ShopViewModel> GetShop(int id)
        {
            try
            {
                Shop shop = await repository.GetAsync(id);
                if (shop != null)
                {
                    return assignDataToShopViewModel(shop);
                }
            }
            catch (Exception e)
            {

            }
            return null;
        }
        public async Task<ShopViewModel> AddShop(ShopViewModel model, ApplicationUser token)
        {
            try
            {
                Shop shop = new Shop
                {
                    OrganizationId = token.OrganizationId,
                    Code = DateTime.Now.ToString("ddMMyyhhmmssmmm"),
                    Name = model.Name,
                    Designation = model.Designation,
                    Owner = token.UserName,
                    Address1 = model.Address1,
                    Address2 = model.Address2,
                    Phone = model.Phone,
                    VatRegNo = model.VatRegNo,
                    EmailForSystemGeneratedMail = model.EmailForSystemGeneratedMail,
                    PasswordForSystemGeneratedMail = model.PasswordForSystemGeneratedMail,
                    CreatedBy = token.Id,
                    CreatedDate = DateTime.Now,
                    Status = (byte)Status.InActive
                };
                Shop result = await repository.AddAsync(shop);
                model.Id = result.Id;
                if (result != null)
                {
                    return assignDataToShopViewModel(result);
                }
            }
            catch (Exception e)
            {

            }
            return null;
        }
        public async Task<ShopViewModel> UpdateShop(ShopViewModel model, ApplicationUser toekn)
        {
            try
            {
                Shop shop = await repository.GetAsync((int)model.Id);
                if (shop != null)
                {
                    shop.Name = model.Name;
                    shop.Designation = model.Designation;
                    shop.Address1 = model.Address1;
                    shop.Address2 = model.Address2;
                    shop.Phone = model.Phone;
                    shop.VatRegNo = model.VatRegNo;
                    shop.EmailForSystemGeneratedMail = model.EmailForSystemGeneratedMail;
                    shop.PasswordForSystemGeneratedMail = model.PasswordForSystemGeneratedMail;
                    shop.ModifiedBy = toekn.Id;
                    shop.ModifiedDate = DateTime.Now;
                    shop.Status = (byte)Status.Active;
                    Shop result = await repository.UpdateAsync(shop);
                    if (result != null)
                    {
                        return assignDataToShopViewModel(result);
                    }
                }
            }
            catch (Exception e)
            {

            }
            return null;
        }
        public async Task<ShopViewModel> DeleteShop(int id)
        {
            try
            {
                Shop shop = await repository.GetAsync(id);
                if (shop != null)
                {
                    Shop result = await repository.DeleteAsync(shop);
                    if (result != null)
                    {
                        return assignDataToShopViewModel(result);
                    }
                }
            }
            catch (Exception e)
            {

            }
            return null;
        }
        public async Task<ShopDetailsViewModel> GetDetails(int id)
        {
            try
            {
                Shop shop = await repository.GetAsync(id);
                if (shop != null)
                {
                    ShopDetailsViewModel shopDetailsViewModel = new ShopDetailsViewModel()
                    {
                        Id = shop.Id,
                        Code = shop.Code,
                        Name = shop.Name,
                        Designation = shop.Designation,
                        Owner = shop.Owner,
                        Address1 = shop.Address1,
                        Address2 = shop.Address2,                        
                        Phone = shop.Phone,
                        VatRegNo = shop.VatRegNo,
                        EmailForSystemGeneratedMail = shop.EmailForSystemGeneratedMail,
                        PasswordForSystemGeneratedMail = shop.PasswordForSystemGeneratedMail,
                        ModifiedByName = shop.ModifiedBy != null ? userManger.FindByIdAsync(shop.ModifiedBy).Result.UserName : null,
                        CreatedByName = shop.CreatedBy != null ? userManger.FindByIdAsync(shop.CreatedBy).Result.UserName : null,
                        ModifiedDateString = shop.ModifiedDate != null ? Formater.FormatDateddMMyyyy((DateTime)shop.ModifiedDate) : null,
                        CreatedDateString = shop.CreatedDate != null ? Formater.FormatDateddMMyyyy((DateTime)shop.CreatedDate) : null,
                        Status = shop.Status
                    };
                    return shopDetailsViewModel;
                }

            }
            catch (Exception e)
            {

            }
            return null;
        }
        public async Task<List<ShopDetailsViewModel>> GetTableData()
        {
            try
            {
                IEnumerable<Shop> shops = await repository.GetAsync();
                List<ShopDetailsViewModel> shopDetailsViewModels = new List<ShopDetailsViewModel>();
                foreach (Shop shop in shops)
                {
                    ShopDetailsViewModel shopDetailsViewModel = new ShopDetailsViewModel
                    {
                        Id = shop.Id,
                        Code = shop.Code,
                        Name = shop.Name,
                        Designation = shop.Designation,
                        Address1 = shop.Address1,
                        Phone = shop.Phone,
                        Status = shop.Status
                    };
                    shopDetailsViewModels.Add(shopDetailsViewModel);
                }
                if (shopDetailsViewModels != null)
                {
                    return shopDetailsViewModels;
                }
            }
            catch (Exception e)
            {

            }
            return null;
        }
        public ShopViewModel assignDataToShopViewModel(Shop shop)
        {
            ShopViewModel shopViewModel = new ShopViewModel
            {
                Id = shop.Id,
                OrganizationId = shop.OrganizationId,
                Name = shop.Name,
                Code = shop.Code,
                Address1 = shop.Address1,
                Address2 = shop.Address2,
                Designation = shop.Designation,
                Phone = shop.Phone,
                Owner = shop.Owner,
                VatRegNo = shop.VatRegNo,
                EmailForSystemGeneratedMail = shop.EmailForSystemGeneratedMail,
                PasswordForSystemGeneratedMail = shop.PasswordForSystemGeneratedMail,
                CreatedBy = shop.CreatedBy,
                CreatedDate = shop.CreatedDate,
                ModifiedBy = shop.ModifiedBy,
                ModifiedDate = shop.ModifiedDate,
                Status = shop.Status,
            };
            return shopViewModel;
        }
    }
}
