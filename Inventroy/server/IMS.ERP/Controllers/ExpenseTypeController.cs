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
    public class ExpenseTypeController : ControllerBase
    {
        private string message = "Sorry! Something going wrong. Please try again.";
        private readonly IRepository<ExpenseType> repository;
        private readonly UserManager<User> userManager;
        private ExpenseTypeBLL expenseTypeBLL;
        private ApplicationUser token;
        public ExpenseTypeController(IRepository<ExpenseType> repository, UserManager<User> userManager)
        {
            expenseTypeBLL = new ExpenseTypeBLL(repository, userManager);
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
                    ExpenseTypeViewModel expenseTypeViewModel = await expenseTypeBLL.GetExpenseType(id);
                    if (expenseTypeViewModel != null)
                    {
                        return Ok(new { status = 200, obj = expenseTypeViewModel, message = "Expense Type data retrive successfull." });
                    }
                }
                else
                {
                    IEnumerable<ExpenseTypeViewModel> expenseTypeViewModels = await expenseTypeBLL.GetExpenseTypes();
                    if (expenseTypeViewModels.Count() > 0)
                    {
                        return Ok(new { status = 200, obj = expenseTypeViewModels, message = "Expense Type data retrive successfull." });
                    }
                }
            }
            catch (Exception e)
            {

            }
            return BadRequest(new { status = 404, message = message });
        }
        [HttpPost]
        public async Task<ActionResult> Post(ExpenseTypeViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    token = await TokenExtracter.ExtractTokenAsync(User, userManager);
                    ExpenseTypeViewModel expenseTypeViewModel = await expenseTypeBLL.AddExpenseType(model, token);
                    if (expenseTypeViewModel != null)
                    {
                        return Ok(new { status = 200, obj = expenseTypeViewModel, message = "Expense Type created successfull." });
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
        public async Task<ActionResult> Put(ExpenseTypeViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    token = await TokenExtracter.ExtractTokenAsync(User, userManager);
                    ExpenseTypeViewModel expenseTypeViewModel = await expenseTypeBLL.UpdateExpenseType(model, token);
                    if (expenseTypeViewModel != null)
                    {
                        return Ok(new { status = 200, obj = expenseTypeViewModel, message = "Expense Type updated successfull." });
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
                ExpenseTypeViewModel expenseTypeViewModel = await expenseTypeBLL.DeleteExpenseType(id);
                if (expenseTypeViewModel != null)
                {
                    return Ok(new { status = 200, obj = expenseTypeViewModel, message = "Expense Type Deleted successfull." });
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
                ExpenseTypeDetailsViewModel expenseTypeDetailsViewModel = await expenseTypeBLL.GetDetails(id);
                if (expenseTypeDetailsViewModel != null)
                {
                    return Ok(new { status = 200, obj = expenseTypeDetailsViewModel, message = "Expense Type details data retrive successfull." });
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
                List<ExpenseTypeDetailsViewModel> expenseTypeDetailsViewModel = await expenseTypeBLL.GetTableData();
                if (expenseTypeDetailsViewModel != null)
                {
                    return Ok(new { status = 200, obj = expenseTypeDetailsViewModel, message = "Expense Type table data retrive successfull." });
                }
            }
            catch (Exception e)
            {

            }
            return BadRequest(new { status = 404, message = message });
        }
    }
}