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
    public class ProductionController : ControllerBase
    {
        private string message = "Sorry! Something going wrong. Please try again.";
        private ApplicationUser toekn;
        private readonly UserManager<User> userManager;
        private ApplicationUser token;
        private ProductionBLL productionBLL;
        public ProductionController(IRepository<Production> productionRepository, UserManager<User> userManager)
        {
            productionBLL = new ProductionBLL(productionRepository, userManager);
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
                    ProductionViewModel productionViewModel = await productionBLL.GetProduction(id);
                    if (productionViewModel != null)
                    {
                        return Ok(new { status = 200, obj = productionViewModel, message = "Production data retrive successfull." });
                    }
                }
                else
                {
                    IEnumerable<ProductionViewModel> productionViewModels = await productionBLL.GetProductions();
                    if (productionViewModels.Count() > 0)
                    {
                        return Ok(new { status = 200, obj = productionViewModels, message = "Production data retrive successfull." });
                    }
                }
            }
            catch (Exception e)
            {

            }
            return BadRequest(new { status = 404, message = message });
        }
        [HttpPost]
        public async Task<ActionResult> Post(ProductionViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    token = await TokenExtracter.ExtractTokenAsync(User, userManager);
                    ProductionViewModel productionViewModel = await productionBLL.AddProduction(model, token);
                    if (productionViewModel != null)
                    {
                        return Ok(new { status = 200, obj = productionViewModel, message = "Prodcution created successfull." });
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
        public async Task<ActionResult> Put(ProductionViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    token = await TokenExtracter.ExtractTokenAsync(User, userManager);
                    ProductionViewModel productionViewModel = await productionBLL.UpdateProduction(model, token);
                    if (productionViewModel != null)
                    {
                        return Ok(new { status = 200, obj = productionViewModel, message = "Production updated successfully." });
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
                ProductionViewModel productionViewModel = await productionBLL.DeleteProduction(id);
                if (productionViewModel != null)
                {
                    return Ok(new { status = 200, obj = productionViewModel, message = "Production Deleted successfull." });
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
                ProductionDetailsViewModel productionDetailsViewModel = await productionBLL.GetDetails(id);
                if (productionDetailsViewModel != null)
                {
                    return Ok(new { status = 200, obj = productionDetailsViewModel, message = "Production details data retrive successfull." });
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
                List<ProductionDetailsViewModel> productionViewModels = await productionBLL.GetTableData();
                if (productionViewModels != null)
                {
                    return Ok(new { status = 200, obj = productionViewModels, message = "Production table data retrive successfull." });
                }
            }
            catch (Exception e)
            {

            }
            return BadRequest(new { status = 404, message = message });
        }
    }
}
