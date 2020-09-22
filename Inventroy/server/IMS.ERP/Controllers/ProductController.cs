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
    public class ProductController : ControllerBase
    {
        private string message = "Sorry! Something going wrong. Please try again.";
        //private readonly IRepository<VAT> repository;
        private ApplicationUser toekn;
        private readonly UserManager<User> userManager;
        private ApplicationUser token;
        private ProductBLL  productBLL;
        public ProductController(IRepository<Product> repository, UserManager<User> userManager)
        {
            productBLL = new ProductBLL(repository, userManager);
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
                    ProductViewModel productViewModel = await productBLL.GetProduct(id);
                    if (productViewModel != null)
                    {
                        return Ok(new { status = 200, obj = productViewModel, message = "Product data retrive successfull." });
                    }
                }
                else
                {
                    IEnumerable<ProductViewModel> productViewModels = await productBLL.GetProducts();
                    if (productViewModels.Count() > 0)
                    {
                        return Ok(new { status = 200, obj = productViewModels, message = "Product data retrive successfull." });
                    }
                }
            }
            catch (Exception e)
            {

            }
            return BadRequest(new { status = 404, message = message });
        }
        [HttpPost]
        public async Task<ActionResult> Post(ProductViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    token = await TokenExtracter.ExtractTokenAsync(User, userManager);
                    ProductViewModel productViewModel = await productBLL.AddProduct(model, token);
                    if (productViewModel != null)
                    {
                        return Ok(new { status = 200, obj = productViewModel, message = "Prodcut created successfull." });
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
        public async Task<ActionResult> Put(ProductViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    token = await TokenExtracter.ExtractTokenAsync(User, userManager);
                    ProductViewModel productViewModel = await productBLL.UpdateProduct(model, token);
                    if (productViewModel != null)
                    {
                        return Ok(new { status = 200, obj = productViewModel, message = "Product updated successfully." });
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
                ProductViewModel productViewModel = await productBLL.DeleteProduct(id);
                if (productViewModel != null)
                {
                    return Ok(new { status = 200, obj = productViewModel, message = "Product Deleted successfull." });
                }
            }
            catch (Exception e)
            {

            }
            return BadRequest(new { status = 404, message = message });
        }
        [HttpGet]
        [Route("details/{id}")]
        public async Task<ActionResult> GetDetails(long id)
        {
            try
            {
                ProductViewModel productViewModel = await productBLL.GetDetails(id);
                if (productViewModel != null)
                {
                    return Ok(new { status = 200, obj = productViewModel, message = "Product details data retrive successfull." });
                }
            }
            catch (Exception e)
            {

            }
            return BadRequest(new { status = 404, message = message });
        }
        [HttpGet]
        [Route("tableData")]
        public async Task<ActionResult> GetTableData()
        {
            try
            {
                toekn = await TokenExtracter.ExtractTokenAsync(User, userManager);
                List<ProductViewModel> productViewModels = await productBLL.GetTableData();
                if (productViewModels != null)
                {
                    return Ok(new { status = 200, obj = productViewModels, message = "Product table data retrive successfull." });
                }
            }
            catch (Exception e)
            {

            }
            return BadRequest(new { status = 404, message = message });
        }
    }
}