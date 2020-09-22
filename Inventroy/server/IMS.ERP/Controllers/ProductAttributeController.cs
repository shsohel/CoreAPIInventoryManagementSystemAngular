using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AdminBLL;
using CommonBLL.Helper;
using CommonDAL.Models;
using CommonDAL.Repository;
using CommonDAL.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace IMSERP.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ProductAttributeController : ControllerBase
    {
        private string message = "Sorry! Something going wrong. Please try again.";
        private readonly IRepository<ProductAttributeMapping> repository;
        private ApplicationUser toekn;
        private readonly UserManager<User> userManager;
        private ApplicationUser token;
        private ProductAttributeBLL productAttributeBLL;
        public ProductAttributeController(IRepository<ProductAttributeMapping> repository, IRepository<ProductItem> proItemRepository, UserManager<User> userManager)
        {
            productAttributeBLL = new ProductAttributeBLL(repository, proItemRepository, userManager);
            this.userManager = userManager;
        }
        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult> Get(long id)
        {
            try
            {
                toekn = await TokenExtracter.ExtractTokenAsync(User, userManager);
                if (id > 0)
                {
                    List<ProductAttributeMappingViewModel> productAttributeMappingViews = await productAttributeBLL.GetProAttribyProductItemId(id);
                    if (productAttributeMappingViews != null)
                    {
                        return Ok(new { status = 200, obj = productAttributeMappingViews, message = "Product Attribute data retrive successfull." });
                    }
                }
                else
                {
                    IEnumerable<ProductAttributeMappingViewModel> productAttributeMappingViews = await productAttributeBLL.GetProductAttri();
                    if (productAttributeMappingViews.Count() > 0)
                    {
                        return Ok(new { status = 200, obj = productAttributeMappingViews, message = "Product Attribute retrive successfull." });
                    }
                }
            }
            catch (Exception e)
            {

            }
            return BadRequest(new { status = 404, message = message });
        }
        [HttpPost]
        public async Task<ActionResult> Post(ExtraProductMapingViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    token = await TokenExtracter.ExtractTokenAsync(User, userManager);
                    ExtraProductMapingViewModel productAttributeMappingViews = await productAttributeBLL.AddProductAttri(model, token);
                    if (productAttributeMappingViews != null)
                    {
                        return Ok(new { status = 200, obj = productAttributeMappingViews, message = "Product Attribute created successfull." });
                    }
                }
                else
                {
                    return BadRequest(new { status = 404, message = ModelState });
                }
            }
            catch (Exception e)
            {

            }
            return BadRequest(new { status = 404, message = message });
        }
        [HttpPut]
        public async Task<ActionResult> Put(ExtraProductMapingViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    token = await TokenExtracter.ExtractTokenAsync(User, userManager);
                    ExtraProductMapingViewModel productAttributeMappingViews = await productAttributeBLL.UpdateProductAttri(model, token);
                    if (productAttributeMappingViews != null)
                    {
                        return Ok(new { status = 200, obj = productAttributeMappingViews, message = "Product Attribute updated successfully." });
                    }
                }
                else
                {
                    return BadRequest(new { status = 404, message = ModelState });
                }
            }
            catch (Exception e)
            {

            }
            return BadRequest(new { status = 404, message = message });
        }
        [HttpDelete]
        [Route("delete/{id}")]
        public async Task<ActionResult> Delete(long id)
        {
            try
            {
               List< ProductAttributeMappingViewModel> productAttributeMappingViewModels = await productAttributeBLL.DeleteProductAttrValue(id);
                if (productAttributeMappingViewModels != null)
                {
                    return Ok(new { status = 200, obj = productAttributeMappingViewModels, message = "Product Attribute Deleted successfull." });
                }
            }
            catch (Exception e)
            {

            }
            return BadRequest(new { status = 404, message = message });
        }
        //[HttpGet]
        //[Route("details/{id}")]
        //public async Task<ActionResult> GetDetails(long id)
        //{
        //    try
        //    {
        //        EmployeeViewModel employeeViewModel = await employeeBLL.GetDetails(id);
        //        if (employeeViewModel != null)
        //        {
        //            return Ok(new { status = 200, obj = employeeViewModel, message = "Employee details data retrive successfull." });
        //        }
        //    }
        //    catch (Exception e)
        //    {

        //    }
        //    return BadRequest(new { status = 404, message = message });
        //}
        //[HttpGet]
        //[Route("tableData")]
        //[Authorize]
        //public async Task<ActionResult> GetTableData()
        //{
        //    try
        //    {
        //        toekn = await TokenExtracter.ExtractTokenAsync(User, userManager);
        //        List<EmployeeViewModel> employeeViewModels = await employeeBLL.GetTableData();
        //        if (employeeViewModels != null)
        //        {
        //            return Ok(new { status = 200, obj = employeeViewModels, message = "Employee table data retrive successfull." });
        //        }
        //    }
        //    catch (Exception e)
        //    {

        //    }
        //    return BadRequest(new { status = 404, message = message });
        //}
    }
}