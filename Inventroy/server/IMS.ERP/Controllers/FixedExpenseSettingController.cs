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
    public class FixedExpenseSettingController : ControllerBase
    {
        private string message = "Sorry! Something going wrong. Please try again.";
        private readonly IRepository<FixedExpenseSetting> repository;
        private readonly UserManager<User> userManager;
        private FixedExpenseSettingBLL fixedExpenseSettingBLL;
        private ApplicationUser token;
        public FixedExpenseSettingController(IRepository<FixedExpenseSetting> repository, UserManager<User> userManager)
        {
            fixedExpenseSettingBLL = new FixedExpenseSettingBLL(repository, userManager);
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
                    FixedExpenseSettingViewModel fixedExpenseSettingViewModel = await fixedExpenseSettingBLL.GetFixedExpenseSetting(id);
                    if (fixedExpenseSettingViewModel != null)
                    {
                        return Ok(new { status = 200, obj = fixedExpenseSettingViewModel, message = "Fixed Expense Setting data retrive successfull." });
                    }
                }
                else
                {
                    IEnumerable<FixedExpenseSettingViewModel> fixedExpenseSettingViewModel = await fixedExpenseSettingBLL.GetFixedExpenseSettings();
                    if (fixedExpenseSettingViewModel.Count() > 0)
                    {
                        return Ok(new { status = 200, obj = fixedExpenseSettingViewModel, message = "Fixed Expense Setting data retrive successfull." });
                    }
                }
            }
            catch (Exception e)
            {

            }
            return BadRequest(new { status = 404, message = message });
        }
        [HttpPost]
        public async Task<ActionResult> Post(FixedExpenseSettingViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    token = await TokenExtracter.ExtractTokenAsync(User, userManager);
                    FixedExpenseSettingViewModel fixedExpenseSettingViewModel = await fixedExpenseSettingBLL.AddFixedExpenseSetting(model, token);
                    if (fixedExpenseSettingViewModel != null)
                    {
                        return Ok(new { status = 200, obj = fixedExpenseSettingViewModel, message = "Fixed Expense Setting created successfull." });
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
        public async Task<ActionResult> Put(FixedExpenseSettingViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    token = await TokenExtracter.ExtractTokenAsync(User, userManager);
                    FixedExpenseSettingViewModel fixedExpenseSettingViewModel = await fixedExpenseSettingBLL.UpdateFixedExpenseSetting(model, token);
                    if (fixedExpenseSettingViewModel != null)
                    {
                        return Ok(new { status = 200, obj = fixedExpenseSettingViewModel, message = "Fixed Expense Setting updated successfull." });
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
                FixedExpenseSettingViewModel fixedExpenseViewModel = await fixedExpenseSettingBLL.DeleteFixedExpenseSetting(id);
                if (fixedExpenseViewModel != null)
                {
                    return Ok(new { status = 200, obj = fixedExpenseViewModel, message = "Fixed Expense Setting Deleted successfull." });
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
                FixedExpenseSettingDetailsViewModel fixedExpenseDetailsViewModel = await fixedExpenseSettingBLL.GetDetails(id);
                if (fixedExpenseDetailsViewModel != null)
                {
                    return Ok(new { status = 200, obj = fixedExpenseDetailsViewModel, message = "Fixed Expense Setting details retrive successfull." });
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
                List<FixedExpenseSettingDetailsViewModel> fixedExpenseSettingDetailsViewModel = await fixedExpenseSettingBLL.GetTableData();
                if (fixedExpenseSettingDetailsViewModel != null)
                {
                    return Ok(new { status = 200, obj = fixedExpenseSettingDetailsViewModel, message = "Fixed Expense Setting table data retrive successfull." });
                }
            }
            catch (Exception e)
            {

            }
            return BadRequest(new { status = 404, message = message });
        }
    }
}