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
    public class ExternalTransferController : ControllerBase
    {
        private string message = "Sorry! Something going wrong. Please try again.";
        private readonly IRepository<ExternalTransfer> repository;
        private readonly UserManager<User> userManager;
        private ExternalTransferBLL externalTransferBLL;
        private ApplicationUser token;
        public ExternalTransferController(IRepository<ExternalTransfer> repository, UserManager<User> userManager)
        {
            externalTransferBLL = new ExternalTransferBLL(repository, userManager);
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
                    ExternalTransferViewModel externalTransferViewModel = await externalTransferBLL.GetExternalTransfer(id);
                    if (externalTransferViewModel != null)
                    {
                        return Ok(new { status = 200, obj = externalTransferViewModel, message = "External Transfer data retrive successfull." });
                    }
                }
                else
                {
                    IEnumerable<ExternalTransferViewModel> externalTransferViewModels = await externalTransferBLL.GetExternalTransfers();
                    if (externalTransferViewModels.Count() > 0)
                    {
                        return Ok(new { status = 200, obj = externalTransferViewModels, message = "External Transfer data retrive successfull." });
                    }
                }
            }
            catch (Exception e)
            {

            }
            return BadRequest(new { status = 404, message = message });
        }
        [HttpPost]
        public async Task<ActionResult> Post(ExternalTransferViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    token = await TokenExtracter.ExtractTokenAsync(User, userManager);
                    ExternalTransferViewModel externalTransferViewModel = await externalTransferBLL.AddExternalTransfer(model, token);
                    if (externalTransferViewModel != null)
                    {
                        return Ok(new { status = 200, obj = externalTransferViewModel, message = "External Transfer created successfull." });
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
        public async Task<ActionResult> Put(ExternalTransferViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    token = await TokenExtracter.ExtractTokenAsync(User, userManager);
                    ExternalTransferViewModel externalTransferViewModel = await externalTransferBLL.UpdateExternalTransfer(model, token);
                    if (externalTransferViewModel != null)
                    {
                        return Ok(new { status = 200, obj = externalTransferViewModel, message = "External Transfer updated successfull." });
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
                ExternalTransferViewModel externalTransferViewModel = await externalTransferBLL.DeleteExternalTransfer(id);
                if (externalTransferViewModel != null)
                {
                    return Ok(new { status = 200, obj = externalTransferViewModel, message = "External Transfer Deleted successfull." });
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
                ExternalTransferDetailsModel externalTransferDetailsModel = await externalTransferBLL.GetDetails(id);
                if (externalTransferDetailsModel != null)
                {
                    return Ok(new { status = 200, obj = externalTransferDetailsModel, message = "External Transfer details retrive successfull." });
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
                List<ExternalTransferDetailsModel> externalTransferDetailsModel = await externalTransferBLL.GetTableData();
                if (externalTransferDetailsModel != null)
                {
                    return Ok(new { status = 200, obj = externalTransferDetailsModel, message = "External Transfer table data retrive successfull." });
                }
            }
            catch (Exception e)
            {

            }
            return BadRequest(new { status = 404, message = message });
        }
    }
}