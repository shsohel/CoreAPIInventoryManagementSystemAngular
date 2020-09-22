using CommonBLL.Enums;
using CommonBLL.Helper;
using CommonDAL.Models;
using CommonDAL.Repository;
using CommonDAL.ViewModels;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdminBLL
{
  public  class ProductItemBLL
    {
        private readonly IRepository<ProductItem> repository;
        private readonly IRepository<Manufacturer> manuRepository;
        private readonly IRepository<Product> productRepository;
        private readonly UserManager<User> userManager;
        private readonly IRepository<Unit> unitRepository;
        private readonly IRepository<Category> categoryRepository;
        private readonly IRepository<VAT> vatRepository;
        private readonly IRepository<ProductAttributeMapping> proAttriRepository;

        public ProductItemBLL(IRepository<ProductItem> repository, IRepository<Manufacturer> manuRepository, IRepository<Product> productRepository, UserManager<User> userManager,
            IRepository<Unit> unitRepository, IRepository<Category> categoryRepository, IRepository<VAT> vatRepository, IRepository<ProductAttributeMapping> proAttriRepository)
        {
            this.repository = repository;
            this.manuRepository = manuRepository;
            this.productRepository = productRepository;
            this.userManager = userManager;
            this.unitRepository = unitRepository;
            this.categoryRepository = categoryRepository;
            this.vatRepository = vatRepository;
            this.proAttriRepository = proAttriRepository;
        }
        public async Task<IEnumerable<ProductItemViewModel>> GetProductItems()
        {
            try
            {
                IEnumerable<ProductItem> productItems = await repository.GetAsync();
                List<ProductItemViewModel> productItemViewModels = new List<ProductItemViewModel>();
                if (productItems != null)
                {
                    foreach (ProductItem productItem in productItems)
                    {
                        productItemViewModels.Add(assignDataToProductItemViewModel(productItem));
                    }
                    return productItemViewModels;
                }
            }
            catch (Exception e)
            {

            }
            return null;
        }
        public async Task<ProductItemViewModel> GetProductItem(long id)
        {
            try
            {
                ProductItem productItem = await repository.GetAsync(id);
                if (productItem != null)
                {
                    return assignDataToProductItemViewModel(productItem);
                }
            }
            catch (Exception e)
            {
                e.Message.Contains("Something Wrong");
            }
            return null;
        }
        public async Task<ProductItemViewModel> AddProductItem(ProductItemViewModel model, ApplicationUser token)
        {
            try
            {
                ProductItem productItem = new ProductItem
                {
                    ProductItemNo = DateTime.Now.ToString("ddMMyyhhmmssmmm"),
                    CategoryId = model.CategoryId,
                    BarCode=model.BarCode,
                    IsSerialProduct=model.IsSerialProduct,
                    ManufacturerId=model.ManufacturerId,
                    ProductId=model.ProductId,
                    Sku=model.Sku,
                    ProductType=model.ProductType,
                    UnitId=model.UnitId,
                    VATId=model.VATId,
                    CreatedBy = token.Id,
                    OrganizationId = token.OrganizationId,
                    ShopId = token.ShopId,
                    CreatedDate = DateTime.Now,
                    Status = (byte)Status.Active
                };
                ProductItem result = await repository.AddAsync(productItem);
                model.Id = result.Id;
                if (result != null)
                {
                    return assignDataToProductItemViewModel(result);
                }
            }
            catch (Exception e)
            {

            }
            return null;
        }
        public async Task<ProductItemViewModel> UpdateProductItem(ProductItemViewModel model, ApplicationUser token)
        {
            try
            {
                ProductItem productItem = await repository.GetAsync(model.Id);
                if (productItem != null)
                {
                    productItem.CategoryId = model.CategoryId;
                    productItem.BarCode = model.BarCode;
                    productItem.IsSerialProduct = model.IsSerialProduct;
                    productItem.ManufacturerId = model.ManufacturerId;
                    productItem.ProductId = model.ProductId;
                    productItem.Sku = model.Sku;
                    productItem.ProductType = model.ProductType;
                    productItem.UnitId = model.UnitId;
                    productItem.VATId = model.VATId;
                    productItem.ModifiedBy = token.Id;
                    productItem.ModifiedDate = DateTime.Now;
                    ProductItem result = await repository.UpdateAsync(productItem);
                    if (result != null)
                    {
                        return assignDataToProductItemViewModel(result);
                    }
                }
            }
            catch (Exception e)
            {

            }
            return null;
        }
        public async Task<ProductItemViewModel> DeleteProductItem(long id)
        {
            try
            {
                ProductItem productItem = await repository.GetAsync(id);
                if (productItem != null)
                {
                    ProductItem result = await repository.DeleteAsync(productItem);
                    if (result != null)
                    {
                        return assignDataToProductItemViewModel(result);
                    }
                }
            }
            catch (Exception e)
            {

            }
            return null;
        }
        public async Task<ProductItemViewModel> GetDetails(long id)
        {
            try
            {
                ProductItem productItem = await repository.GetAsync(id);
                if (productItem != null)
                {
                    ProductItemDetailsViewModel productItemDetails = new ProductItemDetailsViewModel
                    {
                        IsSerialProduct= productItem.IsSerialProduct,
                        CreatedByName = productItem.CreatedBy != null ? userManager.FindByIdAsync(productItem.CreatedBy).Result.UserName : null,
                        CreatedDateString = productItem.CreatedDate != null ? Formater.FormatDateddMMyyyy((DateTime)productItem.CreatedDate) : null,
                        ModifiedByName = productItem.ModifiedBy != null ? userManager.FindByIdAsync(productItem.ModifiedBy).Result.UserName : null,
                        ModifiedDateString = productItem.ModifiedDate != null ? Formater.FormatDateddMMyyyy((DateTime)productItem.ModifiedDate) : null,
                        ProductName = productItem.ProductId != null ? productRepository.GetAsync((long)productItem.ProductId).Result.Name : null,
                        ManufacturerName = productItem.ManufacturerId != null ? manuRepository.GetAsync((long)productItem.ManufacturerId).Result.Name : null,
                        UnitName = productItem.UnitId != null ? unitRepository.GetAsync(productItem.UnitId).Result.Name : null,
                        CategoryName = productItem.CategoryId != null ? categoryRepository.GetAsync(productItem.CategoryId).Result.Name : null,
                        VatName=productItem.VATId != null ? vatRepository.GetAsync((long)productItem.VATId).Result.Name : null,
                        CategoryId = productItem.CategoryId,
                        OrganizationId = productItem.OrganizationId,
                        ShopId = productItem.ShopId,
                        ManufacturerId=productItem.ManufacturerId,
                        ProductId=productItem.ProductId,
                        BarCode=productItem.BarCode,
                        ProductItemNo=productItem.ProductItemNo,
                        ProductType=productItem.ProductType,
                        VATId=productItem.VATId,
                        Sku=productItem.Sku,                       
                        UnitId=productItem.UnitId,
                        Status = productItem.Status,
                    };
                    return productItemDetails;                    
                }
                //IEnumerable<ProductAttributeMapping> productAttributes = await proAttriRepository.GetAsync();
                //List<ProductAttributeMapping> productAttributeMappings = productAttributes.Where(x => x.ProductItemId == id).ToList();
                //List<ProductAttributeMappingViewModel> mappingViewModels = new List<ProductAttributeMappingViewModel>();
                //if (productAttributeMappings.Count > 0)
                //{
                //    foreach(ProductAttributeMapping productAttribute in productAttributeMappings)
                //    {
                //        ProductAttributeMappingViewModel model = new ProductAttributeMappingViewModel
                //        {
                //            PriceAdjustment=productAttribute.PriceAdjustment,
                //            SequenceNo=productAttribute.SequenceNo,
                //            SpecificationAttrId=productAttribute.SpecificationAttrId,
                //            SpecificationAttrValueId=productAttribute.SpecificationAttrValueId,
                //            WeightAdjustment=productAttribute.WeightAdjustment
                //        };
                //        mappingViewModels.Add(model);
                //      //  return mappingViewModels;
                //    }
                //}
            }
            catch (Exception e)
            {

            }
            return null;
        }
        public async Task<List<ProductItemDetailsViewModel>> GetTableData()
        {
            try
            {
                IEnumerable<ProductItem> productItems = await repository.GetAsync();
                List<ProductItemDetailsViewModel> productItemViewModels = new List<ProductItemDetailsViewModel>();
                foreach (ProductItem productItem in productItems)
                {
                    ProductItemDetailsViewModel productDetailsViewModel = new ProductItemDetailsViewModel
                    {
                        Id = productItem.Id,
                        ProductItemNo= productItem.ProductItemNo,
                        ProductId=productItem.ProductId,
                        ManufacturerId=productItem.ManufacturerId,
                        ProductName=productItem.ProductId != null ? productRepository.GetAsync((long)productItem.ProductId).Result.Name : null,
                        ManufacturerName = productItem.ManufacturerId != null ? manuRepository.GetAsync((long)productItem.ManufacturerId).Result.Name : null,
                        UnitName = productItem.UnitId != null ? unitRepository.GetAsync(productItem.UnitId).Result.Name : null,
                        CategoryName = productItem.CategoryId != null ? categoryRepository.GetAsync(productItem.CategoryId).Result.Name : null,
                        CategoryId = productItem.CategoryId,
                        ProductType=productItem.ProductType,
                        UnitId= productItem.UnitId,
                        Status = (byte)productItem.Status
                    };
                    productItemViewModels.Add(productDetailsViewModel);
                }
                if (productItemViewModels != null)
                {
                    return productItemViewModels;
                }
            }
            catch (Exception e)
            {

            }
            return null;
        }
        public ProductItemViewModel assignDataToProductItemViewModel(ProductItem productItem)
        {
            ProductItemViewModel productItemViewModel = new ProductItemViewModel
            {
                Id = productItem.Id,
                CategoryId = productItem.CategoryId,
                OrganizationId = productItem.OrganizationId,
                ShopId = productItem.ShopId,
                BarCode=productItem.BarCode,
                IsSerialProduct=productItem.IsSerialProduct,
                ManufacturerId=productItem.ManufacturerId,
                ProductId=productItem.ProductId,
                ProductItemNo=productItem.ProductItemNo,
                ProductType=productItem.ProductType,
                Sku=productItem.Sku,
                UnitId=productItem.UnitId,
                VATId=productItem.VATId,
                CreatedBy = productItem.CreatedBy,
                CreatedDate = Convert.ToDateTime(productItem.CreatedDate),
                ModifiedBy = productItem.ModifiedBy,
                ModifiedDate = Convert.ToDateTime(productItem.ModifiedDate),
                Status = (byte)productItem.Status
            };
            return productItemViewModel;
        }
    }
}
