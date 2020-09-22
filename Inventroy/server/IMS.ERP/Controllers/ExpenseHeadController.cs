using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CommonBLL.Helper;
using CommonDAL.Models;
using CommonDAL.Repository;
using CommonDAL.ViewModels;
using ExpenseBLL;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace IMSERP.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ExpenseHeadController : ControllerBase
    {
        private string message = "Sorry! Something going wrong. Please try again.";
        private readonly IRepository<ExpenseHead> repository;
        private readonly UserManager<User> userManager;
        private ExpenseHeadBLL expenseHeadBLL;
        private ApplicationUser token;
        public ExpenseHeadController(IRepository<ExpenseHead> repository, UserManager<User> userManager)
        {
            expenseHeadBLL = new ExpenseHeadBLL(repository, userManager);
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
                    ExpenseHeadViewModel expenseHeadViewModel = await expenseHeadBLL.GetExpenseHead(id);
                    if (expenseHeadViewModel != null)
                    {
                        return Ok(new { status = 200, obj = expenseHeadViewModel, message = "Expense Head data retrive successfull." });
                    }
                }
                else
                {
                    IEnumerable<ExpenseHeadViewModel> expenseHeadViewModels = await expenseHeadBLL.GetExpenseHeads();
                    if (expenseHeadViewModels.Count() > 0)
                    {
                        return Ok(new { status = 200, obj = expenseHeadViewModels, message = "Expense Head data retrive successfull." });
                    }
                }
            }
            catch (Exception e)
            {

            }
            return BadRequest(new { status = 404, message = message });
        }
        [HttpPost]
        public async Task<ActionResult> Post(ExpenseHeadViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    token = await TokenExtracter.ExtractTokenAsync(User, userManager);
                    ExpenseHeadViewModel expenseHeadViewModel = await expenseHeadBLL.AddExpenseHead(model, token);
                    if (expenseHeadViewModel != null)
                    {
                        return Ok(new { status = 200, obj = expenseHeadViewModel, message = "Expense Head created successfull." });
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
        public async Task<ActionResult> Put(ExpenseHeadViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    token = await TokenExtracter.ExtractTokenAsync(User, userManager);
                    ExpenseHeadViewModel expenseHeadViewModel = await expenseHeadBLL.UpdateExpenseHead(model, token);
                    if (expenseHeadViewModel != null)
                    {
                        return Ok(new { status = 200, obj = expenseHeadViewModel, message = "Expense Head updated successfull." });
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
                ExpenseHeadViewModel expenseHeadViewModel = await expenseHeadBLL.DeleteExpenseHead(id);
                if (expenseHeadViewModel != null)
                {
                    return Ok(new { status = 200, obj = expenseHeadViewModel, message = "Expense Head Deleted successfull." });
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
                ExpenseHeadDetailsViewModel expenseHeadDetailsViewModel = await expenseHeadBLL.GetDetails(id);
                if (expenseHeadDetailsViewModel != null)
                {
                    return Ok(new { status = 200, obj = expenseHeadDetailsViewModel, message = "Expense Head details data retrive successfull." });
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
                List<ExpenseHeadDetailsViewModel> expenseHeadDetailsViewModel = await expenseHeadBLL.GetTableData();
                if (expenseHeadDetailsViewModel != null)
                {
                    return Ok(new { status = 200, obj = expenseHeadDetailsViewModel, message = "Expense Head table data retrive successfull." });
                }
            }
            catch (Exception e)
            {

            }
            return BadRequest(new { status = 404, message = message });
        }
    }
}