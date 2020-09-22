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
  public  class ProductionBLL
    {
        private readonly IRepository<Production> productionRepository;
        private readonly UserManager<User> userManager;
        public ProductionBLL(IRepository<Production> productionRepository, UserManager<User> userManager)
        {
            this.productionRepository = productionRepository;
            this.userManager = userManager;
        }
        public async Task<IEnumerable<ProductionViewModel>> GetProductions()
        {
            try
            {
                IEnumerable<Production> productions = await productionRepository.GetAsync();
                List<ProductionViewModel> productionViewModels = new List<ProductionViewModel>();
                if (productions != null)
                {
                    foreach (Production production in productions)
                    {
                        productionViewModels.Add(assignDataToProductionViewModel(production));
                    }
                    return productionViewModels;
                }
            }
            catch (Exception e)
            {

            }
            return null;
        }
        public async Task<ProductionViewModel> GetProduction(long id)
        {
            try
            {
                Production production = await productionRepository.GetAsync(id);
                if (production != null)
                {
                    return assignDataToProductionViewModel(production);
                }
            }
            catch (Exception e)
            {
                e.Message.Contains("Something Wrong");
            }
            return null;
        }
        public async Task<ProductionViewModel> AddProduction(ProductionViewModel model, ApplicationUser token)
        {
            try
            {
                Production production = new Production
                {
                    Name = model.Name,
                    ProductionNo = DateTime.Now.ToString("ddMMyyhhmmssmmm"),
                    StartDate=model.StartDate,
                    Batch=model.Batch,
                    ExpiredDate=model.ExpiredDate,
                    BatchCode=model.BatchCode,
                    OtherCostTotal=model.OtherCostTotal,
                    Note=model.Note,
                    RawProductCostTotal=model.RawProductCostTotal,
                    CreatedBy = token.Id,
                    OrganizationId = token.OrganizationId,
                    ShopId = token.ShopId,
                    CreatedDate = DateTime.Now,
                    Status = (byte)Status.Active
                };
                Production result = await productionRepository.AddAsync(production);
                model.Id = result.Id;
                if (result != null)
                {
                    return assignDataToProductionViewModel(result);
                }
            }
            catch (Exception e)
            {

            }
            return null;
        }
        public async Task<ProductionViewModel> UpdateProduction(ProductionViewModel model, ApplicationUser token)
        {
            try
            {
                Production production = await productionRepository.GetAsync(model.Id);
                if (production != null)
                {
                    production.Name = model.Name;
                    production.StartDate = model.StartDate;
                    production.Batch = model.Batch;
                    production.ExpiredDate = model.ExpiredDate;
                    production.BatchCode = model.BatchCode;
                    production.OtherCostTotal = model.OtherCostTotal;
                    production.Note = model.Note;
                    production.RawProductCostTotal = model.RawProductCostTotal;
                    production.ModifiedBy = token.Id;
                    production.ModifiedDate = DateTime.Now;

                    Production result = await productionRepository.UpdateAsync(production);
                    if (result != null)
                    {
                        return assignDataToProductionViewModel(result);
                    }
                }
            }
            catch (Exception e)
            {

            }
            return null;
        }
        public async Task<ProductionViewModel> DeleteProduction(long id)
        {
            try
            {
                Production production = await productionRepository.GetAsync(id);
                if (production != null)
                {
                    Production result = await productionRepository.DeleteAsync(production);
                    if (result != null)
                    {
                        return assignDataToProductionViewModel(result);
                    }
                }
            }
            catch (Exception e)
            {

            }
            return null;
        }
        public async Task<ProductionDetailsViewModel> GetDetails(long id)
        {
            try
            {
                Production production = await productionRepository.GetAsync(id);
                if (production != null)
                {
                    ProductionDetailsViewModel productDetailsViewModel = new ProductionDetailsViewModel
                    {
                        CreatedByName = production.CreatedBy != null ? userManager.FindByIdAsync(production.CreatedBy).Result.UserName : null,
                        CreatedDateString = production.CreatedDate != null ? Formater.FormatDateddMMyyyy((DateTime)production.CreatedDate) : null,
                        ModifiedByName = production.ModifiedBy != null ? userManager.FindByIdAsync(production.ModifiedBy).Result.UserName : null,
                        ModifiedDateString = production.ModifiedDate != null ? Formater.FormatDateddMMyyyy((DateTime)production.ModifiedDate) : null,
                        StartDateString= production.StartDate != null ? Formater.FormatDateddMMyyyy((DateTime)production.StartDate) : null,
                        ExpiredDateString= production.ExpiredDate != null ? Formater.FormatDateddMMyyyy((DateTime)production.ExpiredDate) : null,
                        Batch=production.Batch,
                        BatchCode=production.BatchCode,
                        OtherCostTotal=production.OtherCostTotal,
                        ProductionNo=production.ProductionNo,
                        Note=production.Note,
                        RawProductCostTotal=production.RawProductCostTotal,                       
                        Name = production.Name,
                        OrganizationId = production.OrganizationId,
                        ShopId = production.ShopId,
                        Status = production.Status,
                    };
                    return productDetailsViewModel;
                }
            }
            catch (Exception e)
            {

            }
            return null;
        }
        public async Task<List<ProductionDetailsViewModel>> GetTableData()
        {
            try
            {
                IEnumerable<Production> productions = await productionRepository.GetAsync();
                List<ProductionDetailsViewModel> productionViewModels = new List<ProductionDetailsViewModel>();
                foreach (Production production in productions)
                {
                    ProductionDetailsViewModel productDetailsViewModel = new ProductionDetailsViewModel
                    {
                        Id = production.Id,
                        ProductionNo = production.ProductionNo,
                        Batch=production.Batch,
                        BatchCode=production.BatchCode,
                        Name = production.Name,
                        StartDateString = Formater.FormatDateddMMyyyy(Convert.ToDateTime(production.StartDate)),
                        ExpiredDateString = Formater.FormatDateddMMyyyy(Convert.ToDateTime(production.ExpiredDate)),
                        Status = (byte)production.Status
                    };
                    productionViewModels.Add(productDetailsViewModel);
                }
                if (productionViewModels != null)
                {
                    return productionViewModels;
                }
            }
            catch (Exception e)
            {

            }
            return null;
        }
        public ProductionViewModel assignDataToProductionViewModel(Production production)
        {
            ProductionViewModel productionViewModel = new ProductionViewModel
            {
                Id = production.Id,
                Name = production.Name,
                OrganizationId = production.OrganizationId,
                ShopId = production.ShopId,
                Batch = production.Batch,
                BatchCode = production.BatchCode,
                ExpiredDate = Convert.ToDateTime(production.ExpiredDate),
                Note = production.Note,
                ProductionNo = production.ProductionNo,
                OtherCostTotal = production.OtherCostTotal,
                RawProductCostTotal = production.RawProductCostTotal,
                StartDate = Convert.ToDateTime(production.StartDate),
                CreatedBy = production.CreatedBy,
                CreatedDate = Convert.ToDateTime(production.CreatedDate),
                ModifiedBy = production.ModifiedBy,
                ModifiedDate = Convert.ToDateTime(production.ModifiedDate),
                Status = (byte)production.Status
            };
            return productionViewModel;
        }
    }
}