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
    public class ProductItemController : ControllerBase
    {
        private string message = "Sorry! Something going wrong. Please try again.";
        private ApplicationUser toekn;
        private readonly UserManager<User> userManager;
        private ApplicationUser token;
        private ProductItemBLL productItemBLL;
        public ProductItemController(IRepository<ProductItem> repository, IRepository<Manufacturer> manuRepository, IRepository<Product> productRepository, UserManager<User> userManager,
            IRepository<Unit> unitRepository, IRepository<Category> categoryRepository, IRepository<VAT> vatRepository, IRepository<ProductAttributeMapping> proAttriRepository)
        {
            productItemBLL = new ProductItemBLL(repository, manuRepository, productRepository, userManager, unitRepository, categoryRepository, vatRepository, proAttriRepository);
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
                    ProductItemViewModel productItemViewModel = await productItemBLL.GetProductItem(id);
                    if (productItemViewModel != null)
                    {
                        return Ok(new { status = 200, obj = productItemViewModel, message = "Product Item data retrive successfull." });
                    }
                }
                else
                {
                    IEnumerable<ProductItemViewModel> productItemViewModels = await productItemBLL.GetProductItems();
                    if (productItemViewModels.Count() > 0)
                    {
                        return Ok(new { status = 200, obj = productItemViewModels, message = "Product Item data retrive successfull." });
                    }
                }
            }
            catch (Exception e)
            {

            }
            return BadRequest(new { status = 404, message = message });
        }
        [HttpPost]
        public async Task<ActionResult> Post(ProductItemViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    token = await TokenExtracter.ExtractTokenAsync(User, userManager);
                    ProductItemViewModel productItemViewModel = await productItemBLL.AddProductItem(model, token);
                    if (productItemViewModel != null)
                    {
                        return Ok(new { status = 200, obj = productItemViewModel, message = "Product Item created successfull." });
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
        public async Task<ActionResult> Put(ProductItemViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    token = await TokenExtracter.ExtractTokenAsync(User, userManager);
                    ProductItemViewModel productItemViewModel = await productItemBLL.UpdateProductItem(model, token);
                    if (productItemViewModel != null)
                    {
                        return Ok(new { status = 200, obj = productItemViewModel, message = "Product Item updated successfully." });
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
                ProductItemViewModel productItemViewModel = await productItemBLL.DeleteProductItem(id);
                if (productItemViewModel != null)
                {
                    return Ok(new { status = 200, obj = productItemViewModel, message = "Product Item Deleted successfull." });
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
                ProductItemViewModel productItemViewModel = await productItemBLL.GetDetails(id);
                if (productItemViewModel != null)
                {
                    return Ok(new { status = 200, obj = productItemViewModel, message = "Product Item details data retrive successfull." });
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
                List<ProductItemDetailsViewModel> productItemViewModels = await productItemBLL.GetTableData();
                if (productItemViewModels != null)
                {
                    return Ok(new { status = 200, obj = productItemViewModels, message = "Product Item table data retrive successfull." });
                }
            }
            catch (Exception e)
            {

            }
            return BadRequest(new { status = 404, message = message });
        }
    }
}