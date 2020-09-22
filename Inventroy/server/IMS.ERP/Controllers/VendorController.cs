using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AdminBLL;
using CommonBLL.Helper;
using CommonDAL.Models;
using CommonDAL.Repository;
using CommonDAL.ViewModels;
using FinanceBLL;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace IMSERP.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class VendorController : ControllerBase
    {
        private string message = "Sorry! Something going wrong. Please try again.";
        private readonly IRepository<Vendor> repository;
        private readonly UserManager<User> userManager;
        private ExternalPersonBLL exPerson;
        private VendorBLL vendorBLL;
        private ApplicationUser token;
        public VendorController(IRepository<Vendor> repository, UserManager<User> userManager, IRepository<ExternalPerson> exPerson)
        {
            vendorBLL = new VendorBLL(repository, userManager, exPerson);
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
                    VendorViewModel vendorViewModel = await vendorBLL.GetVendor(id);
                    if (vendorViewModel != null)
                    {
                        return Ok(new { status = 200, obj = vendorViewModel, message = "Vendor data retrive successfull." });
                    }
                }
                else
                {
                    IEnumerable<VendorViewModel> vendorViewModels = await vendorBLL.GetVendors();
                    if (vendorViewModels.Count() > 0)
                    {
                        return Ok(new { status = 200, obj = vendorViewModels, message = "Vendor data retrive successfull." });
                    }
                }
            }
            catch (Exception e)
            {

            }
            return BadRequest(new { status = 404, message = message });
        }
        [HttpPost]
        public async Task<ActionResult> Post(VendorViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    token = await TokenExtracter.ExtractTokenAsync(User, userManager);
                    VendorViewModel vendorViewModel = await vendorBLL.AddVendor(model, token);
                    if (vendorViewModel != null)
                    {
                        return Ok(new { status = 200, obj = vendorViewModel, message = "Vendor created successfull." });
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
        public async Task<ActionResult> Put(VendorViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    token = await TokenExtracter.ExtractTokenAsync(User, userManager);
                    VendorViewModel vendorViewModel = await vendorBLL.UpdateVendor(model, token);
                    if (vendorViewModel != null)
                    {
                        return Ok(new { status = 200, obj = vendorViewModel, message = "Vendor updated successfull." });
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
                VendorViewModel vendorViewModel = await vendorBLL.DeleteVendor(id);
                if (vendorViewModel != null)
                {
                    return Ok(new { status = 200, obj = vendorViewModel, message = "Vendor Deleted successfull." });
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
                VendorViewModel vendorViewModel = await vendorBLL.GetDetails(id);
                if (vendorViewModel != null)
                {
                    return Ok(new { status = 200, obj = vendorViewModel, message = "Vendor details data retrive successfull." });
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
                List<VedorDetailsViewModel> vedorDetailsViewModel = await vendorBLL.GetTableData();
                if (vedorDetailsViewModel != null)
                {
                    return Ok(new { status = 200, obj = vedorDetailsViewModel, message = "Vendor table data retrive successfull." });
                }
            }
            catch (Exception e)
            {

            }
            return BadRequest(new { status = 404, message = message });
        }
    }
}