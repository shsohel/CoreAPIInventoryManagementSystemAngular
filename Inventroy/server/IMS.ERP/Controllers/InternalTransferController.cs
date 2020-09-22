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
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace IMSERP.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class InternalTransferController : ControllerBase
    {
        private string message = "Sorry! Something going wrong. Please try again.";
        private readonly IRepository<InternalTransfer> repository;
        private readonly UserManager<User> userManager;
        private InternalTransferBLL internalTransferBLL;
        private ApplicationUser token;
        public InternalTransferController(IRepository<InternalTransfer> repository, UserManager<User> userManager)
        {
            internalTransferBLL = new InternalTransferBLL(repository, userManager);
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
                    InternalTransferViewModel internalTransferViewModel = await internalTransferBLL.GetInternalTransfer(id);
                    if (internalTransferViewModel != null)
                    {
                        return Ok(new { status = 200, obj = internalTransferViewModel, message = "Internal Transfer data retrive successfull." });
                    }
                }
                else
                {
                    IEnumerable<InternalTransferViewModel> internalTransferViewModels = await internalTransferBLL.GetInternalTransfers();
                    if (internalTransferViewModels.Count() > 0)
                    {
                        return Ok(new { status = 200, obj = internalTransferViewModels, message = "Internal Transfer data retrive successfull." });
                    }
                }
            }
            catch (Exception e)
            {

            }
            return BadRequest(new { status = 404, message = message });
        }
        [HttpPost]
        public async Task<ActionResult> Post(InternalTransferViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    token = await TokenExtracter.ExtractTokenAsync(User, userManager);
                    InternalTransferViewModel internalTransferViewModel = await internalTransferBLL.AddInternalTransfer(model, token);
                    if (internalTransferViewModel != null)
                    {
                        return Ok(new { status = 200, obj = internalTransferViewModel, message = "Internal Transfer created successfull." });
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
        public async Task<ActionResult> Put(InternalTransferViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    token = await TokenExtracter.ExtractTokenAsync(User, userManager);
                    InternalTransferViewModel internalTransferViewModel = await internalTransferBLL.UpdateInternalTransfer(model , token);
                    if (internalTransferViewModel != null)
                    {
                        return Ok(new { status = 200, obj = internalTransferViewModel, message = "Internal Transfer updated successfull." });
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
                InternalTransferViewModel internalTransferViewModel = await internalTransferBLL.DeleteInternalTransfer(id);
                if (internalTransferViewModel != null)
                {
                    return Ok(new { status = 200, obj = internalTransferViewModel, message = "Internal Transfer Deleted successfull." });
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
                InternalTransferDetailsModel internalTransferDetailsModel = await internalTransferBLL.GetDetails(id);
                if (internalTransferDetailsModel != null)
                {
                    return Ok(new { status = 200, obj = internalTransferDetailsModel, message = "Internal Transfer details retrive successfull." });
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
                token = await TokenExtracter.ExtractTokenAsync(User, userManager);
                List<InternalTransferDetailsModel> internalTransferDetailsModel = await internalTransferBLL.GetTableData();
                if (internalTransferDetailsModel != null)
                {
                    return Ok(new { status = 200, obj = internalTransferDetailsModel, message = "Internal Transfer table data retrive successfull." });
                }
            }
            catch (Exception e)
            {

            }
            return BadRequest(new { status = 404, message = message });
        }
    }
}