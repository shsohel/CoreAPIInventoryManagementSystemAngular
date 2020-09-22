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
   public class ProductBLL
    {
        private readonly IRepository<Product> repository;
        private readonly UserManager<User> userManager;

        public ProductBLL(IRepository<Product> repository, UserManager<User> userManager)
        {
            this.repository = repository;
            this.userManager = userManager;
        }
        public async Task<IEnumerable<ProductViewModel>> GetProducts()
        {
            try
            {
                IEnumerable<Product> products = await repository.GetAsync();
                List<ProductViewModel> productViewModels = new List<ProductViewModel>();
                if (products != null)
                {
                    foreach (Product product in products)
                    {
                        productViewModels.Add(assignDataToProductViewModel(product));
                    }
                    return productViewModels;
                }
            }
            catch (Exception e)
            {

            }
            return null;
        }
        public async Task<ProductViewModel> GetProduct(long id)
        {
            try
            {
                Product product = await repository.GetAsync(id);
                if (product != null)
                {
                    return assignDataToProductViewModel(product);
                }
            }
            catch (Exception e)
            {
                e.Message.Contains("Something Wrong");
            }
            return null;
        }
        public async Task<ProductViewModel> AddProduct(ProductViewModel model, ApplicationUser token)
        {
            try
            {
                Product product = new Product
                {
                    Name = model.Name,
                    ProductNo = DateTime.Now.ToString("ddMMyyhhmmssmmm"),
                    Description = model.Description,
                    CategoryId=model.CategoryId,
                    CreatedBy=token.Id,                  
                    OrganizationId = token.OrganizationId,
                    ShopId = token.ShopId,
                    CreatedDate = DateTime.Now,
                    Status = (byte)Status.Active
                };
                Product result = await repository.AddAsync(product);
                model.Id = result.Id;
                if (result != null)
                {
                    return assignDataToProductViewModel(result);
                }
            }
            catch (Exception e)
            {

            }
            return null;
        }
        public async Task<ProductViewModel> UpdateProduct(ProductViewModel model, ApplicationUser token)
        {
            try
            {
                Product product = await repository.GetAsync(model.Id);
                if (product != null)
                {
                    product.Name = model.Name;
                    product.Description = model.Description;
                    product.CategoryId = model.CategoryId;
                    product.ModifiedBy = token.Id;
                    product.ModifiedDate = DateTime.Now;
                    Product result = await repository.UpdateAsync(product);
                    if (result != null)
                    {
                        return assignDataToProductViewModel(result);
                    }
                }
            }
            catch (Exception e)
            {

            }
            return null;
        }
        public async Task<ProductViewModel> DeleteProduct(long id)
        {
            try
            {
                Product product = await repository.GetAsync(id);
                if (product != null)
                {
                    Product result = await repository.DeleteAsync(product);
                    if (result != null)
                    {
                        return assignDataToProductViewModel(result);
                    }
                }
            }
            catch (Exception e)
            {

            }
            return null;
        }
        public async Task<ProductViewModel> GetDetails(long id)
        {
            try
            {
                Product product = await repository.GetAsync(id);
                if (product != null)
                {
                    ProductDetailsViewModel productDetailsViewModel = new ProductDetailsViewModel
                    {
                        ProductNo = product.ProductNo,
                        Description = product.Description,
                        CreatedByName = product.CreatedBy != null ? userManager.FindByIdAsync(product.CreatedBy).Result.UserName : null,
                        CreatedDateString = product.CreatedDate != null ? Formater.FormatDateddMMyyyy((DateTime)product.CreatedDate) : null,
                        ModifiedByName = product.ModifiedBy != null ? userManager.FindByIdAsync(product.ModifiedBy).Result.UserName : null,
                        ModifiedDateString = product.ModifiedDate != null ? Formater.FormatDateddMMyyyy((DateTime)product.ModifiedDate) : null,
                        Name = product.Name,
                        CategoryId=product.CategoryId,
                        OrganizationId = product.OrganizationId,
                        ShopId = product.ShopId,
                        Status = product.Status,
                    };
                    return productDetailsViewModel;
                }
            }
            catch (Exception e)
            {

            }
            return null;
        }
        public async Task<List<ProductViewModel>> GetTableData()
        {
            try
            {
                IEnumerable<Product> products = await repository.GetAsync();
                List<ProductViewModel> productViewModels = new List<ProductViewModel>();
                foreach (Product product in products)
                {
                    ProductViewModel productDetailsViewModel = new ProductViewModel
                    {
                        Id = product.Id,
                        ProductNo=product.ProductNo,
                        CategoryId=product.CategoryId,
                        OrganizationId = product.OrganizationId,
                        ShopId = product.ShopId,
                        Description = product.Description,
                        Name = product.Name,
                        Status = (byte)product.Status
                    };
                    productViewModels.Add(productDetailsViewModel);
                }
                if (productViewModels != null)
                {
                    return productViewModels;
                }
            }
            catch (Exception e)
            {

            }
            return null;
        }
        public ProductViewModel assignDataToProductViewModel(Product  product)
        {
            ProductViewModel productViewModel = new ProductViewModel
            {
                Id = product.Id,
                CategoryId=product.CategoryId,
                Description=product.Description,
                Name=product.Name,
                OrganizationId=product.OrganizationId,
                ProductNo=product.ProductNo,
                ShopId=product.ShopId,
                CreatedBy = product.CreatedBy,
                CreatedDate = Convert.ToDateTime(product.CreatedDate),
                ModifiedBy = product.ModifiedBy,
                ModifiedDate = Convert.ToDateTime(product.ModifiedDate),
                Status = (byte)product.Status
            };
            return productViewModel;
        }
    }
}