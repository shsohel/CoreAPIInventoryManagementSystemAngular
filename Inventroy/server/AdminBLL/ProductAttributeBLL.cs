using CommonBLL.Enums;
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
    public class ProductAttributeBLL
    {
        private readonly IRepository<ProductAttributeMapping> repository;
        private readonly IRepository<ProductItem> proItemRepository;
        private readonly UserManager<User> userManager;

        public ProductAttributeBLL(IRepository<ProductAttributeMapping> repository, IRepository<ProductItem> proItemRepository, UserManager<User> userManager)
        {
            this.repository = repository;
            this.proItemRepository = proItemRepository;
            this.userManager = userManager;
        }
        public async Task<IEnumerable<ProductAttributeMappingViewModel>> GetProductAttri()
        {
            try
            {
                IEnumerable<ProductAttributeMapping> productAttributes = await repository.GetAsync();
                List<ProductAttributeMappingViewModel> attributeMappingViewModels = new List<ProductAttributeMappingViewModel>();
                if (productAttributes != null)
                {
                    foreach (ProductAttributeMapping productAttribute in productAttributes)
                    {
                        attributeMappingViewModels.Add(assignDataToProdAttriViewModel(productAttribute));
                    }
                    return attributeMappingViewModels;
                }
            }
            catch (Exception e)
            {

            }
            return null;
        }
        public async Task<List<ProductAttributeMappingViewModel>> GetProAttribyProductItemId(long id)
        {
            try
            {
                ProductItem productItem = await proItemRepository.GetAsync(id);
                IEnumerable<ProductAttributeMapping> productAttributeMappings = await repository.GetAsync();
                List<ProductAttributeMapping> filteredProductItems = productAttributeMappings.Where(x => x.ProductItemId == productItem.Id).ToList();
                if (filteredProductItems != null)
                {
                    List<ProductAttributeMappingViewModel> attributeMappingViewModels = new List<ProductAttributeMappingViewModel>();
                    foreach (ProductAttributeMapping productAttribute in filteredProductItems)
                    {
                        attributeMappingViewModels.Add(assignDataToProdAttriViewModel(productAttribute));
                    }
                    return attributeMappingViewModels;
                }
            }
            catch (Exception e)
            {
                e.Message.Contains("Something Wrong");
            }
            return null;
        }
        public async Task<ExtraProductMapingViewModel> AddProductAttri(ExtraProductMapingViewModel models, ApplicationUser token)
        {
            try
            {
                List<ProductAttributeMapping> productAttributeMappings = new List<ProductAttributeMapping>();
                foreach (ProductAttributeMappingViewModel model in models.MappingViewModels)
                {
                    ProductAttributeMapping productAttribute = new ProductAttributeMapping
                    {
                        CreatedBy = token.Id,
                        OrganizationId = token.OrganizationId,
                        PriceAdjustment = model.PriceAdjustment,
                        ProductItemId = model.ProductItemId,
                        SequenceNo = model.SequenceNo,
                        ShopId = token.ShopId,
                        SpecificationAttrId = model.SpecificationAttrId,
                        SpecificationAttrValueId = model.SpecificationAttrValueId,
                        WeightAdjustment = model.WeightAdjustment,
                        CreatedDate = DateTime.Now,
                        Status = (byte)Status.Active
                    };
                    productAttributeMappings.Add(productAttribute);
                }
                List<ProductAttributeMapping> result = await repository.AddRangeAsync(productAttributeMappings);
                //  models.ToArray() = result.Id;
                if (result.Count > 0)
                {
                    ExtraProductMapingViewModel extraProductMapingView = new ExtraProductMapingViewModel();
                    foreach (ProductAttributeMapping productAttribute in result)
                    {
                        var data = assignDataToProdAttriViewModel(productAttribute);
                        extraProductMapingView.MappingViewModels.Add(data);
                    }
                    return extraProductMapingView;
                }
            }
            catch (Exception e)
            {

            }
            return null;
        }
        public async Task<ExtraProductMapingViewModel> UpdateProductAttri(ExtraProductMapingViewModel models, ApplicationUser token)
        {
            try
            {
                if (models != null)
                {
                    IEnumerable<ProductAttributeMapping> productAttributeMappings = await repository.GetAsync();
                    List<ProductAttributeMapping> filterProductAttri = productAttributeMappings
                        .Where(x => x.ProductItemId == models.MappingViewModels[0].ProductItemId).ToList();
                    List<ProductAttributeMapping> deletedProductAttri = new List<ProductAttributeMapping>();
                    if (filterProductAttri.Count > 0)
                    {
                        foreach (ProductAttributeMapping productAttribute in filterProductAttri)
                        {
                            var resutl = models.MappingViewModels.Where(x => x.Id == productAttribute.Id).FirstOrDefault();
                            if (resutl == null)
                            {
                                deletedProductAttri.Add(productAttribute);
                            }
                        }
                        if (deletedProductAttri.Count > 0)
                        {
                            List<ProductAttributeMapping> deletedResult = await repository.DeleteRangeAsync(deletedProductAttri);
                        }
                    }
                    List<ProductAttributeMapping> updateProductAttris = new List<ProductAttributeMapping>();
                    List<ProductAttributeMapping> addProductAttris = new List<ProductAttributeMapping>();
                    foreach (ProductAttributeMappingViewModel model in models.MappingViewModels)
                    {
                        if (model.Id > 0)
                        {
                            ProductAttributeMapping productAttribute = repository.GetAsync(model.Id).Result;
                            if (productAttribute != null)
                            {
                                productAttribute.PriceAdjustment = model.PriceAdjustment;
                                productAttribute.SequenceNo = model.SequenceNo;
                                productAttribute.SpecificationAttrId = model.SpecificationAttrId;
                                productAttribute.SpecificationAttrValueId = model.SpecificationAttrValueId;
                                productAttribute.WeightAdjustment = model.WeightAdjustment;
                                productAttribute.ModifiedDate = DateTime.Now;
                                productAttribute.ModifiedBy = token.Id;
                            }
                            updateProductAttris.Add(productAttribute);
                        }
                        else
                        {
                            ProductAttributeMapping productAttribute = new ProductAttributeMapping
                            {
                                CreatedBy = token.Id,
                                OrganizationId = token.OrganizationId,
                                PriceAdjustment = model.PriceAdjustment,
                                ProductItemId = model.ProductItemId,
                                SequenceNo = model.SequenceNo,
                                ShopId = token.ShopId,
                                SpecificationAttrId = model.SpecificationAttrId,
                                SpecificationAttrValueId = model.SpecificationAttrValueId,
                                WeightAdjustment = model.WeightAdjustment,
                                CreatedDate = DateTime.Now,
                                Status = (byte)Status.Active
                            };
                            addProductAttris.Add(productAttribute);
                        }
                    };
                    List<ProductAttributeMapping> updateResult = await repository.UpdateRangeAsync(updateProductAttris);
                    if (addProductAttris.Count > 0)
                    {
                        List<ProductAttributeMapping> addResult = await repository.AddRangeAsync(addProductAttris);
                    }
                    if (updateResult.Count > 0)
                    {
                        ExtraProductMapingViewModel productMapingViewModels = new ExtraProductMapingViewModel();
                        foreach (ProductAttributeMapping productAttribute in updateResult)
                        {
                            var data = assignDataToProdAttriViewModel(productAttribute);
                            productMapingViewModels.MappingViewModels.Add(data);
                        }
                        return productMapingViewModels;
                    }
                };
            }
            catch (Exception e)
            {

            }
            return null;
        }
        public async Task<List<ProductAttributeMappingViewModel>> DeleteProductAttrValue(long id)
        {
            try
            {
                ProductItem productItem = await proItemRepository.GetAsync(id);
                IEnumerable<ProductAttributeMapping> productAttributeMappings = await repository.GetAsync();
                List<ProductAttributeMapping> filteredProductAttrValues = productAttributeMappings.Where(x => x.ProductItemId == productItem.Id).ToList();
                if (filteredProductAttrValues.Count > 0)
                {
                    List<ProductAttributeMapping> result = await repository.DeleteRangeAsync(filteredProductAttrValues);
                    List<ProductAttributeMappingViewModel> ProductAttrValues = new List<ProductAttributeMappingViewModel>();
                    if (result != null)
                    {
                        foreach (ProductAttributeMapping productAttributeMapping in result)
                        {
                            var data = assignDataToProdAttriViewModel(productAttributeMapping);
                            ProductAttrValues.Add(data);
                        }
                        return ProductAttrValues;
                    }
                }
            }
            catch (Exception e)
            {
            }
            return null;
        }
        //public async Task<EmployeeViewModel> GetDetails(long id)
        //{
        //    try
        //    {
        //        Employee employee = await repository.GetAsync(id);
        //        if (employee != null)
        //        {
        //            EmployeeViewModel employeeViewModel = new EmployeeViewModel
        //            {
        //                Id = employee.Id,
        //                ShopId = employee.ShopId,
        //                Name = employee.Name,
        //                Phone = employee.Phone,
        //                Mobile = employee.Mobile,
        //                //   Address = employee.Address,
        //                Designation = employee.Designation,
        //                EmployeeNo = employee.EmployeeNo,
        //                Email = employee.Email,
        //                IsOwner = employee.IsOwner,
        //                /// Picture = employee.Picture,
        //                // CreatedBy = employee.CreatedBy,
        //                CreatedDate = Convert.ToDateTime(employee.CreatedDate),
        //                // ModifiedBy = employee.ModifiedBy,
        //                ModifiedDate = Convert.ToDateTime(employee.ModifiedDate),
        //                Status = (byte)employee.Status
        //            };
        //            return employeeViewModel;
        //        }
        //    }
        //    catch (Exception e)
        //    {

        //    }
        //    return null;
        //}
        //public async Task<List<EmployeeViewModel>> GetTableData()
        //{
        //    try
        //    {
        //        IEnumerable<Employee> employees = await repository.GetAsync();
        //        List<EmployeeViewModel> employeeViewModels = new List<EmployeeViewModel>();
        //        foreach (Employee employee in employees)
        //        {
        //            EmployeeViewModel employeeViewModel = new EmployeeViewModel
        //            {
        //                Id = employee.Id,
        //                ShopId = employee.ShopId,
        //                Name = employee.Name,
        //                Phone = employee.Phone,
        //                Mobile = employee.Mobile,
        //                ///   Address = employee.Address,
        //                Designation = employee.Designation,
        //                EmployeeNo = employee.EmployeeNo,
        //                Email = employee.Email,
        //                IsOwner = employee.IsOwner,
        //                //   Picture = employee.Picture,
        //                //    CreatedBy = employee.CreatedBy,
        //                CreatedDate = Convert.ToDateTime(employee.CreatedDate),
        //                //  ModifiedBy = employee.ModifiedBy,
        //                ModifiedDate = Convert.ToDateTime(employee.ModifiedDate),
        //                Status = (byte)employee.Status
        //            };
        //            employeeViewModels.Add(employeeViewModel);
        //        }
        //        if (employeeViewModels != null)
        //        {
        //            return employeeViewModels;
        //        }
        //    }
        //    catch (Exception e)
        //    {

        //    }
        //    return null;
        //}
        public ProductAttributeMappingViewModel assignDataToProdAttriViewModel(ProductAttributeMapping productAttribute)
        {
            ProductAttributeMappingViewModel attributeMappingViewModel = new ProductAttributeMappingViewModel
            {
                Id = productAttribute.Id,
                CreatedBy= productAttribute.CreatedBy,
                OrganizationId= productAttribute.OrganizationId,
                PriceAdjustment= productAttribute.PriceAdjustment,
                ProductItemId= productAttribute.ProductItemId,
                SequenceNo=productAttribute.SequenceNo,
                ShopId=productAttribute.ShopId,
                SpecificationAttrId= productAttribute.SpecificationAttrId,
                SpecificationAttrValueId= productAttribute.SpecificationAttrValueId,
                WeightAdjustment= productAttribute.WeightAdjustment,
                CreatedDate = Convert.ToDateTime(productAttribute.CreatedDate),
                ModifiedBy = productAttribute.ModifiedBy,
                ModifiedDate = Convert.ToDateTime(productAttribute.ModifiedDate),
                Status = (byte)productAttribute.Status
            };
            return attributeMappingViewModel;
        }
    }
}
