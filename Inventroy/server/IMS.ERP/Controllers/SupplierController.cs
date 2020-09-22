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
    public class SupplierController : ControllerBase
    {
        private string message = "Sorry! Something going wrong. Please try again.";
        private readonly IRepository<Supplier> repository;
        private readonly UserManager<User> userManager;
        private SupplierBLL supplierBLL;
        private ApplicationUser token;
        public SupplierController(IRepository<Supplier> repository, UserManager<User> userManager)
        {
            supplierBLL = new SupplierBLL(repository, userManager);
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
                    SupplierViewModel supplierViewModel = await supplierBLL.GetSupplier(id);
                    if (supplierViewModel != null)
                    {
                        return Ok(new { status = 200, obj = supplierViewModel, message = "Supplier data retrive successfull." });
                    }
                }
                else
                {
                    IEnumerable<SupplierViewModel> supplierViewModels = await supplierBLL.GetSuppliers();
                    if (supplierViewModels.Count() > 0)
                    {
                        return Ok(new { status = 200, obj = supplierViewModels, message = "Supplier data retrive successfull." });
                    }
                }
            }
            catch (Exception e)
            {

            }
            return BadRequest(new { status = 404, message = message });
        }
        [HttpPost]
        public async Task<ActionResult> Post(SupplierViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    token = await TokenExtracter.ExtractTokenAsync(User, userManager);
                    SupplierViewModel supplierViewModel = await supplierBLL.AddSupplier(model, token);
                    if (supplierViewModel != null)
                    {
                        return Ok(new { status = 200, obj = supplierViewModel, message = "Supplier created successfull." });
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
        public async Task<ActionResult> Put(SupplierViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    token = await TokenExtracter.ExtractTokenAsync(User, userManager);
                    SupplierViewModel supplierViewModel = await supplierBLL.UpdateSupplier(model, token);
                    if (supplierViewModel != null)
                    {
                        return Ok(new { status = 200, obj = supplierViewModel, message = "Supplier updated successfull." });
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
                SupplierViewModel supplierViewModel = await supplierBLL.DeleteSupplier(id);
                if (supplierViewModel != null)
                {
                    return Ok(new { status = 200, obj = supplierViewModel, message = "Supplier Deleted successfull." });
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
                SupplierDetailsViewModel supplierDetailsViewModel = await supplierBLL.GetDetails(id);
                if (supplierDetailsViewModel != null)
                {
                    return Ok(new { status = 200, obj = supplierDetailsViewModel, message = "Supplier details data retrive successfull." });
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
                List<SupplierDetailsViewModel> supplierDetailsViewModel = await supplierBLL.GetTableData();
                if (supplierDetailsViewModel != null)
                {
                    return Ok(new { status = 200, obj = supplierDetailsViewModel, message = "Supplier table data retrive successfull." });
                }
            }
            catch (Exception e)
            {

            }
            return BadRequest(new { status = 404, message = message });
        }
    }
}