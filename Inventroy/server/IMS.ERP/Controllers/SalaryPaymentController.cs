using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AdminBLL;
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
    public class SalaryPaymentController : ControllerBase
    {
        private string message = "Sorry! Something going wrong. Please try again.";
        private readonly IRepository<FixedExpense> repository;
        private readonly UserManager<User> userManager;
        private SalaryPaymentBLL salaryPaymentBLL;
        private EmployeeBLL emprepository;
        private ApplicationUser token;
        public SalaryPaymentController(IRepository<SalaryPayment> repository, UserManager<User> userManager, IRepository<Employee> emprepository)
        {
            salaryPaymentBLL = new SalaryPaymentBLL(repository, userManager, emprepository);
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
                    SalaryPaymentViewModel salaryPaymentViewModel = await salaryPaymentBLL.GetSalaryPayment(id);
                    if (salaryPaymentViewModel != null)
                    {
                        return Ok(new { status = 200, obj = salaryPaymentViewModel, message = "Salary payment data retrive successfull." });
                    }
                }
                else
                {
                    IEnumerable<SalaryPaymentViewModel> salaryPaymentViewModel = await salaryPaymentBLL.GetSalaryPayments();
                    if (salaryPaymentViewModel.Count() > 0)
                    {
                        return Ok(new { status = 200, obj = salaryPaymentViewModel, message = "Salary payment data retrive successfull." });
                    }
                }
            }
            catch (Exception e)
            {

            }
            return BadRequest(new { status = 404, message = message });
        }
        [HttpPost]
        public async Task<ActionResult> Post(SalaryPaymentViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    token = await TokenExtracter.ExtractTokenAsync(User, userManager);
                    SalaryPaymentViewModel salaryPaymentViewModel = await salaryPaymentBLL.AddSalaryPayment(model, token);
                    if (salaryPaymentViewModel != null)
                    {
                        return Ok(new { status = 200, obj = salaryPaymentViewModel, message = "Salary payment created successfull." });
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
        public async Task<ActionResult> Put(SalaryPaymentViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    token = await TokenExtracter.ExtractTokenAsync(User, userManager);
                    SalaryPaymentViewModel salaryPaymentViewModel = await salaryPaymentBLL.UpdateSalaryPayment(model, token);
                    if (salaryPaymentViewModel != null)
                    {
                        return Ok(new { status = 200, obj = salaryPaymentViewModel, message = "Salary payment updated successfull." });
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
                SalaryPaymentViewModel salaryPaymentViewModel = await salaryPaymentBLL.DeleteSalaryPayment(id);
                if (salaryPaymentViewModel != null)
                {
                    return Ok(new { status = 200, obj = salaryPaymentViewModel, message = "Salary payment Deleted successfull." });
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
                SalaryPaymentDetailsViewModel salaryPaymentDetailsViewModel = await salaryPaymentBLL.GetDetails(id);
                if (salaryPaymentDetailsViewModel != null)
                {
                    return Ok(new { status = 200, obj = salaryPaymentDetailsViewModel, message = "Salary payment details retrive successfull." });
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
                List<SalaryPaymentDetailsViewModel> salaryPaymentDetailsViewModel = await salaryPaymentBLL.GetTableData();
                if (salaryPaymentDetailsViewModel != null)
                {
                    return Ok(new { status = 200, obj = salaryPaymentDetailsViewModel, message = "Salary payment table data retrive successfull." });
                }
            }
            catch (Exception e)
            {

            }
            return BadRequest(new { status = 404, message = message });
        }
    }
}