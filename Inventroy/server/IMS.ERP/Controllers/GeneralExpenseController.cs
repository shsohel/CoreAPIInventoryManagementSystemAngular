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
    public class GeneralExpenseController : ControllerBase
    {
        private string message = "Sorry! Something going wrong. Please try again.";
        private readonly IRepository<GeneralExpense> repository;
        private readonly UserManager<User> userManager;
        private GeneralExpenseBLL generalExpenseBLL;
        private ApplicationUser token;
        public GeneralExpenseController(IRepository<GeneralExpense> repository, UserManager<User> userManager)
        {
            generalExpenseBLL = new GeneralExpenseBLL(repository, userManager);
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
                    GeneralExpenseViewModel generalExpenseViewModel = await generalExpenseBLL.GetGeneralExpense(id);
                    if (generalExpenseViewModel != null)
                    {
                        return Ok(new { status = 200, obj = generalExpenseViewModel, message = "General Expense data retrive successfull." });
                    }
                }
                else
                {
                    IEnumerable<GeneralExpenseViewModel> generalExpenseViewModel = await generalExpenseBLL.GetGeneralExpenses();
                    if (generalExpenseViewModel.Count() > 0)
                    {
                        return Ok(new { status = 200, obj = generalExpenseViewModel, message = "General Expense data retrive successfull." });
                    }
                }
            }
            catch (Exception e)
            {

            }
            return BadRequest(new { status = 404, message = message });
        }
        [HttpPost]
        public async Task<ActionResult> Post(GeneralExpenseViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    token = await TokenExtracter.ExtractTokenAsync(User, userManager);
                    GeneralExpenseViewModel generalExpenseViewModel = await generalExpenseBLL.AddGeneralExpense(model, token);
                    if (generalExpenseViewModel != null)
                    {
                        return Ok(new { status = 200, obj = generalExpenseViewModel, message = "General Expense created successfull." });
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
        public async Task<ActionResult> Put(GeneralExpenseViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    token = await TokenExtracter.ExtractTokenAsync(User, userManager);
                    GeneralExpenseViewModel generalExpenseViewModel = await generalExpenseBLL.UpdateGeneralExpense(model, token);
                    if (generalExpenseViewModel != null)
                    {
                        return Ok(new { status = 200, obj = generalExpenseViewModel, message = "General Expense updated successfull." });
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
                GeneralExpenseViewModel generalExpenseViewModel = await generalExpenseBLL.DeleteGeneralExpense(id);
                if (generalExpenseViewModel != null)
                {
                    return Ok(new { status = 200, obj = generalExpenseViewModel, message = "General Expense Deleted successfull." });
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
                GeneralExpenseDetailsViewModel generalExpenseDetailsViewModel = await generalExpenseBLL.GetDetails(id);
                if (generalExpenseDetailsViewModel != null)
                {
                    return Ok(new { status = 200, obj = generalExpenseDetailsViewModel, message = "General Expense details retrive successfull." });
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
                List<GeneralExpenseDetailsViewModel> generalExpenseDetailsViewModel = await generalExpenseBLL.GetTableData();
                if (generalExpenseDetailsViewModel != null)
                {
                    return Ok(new { status = 200, obj = generalExpenseDetailsViewModel, message = "General Expense table data retrive successfull." });
                }
            }
            catch (Exception e)
            {

            }
            return BadRequest(new { status = 404, message = message });
        }
    }
}