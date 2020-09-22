using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CommonBLL.Helper;
using CommonDAL.Models;
using CommonDAL.Repository;
using CommonDAL.ViewModels;
using FinanceBLL;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace IMSERP.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class VATController : ControllerBase
    {
        private string message = "Sorry! Something going wrong. Please try again.";
        //private readonly IRepository<VAT> repository;
        private ApplicationUser toekn;
        private readonly UserManager<User> userManager;
        private ApplicationUser token;
        private VATBLL vATBLL;
        public VATController(IRepository<VAT> repository, UserManager<User> userManager)
        {
            vATBLL = new VATBLL(repository, userManager);
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
                    VATViewModel vATViewModel = await vATBLL.GetVAT(id);
                    if (vATViewModel != null)
                    {
                        return Ok(new { status = 200, obj = vATViewModel, message = "VAT data retrive successfull." });
                    }
                }
                else
                {
                    IEnumerable<VATViewModel> vATViewModels = await vATBLL.GetVATs();
                    if (vATViewModels.Count() > 0)
                    {
                        return Ok(new { status = 200, obj = vATViewModels, message = "VAT data retrive successfull." });
                    }
                }
            }
            catch (Exception e)
            {

            }
            return BadRequest(new { status = 404, message = message });
        }
        [HttpPost]
        public async Task<ActionResult> Post(VATViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    token = await TokenExtracter.ExtractTokenAsync(User, userManager);
                    VATViewModel vATViewModel = await vATBLL.AddVAT(model, token);
                    if (vATViewModel != null)
                    {
                        return Ok(new { status = 200, obj = vATViewModel, message = "VAT created successfull." });
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
        public async Task<ActionResult> Put(VATViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    token = await TokenExtracter.ExtractTokenAsync(User, userManager);
                    VATViewModel vATViewModel = await vATBLL.UpdateVAT(model, token);
                    if (vATViewModel != null)
                    {
                        return Ok(new { status = 200, obj = vATViewModel, message = "VAT updated successfully." });
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
                VATViewModel vATViewModel = await vATBLL.DeleteVAT(id);
                if (vATViewModel != null)
                {
                    return Ok(new { status = 200, obj = vATViewModel, message = "VAT Deleted successfull." });
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
                VATViewModel vATViewModel = await vATBLL.GetDetails(id);
                if (vATViewModel != null)
                {
                    return Ok(new { status = 200, obj = vATViewModel, message = "VAT details data retrive successfull." });
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
                List<VATViewModel> vATViewModels = await vATBLL.GetTableData();
                if (vATViewModels != null)
                {
                    return Ok(new { status = 200, obj = vATViewModels, message = "VAT table data retrive successfull." });
                }
            }
            catch (Exception e)
            {

            }
            return BadRequest(new { status = 404, message = message });
        }
    }
}