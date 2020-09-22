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
    public class PurchaseController : ControllerBase
    {
        private string message = "Sorry! Something going wrong. Please try again.";
        private readonly IRepository<Purchase> repository;
        private readonly UserManager<User> userManager;
        private PurchasesBLL purchasesBLL;
        private ApplicationUser token;
        public PurchaseController(IRepository<Purchase> repository, UserManager<User> userManager, IRepository<Employee> empRepository, IRepository<Supplier> supRepository)
        {
            purchasesBLL = new PurchasesBLL(repository, userManager, supRepository, empRepository);
            this.userManager = userManager;
        }
        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult> Get(long id)
        {
            try
            {
                token = await TokenExtracter.ExtractTokenAsync(User, userManager);
                if (id > 0)
                {
                    PurchaseViewModel purchaseViewModel = await purchasesBLL.GetPurchase(id);
                    if (purchaseViewModel != null)
                    {
                        return Ok(new { status = 200, obj = purchaseViewModel, message = "Purchase data retrive successfull." });
                    }
                }
                else
                {
                    IEnumerable<PurchaseViewModel> purchaseViewModels = await purchasesBLL.GetPurchases();
                    if (purchaseViewModels.Count() > 0)
                    {
                        return Ok(new { status = 200, obj = purchaseViewModels, message = "Purchase data retrive successfull." });
                    }
                }
            }
            catch (Exception e)
            {

            }
            return BadRequest(new { status = 404, message = message });
        }
        [HttpPost]
        public async Task<ActionResult> Post(PurchaseViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    token = await TokenExtracter.ExtractTokenAsync(User, userManager);
                    PurchaseViewModel purchaseViewModel = await purchasesBLL.AddPurchase(model, token);
                    if (purchaseViewModel != null)
                    {
                        return Ok(new { status = 200, obj = purchaseViewModel, message = "Purchase created successfull." });
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
        public async Task<ActionResult> Put(PurchaseViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    token = await TokenExtracter.ExtractTokenAsync(User, userManager);
                    PurchaseViewModel purchaseViewModel = await purchasesBLL.UpdatePurchase(model, token);
                    if (purchaseViewModel != null)
                    {
                        return Ok(new { status = 200, obj = purchaseViewModel, message = "Purchase updated successfull." });
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
        public async Task<ActionResult> Delete(long id)
        {
            try
            {
                token = await TokenExtracter.ExtractTokenAsync(User, userManager);
                PurchaseViewModel purchaseViewModel = await purchasesBLL.DeletePurchase(id);
                if (purchaseViewModel != null)
                {
                    return Ok(new { status = 200, obj = purchaseViewModel, message = "Purchase Deleted successfull." });
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
                token = await TokenExtracter.ExtractTokenAsync(User, userManager);
                PurchaseDetailsViewModel purchaseDetailsViewModel = await purchasesBLL.GetDetails(id);
                if (purchaseDetailsViewModel != null)
                {
                    return Ok(new { status = 200, obj = purchaseDetailsViewModel, message = "Purchase details data retrive successfull." });
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
                List<PurchaseDetailsViewModel> purchaseDetailsViewModel = await purchasesBLL.GetTableData();
                if (purchaseDetailsViewModel != null)
                {
                    return Ok(new { status = 200, obj = purchaseDetailsViewModel, message = "Vendor table data retrive successfull." });
                }
            }
            catch (Exception e)
            {

            }
            return BadRequest(new { status = 404, message = message });
        }
    }
}