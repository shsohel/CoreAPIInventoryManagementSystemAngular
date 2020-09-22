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
    public class BankTransferController : ControllerBase
    {
        private string message = "Sorry! Something going wrong. Please try again.";
        private readonly IRepository<BankTransfer> repository;
        private readonly UserManager<User> userManager;
        private BankTransferBLL bankTransferBLL;
        private ApplicationUser token;
        public BankTransferController(IRepository<BankTransfer> repository, UserManager<User> userManager)
        {
            bankTransferBLL = new BankTransferBLL(repository, userManager);
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
                    BankTransferViewModel bankTransferViewModel = await bankTransferBLL.GetBankTransfer(id);
                    if (bankTransferViewModel != null)
                    {
                        return Ok(new { status = 200, obj = bankTransferViewModel, message = "Bank Transfer data retrive successfull." });
                    }
                }
                else
                {
                    IEnumerable<BankTransferViewModel> bankTransferViewModel = await bankTransferBLL.GetBankTransfers();
                    if (bankTransferViewModel.Count() > 0)
                    {
                        return Ok(new { status = 200, obj = bankTransferViewModel, message = "Bank Transfer data retrive successfull." });
                    }
                }
            }
            catch (Exception e)
            {

            }
            return BadRequest(new { status = 404, message = message });
        }
        [HttpPost]
        public async Task<ActionResult> Post(BankTransferViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    token = await TokenExtracter.ExtractTokenAsync(User, userManager);
                    BankTransferViewModel bankTransferViewModel = await bankTransferBLL.AddBankTransfer(model, token);
                    if (bankTransferViewModel != null)
                    {
                        return Ok(new { status = 200, obj = bankTransferViewModel, message = "Bank Transfer created successfull." });
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
        public async Task<ActionResult> Put(BankTransferViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    token = await TokenExtracter.ExtractTokenAsync(User, userManager);
                    BankTransferViewModel bankTransferViewModel = await bankTransferBLL.UpdateBankTransfer(model, token);
                    if (bankTransferViewModel != null)
                    {
                        return Ok(new { status = 200, obj = bankTransferViewModel, message = "Bank Transfer updated successfull." });
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
                BankTransferViewModel bankTransferViewModel = await bankTransferBLL.DeleteBankTransfer(id);
                if (bankTransferViewModel != null)
                {
                    return Ok(new { status = 200, obj = bankTransferViewModel, message = "Bank Transfer Deleted successfull." });
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
                BankTransferDetailsModel bankTransferDetailsModel = await bankTransferBLL.GetDetails(id);
                if (bankTransferDetailsModel != null)
                {
                    return Ok(new { status = 200, obj = bankTransferDetailsModel, message = "Bank Transfer details retrive successfull." });
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
                List<BankTransferDetailsModel> bankTransferDetailsModel = await bankTransferBLL.GetTableData();
                if (bankTransferDetailsModel != null)
                {
                    return Ok(new { status = 200, obj = bankTransferDetailsModel, message = "Bank Transfer table data retrive successfull." });
                }
            }
            catch (Exception e)
            {

            }
            return BadRequest(new { status = 404, message = message });
        }
    }
}