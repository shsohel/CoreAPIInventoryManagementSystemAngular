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

namespace AdminBLL
{
    public class ManufacturerBLL
    {
        private readonly IRepository<Manufacturer> repository;
        private readonly UserManager<User> userManager;

        public ManufacturerBLL(IRepository<Manufacturer> repository, UserManager<User> userManager)
        {
            this.repository = repository;
            this.userManager = userManager;
        }
        public async Task<IEnumerable<ManufacturerViewModel>> GetManufacturers()
        {
            try
            {
                IEnumerable<Manufacturer> manufacturers = await repository.GetAsync();
                List<ManufacturerViewModel> manufacturerViewModels = new List<ManufacturerViewModel>();
                if (manufacturers != null)
                {
                    foreach (Manufacturer manufacturer in manufacturers)
                    {
                        manufacturerViewModels.Add(assignDataToManufacturerViewModel(manufacturer));
                    }
                    return manufacturerViewModels;
                }
            }
            catch (Exception e)
            {

            }
            return null;
        }
        public async Task<ManufacturerViewModel> GetManufacturer(long id)
        {
            try
            {
                Manufacturer manufacturer = await repository.GetAsync(id);
                if (manufacturer != null)
                {
                    return assignDataToManufacturerViewModel(manufacturer);
                }
            }
            catch (Exception e)
            {
                e.Message.Contains("Something Wrong");
            }
            return null;
        }
        public async Task<ManufacturerViewModel> AddManufacturer(ManufacturerViewModel model, ApplicationUser token)
        {
            try
            {
                Manufacturer manufacturer = new Manufacturer
                {
                    ManufacturerNo = DateTime.Now.ToString("ddMMyyhhmmssmmm"),
                    Description = model.Description,
                    Name = model.Name,
                    OrganizationId = token.OrganizationId,
                    ShopId = token.ShopId,
                    CreatedBy = token.Id,
                    CreatedDate = DateTime.Now,
                    Status = (byte)Status.Active
                };
                Manufacturer result = await repository.AddAsync(manufacturer);
                model.Id = result.Id;
                if (result != null)
                {
                    return assignDataToManufacturerViewModel(result);
                }
            }
            catch (Exception e)
            {

            }
            return null;
        }
        public async Task<ManufacturerViewModel> UpdateManufacturer(ManufacturerViewModel model, ApplicationUser token)
        {
            try
            {
                Manufacturer manufacturer = await repository.GetAsync(model.Id);
                if (manufacturer != null)
                {
                    manufacturer.Name = model.Name;
                    manufacturer.Description = model.Description;
                    manufacturer.ModifiedBy = token.Id;
                    manufacturer.ModifiedDate = DateTime.Now;
                    Manufacturer result = await repository.UpdateAsync(manufacturer);
                    if (result != null)
                    {
                        return assignDataToManufacturerViewModel(result);
                    }
                }
            }
            catch (Exception e)
            {

            }
            return null;
        }
        public async Task<ManufacturerViewModel> DeleteManufacturer(long id)
        {
            try
            {
                Manufacturer manufacturer = await repository.GetAsync(id);
                if (manufacturer != null)
                {
                    Manufacturer result = await repository.DeleteAsync(manufacturer);
                    if (result != null)
                    {
                        return assignDataToManufacturerViewModel(result);
                    }
                }
            }
            catch (Exception e)
            {

            }
            return null;
        }
        public async Task<ManufacturerViewModel> GetDetails(long id)
        {
            try
            {
                Manufacturer manufacturer = await repository.GetAsync(id);
                if (manufacturer != null)
                {
                    ManufacturerDetailsViewModel manufacturerDetailsViewModel = new ManufacturerDetailsViewModel
                    {
                        Description = manufacturer.Description,
                        CreatedByName = manufacturer.CreatedBy != null ? userManager.FindByIdAsync(manufacturer.CreatedBy).Result.UserName : null,
                        CreatedDateString = manufacturer.CreatedDate != null ? Formater.FormatDateddMMyyyy((DateTime)manufacturer.CreatedDate) : null,
                        ModifiedByName = manufacturer.ModifiedBy != null ? userManager.FindByIdAsync(manufacturer.ModifiedBy).Result.UserName : null,
                        ModifiedDateString = manufacturer.ModifiedDate != null ? Formater.FormatDateddMMyyyy((DateTime)manufacturer.ModifiedDate) : null,
                        Name = manufacturer.Name,
                        ManufacturerNo = manufacturer.ManufacturerNo,
                        OrganizationId = manufacturer.OrganizationId,
                        ShopId = manufacturer.ShopId,
                        Status = manufacturer.Status,
                    };
                    return manufacturerDetailsViewModel;
                }
            }
            catch (Exception e)
            {

            }
            return null;
        }
        public async Task<List<ManufacturerViewModel>> GetTableData()
        {
            try
            {
                IEnumerable<Manufacturer> manufacturers = await repository.GetAsync();
                List<ManufacturerViewModel> manufacturerViewModels = new List<ManufacturerViewModel>();
                foreach (Manufacturer manufacturer in manufacturers)
                {
                    ManufacturerViewModel productDetailsViewModel = new ManufacturerViewModel
                    {
                        Id = manufacturer.Id,
                        ManufacturerNo = manufacturer.ManufacturerNo,
                        OrganizationId = manufacturer.OrganizationId,
                        ShopId = manufacturer.ShopId,
                        Description = manufacturer.Description,
                        Name = manufacturer.Name,
                        Status = (byte)manufacturer.Status
                    };
                    manufacturerViewModels.Add(productDetailsViewModel);
                }
                if (manufacturerViewModels != null)
                {
                    return manufacturerViewModels;
                }
            }
            catch (Exception e)
            {

            }
            return null;
        }
        public ManufacturerViewModel assignDataToManufacturerViewModel(Manufacturer manufacturer)
        {
            ManufacturerViewModel manufacturerViewModel = new ManufacturerViewModel
            {
                Id = manufacturer.Id,
                Description = manufacturer.Description,
                Name = manufacturer.Name,
                ManufacturerNo = manufacturer.ManufacturerNo,
                OrganizationId = manufacturer.OrganizationId,
                ShopId = manufacturer.ShopId,
                CreatedBy = manufacturer.CreatedBy,
                CreatedDate = Convert.ToDateTime(manufacturer.CreatedDate),
                ModifiedBy = manufacturer.ModifiedBy,
                ModifiedDate = Convert.ToDateTime(manufacturer.ModifiedDate),
                Status = (byte)manufacturer.Status
            };
            return manufacturerViewModel;
        }
    }
}
