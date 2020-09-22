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
    public class FixedExpenseController : ControllerBase
    {
        private string message = "Sorry! Something going wrong. Please try again.";
        private readonly IRepository<FixedExpense> repository;
        private readonly UserManager<User> userManager;
        private FixedExpenseBLL fixedExpenseBLL;
        private ApplicationUser token;
        public FixedExpenseController(IRepository<FixedExpense> repository, UserManager<User> userManager)
        {
            fixedExpenseBLL = new FixedExpenseBLL(repository, userManager);
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
                    FixedExpenseViewModel fixedExpenseViewModel = await fixedExpenseBLL.GetFixedExpense(id);
                    if (fixedExpenseViewModel != null)
                    {
                        return Ok(new { status = 200, obj = fixedExpenseViewModel, message = "Fixed Expense data retrive successfull." });
                    }
                }
                else
                {
                    IEnumerable<FixedExpenseViewModel> fixedExpenseViewModel = await fixedExpenseBLL.GetFixedExpenses();
                    if (fixedExpenseViewModel.Count() > 0)
                    {
                        return Ok(new { status = 200, obj = fixedExpenseViewModel, message = "Fixed Expense data retrive successfull." });
                    }
                }
            }
            catch (Exception e)
            {

            }
            return BadRequest(new { status = 404, message = message });
        }
        [HttpPost]
        public async Task<ActionResult> Post(FixedExpenseViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    token = await TokenExtracter.ExtractTokenAsync(User, userManager);
                    FixedExpenseViewModel fixedExpenseViewModel = await fixedExpenseBLL.AddFixedExpense(model, token);
                    if (fixedExpenseViewModel != null)
                    {
                        return Ok(new { status = 200, obj = fixedExpenseViewModel, message = "Fixed Expense created successfull." });
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
        public async Task<ActionResult> Put(FixedExpenseViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    token = await TokenExtracter.ExtractTokenAsync(User, userManager);
                    FixedExpenseViewModel fixedExpenseViewModel = await fixedExpenseBLL.UpdateFixedExpense(model, token);
                    if (fixedExpenseViewModel != null)
                    {
                        return Ok(new { status = 200, obj = fixedExpenseViewModel, message = "Fixed Expense updated successfull." });
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
                FixedExpenseViewModel fixedExpenseViewModel = await fixedExpenseBLL.DeleteFixedExpense(id);
                if (fixedExpenseViewModel != null)
                {
                    return Ok(new { status = 200, obj = fixedExpenseViewModel, message = "Fixed Expense Deleted successfull." });
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
                FixedExpenseDetailsViewModel fixedExpenseDetailsViewModel = await fixedExpenseBLL.GetDetails(id);
                if (fixedExpenseDetailsViewModel != null)
                {
                    return Ok(new { status = 200, obj = fixedExpenseDetailsViewModel, message = "Fixed Expense details retrive successfull." });
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
                List<FixedExpenseDetailsViewModel> fixedExpenseDetailsViewModel = await fixedExpenseBLL.GetTableData();
                if (fixedExpenseDetailsViewModel != null)
                {
                    return Ok(new { status = 200, obj = fixedExpenseDetailsViewModel, message = "Fixed Expense table data retrive successfull." });
                }
            }
            catch (Exception e)
            {

            }
            return BadRequest(new { status = 404, message = message });
        }
    }
}