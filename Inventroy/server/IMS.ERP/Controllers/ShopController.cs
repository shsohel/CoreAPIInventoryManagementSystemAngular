using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CommonBLL.Helper;
using CommonDAL.Models;
using CommonDAL.Repository;
using CommonDAL.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using PurchaseBLL;

namespace IMSERP.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ShopController : ControllerBase
    {
        private string message = "Sorry! Something going wrong. Please try again.";
        private readonly IRepository<Shop> repository;
        private readonly UserManager<User> userManager;
        private ShopBLL shopBLL;
        private ApplicationUser token;
        public ShopController(IRepository<Shop> repository, UserManager<User> userManager)
        {
            shopBLL = new ShopBLL(repository, userManager);
            this.userManager = userManager;
        }
        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult> Get(int id)
        {
            try
            {
                token = await TokenExtracter.ExtractTokenAsync(User, userManager);
                if (id > 0)
                {
                    ShopViewModel shopViewModel = await shopBLL.GetShop(id);
                    if (shopViewModel != null)
                    {
                        return Ok(new { status = 200, obj = shopViewModel, message = "Shop data retrive successfull." });
                    }
                }
                else
                {
                    IEnumerable<ShopViewModel> shopViewModels = await shopBLL.GetShops();
                    if (shopViewModels.Count() > 0)
                    {
                        return Ok(new { status = 200, obj = shopViewModels, message = "Shop data retrive successfull." });
                    }
                }
            }
            catch (Exception e)
            {

            }
            return BadRequest(new { status = 404, message = message });
        }
        [HttpPost]
        public async Task<ActionResult> Post(ShopViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    token = await TokenExtracter.ExtractTokenAsync(User, userManager);
                    ShopViewModel shopViewModel = await shopBLL.AddShop(model, token);
                    if (shopViewModel != null)
                    {
                        return Ok(new { status = 200, obj = shopViewModel, message = "Shop created successfull." });
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
        public async Task<ActionResult> Put(ShopViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    token = await TokenExtracter.ExtractTokenAsync(User, userManager);
                    ShopViewModel shopViewModel = await shopBLL.UpdateShop(model, token);
                    if (shopViewModel != null)
                    {
                        return Ok(new { status = 200, obj = shopViewModel, message = "Shop updated successfull." });
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
        [Route("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            try
            {
                token = await TokenExtracter.ExtractTokenAsync(User, userManager);
                ShopViewModel shopViewModel = await shopBLL.DeleteShop(id);
                if (shopViewModel != null)
                {
                    return Ok(new { status = 200, obj = shopViewModel, message = "Shop Deleted successfull." });
                }
            }
            catch (Exception e)
            {

            }
            return BadRequest(new { status = 404, message = message });
        }
        [HttpGet]
        [Route("details/{id}")]
        public async Task<ActionResult> GetDetails(int id)
        {
            try
            {
                token = await TokenExtracter.ExtractTokenAsync(User, userManager);
                ShopDetailsViewModel shopDetailsViewModel = await shopBLL.GetDetails(id);
                if (shopDetailsViewModel != null)
                {
                    return Ok(new { status = 200, obj = shopDetailsViewModel, message = "Shop details data retrive successfull." });
                }
            }
            catch (Exception e)
            {

            }
            return BadRequest(new { status = 404, message = message });
        }
        [HttpGet]
        [Route("tableData")]
        [Authorize]
        public async Task<ActionResult> GetTableData()
        {
            try
            {
                token = await TokenExtracter.ExtractTokenAsync(User, userManager);
                List<ShopDetailsViewModel> shopDetailsViewModel = await shopBLL.GetTableData();
                if (shopDetailsViewModel != null)
                {
                    return Ok(new { status = 200, obj = shopDetailsViewModel, message = "Shop table data retrive successfull." });
                }
            }
            catch (Exception e)
            {

            }
            return BadRequest(new { status = 404, message = message });
        }
    }
}