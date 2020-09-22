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
    public class BankAccountController : ControllerBase
    {
        private string message = "Sorry! Something going wrong. Please try again.";
        private readonly IRepository<BankAccount> repository;
        private readonly UserManager<User> userManager;
        private BankAccountBLL bankAccountBLL;
        private ApplicationUser token;
        public BankAccountController(IRepository<BankAccount> repository, UserManager<User> userManager)
        {
            bankAccountBLL = new BankAccountBLL(repository, userManager);
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
                    BankAccountViewModel bankAccountViewModel = await bankAccountBLL.GetBankAccount(id);
                    if (bankAccountViewModel != null)
                    {
                        return Ok(new { status = 200, obj = bankAccountViewModel, message = "Bank Transfer data retrive successfull." });
                    }
                }
                else
                {
                    IEnumerable<BankAccountViewModel> bankAccountViewModel = await bankAccountBLL.GetBankAccounts();
                    if (bankAccountViewModel.Count() > 0)
                    {
                        return Ok(new { status = 200, obj = bankAccountViewModel, message = "Bank Transfer data retrive successfull." });
                    }
                }
            }
            catch (Exception e)
            {

            }
            return BadRequest(new { status = 404, message = message });
        }
        [HttpPost]
        public async Task<ActionResult> Post(BankAccountViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    token = await TokenExtracter.ExtractTokenAsync(User, userManager);
                    BankAccountViewModel bankAccountViewModel = await bankAccountBLL.AddBankAccount(model, token);
                    if (bankAccountViewModel != null)
                    {
                        return Ok(new { status = 200, obj = bankAccountViewModel, message = "Bank Account created successfull." });
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
        public async Task<ActionResult> Put(BankAccountViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    token = await TokenExtracter.ExtractTokenAsync(User, userManager);
                    BankAccountViewModel bankAccountViewModel = await bankAccountBLL.UpdateBankAccount(model, token);
                    if (bankAccountViewModel != null)
                    {
                        return Ok(new { status = 200, obj = bankAccountViewModel, message = "Bank Account updated successfull." });
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
                BankAccountViewModel bankAccountViewModel = await bankAccountBLL.DeleteBankAccount(id);
                if (bankAccountViewModel != null)
                {
                    return Ok(new { status = 200, obj = bankAccountViewModel, message = "Bank Account Deleted successfull." });
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
                BankAccountDetailsViewModel bankAccountDetailsViewModel = await bankAccountBLL.GetDetails(id);
                if (bankAccountDetailsViewModel != null)
                {
                    return Ok(new { status = 200, obj = bankAccountDetailsViewModel, message = "Bank Account details retrive successfull." });
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
                List<BankAccountDetailsViewModel> bankAccountDetailsViewModel = await bankAccountBLL.GetTableData();
                if (bankAccountDetailsViewModel != null)
                {
                    return Ok(new { status = 200, obj = bankAccountDetailsViewModel, message = "Bank Account table data retrive successfull." });
                }
            }
            catch (Exception e)
            {

            }
            return BadRequest(new { status = 404, message = message });
        }
    }
}