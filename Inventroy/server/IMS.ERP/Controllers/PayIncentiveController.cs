using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CommonBLL.Helper;
using CommonDAL.Models;
using CommonDAL.Repository;
using CommonDAL.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using StockBLL;

namespace IMSERP.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class PayIncentiveController : ControllerBase
    {
        private string message = "Sorry! Something going wrong. Please try again.";
        private readonly IRepository<PayIncentive> repository;
        private readonly UserManager<User> userManager;
        private readonly IRepository<Employee> empRepository;
        private PayIncentiveBLL payIncentiveBLL;
        private ApplicationUser token;
        public PayIncentiveController(IRepository<PayIncentive> repository, UserManager<User> userManager, IRepository<Employee> empRepository)
        {
            payIncentiveBLL = new PayIncentiveBLL(repository, userManager, empRepository);
            this.userManager = userManager;
            this.empRepository = empRepository;
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
                    PayIncentiveViewModel payIncentiveViewModel = await payIncentiveBLL.GetPayIncentive(id);
                    if (payIncentiveViewModel != null)
                    {
                        return Ok(new { status = 200, obj = payIncentiveViewModel, message = "Pay Incentive data retrive successfull." });
                    }
                }
                else
                {
                    IEnumerable<PayIncentiveViewModel> payIncentiveViewModels = await payIncentiveBLL.GetPayIncentives();
                    if (payIncentiveViewModels.Count() > 0)
                    {
                        return Ok(new { status = 200, obj = payIncentiveViewModels, message = "Pay Incentive data retrive successfull." });
                    }
                }
            }
            catch (Exception e)
            {

            }
            return BadRequest(new { status = 404, message = message });
        }
        [HttpPost]
        public async Task<ActionResult> Post(PayIncentiveViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    token = await TokenExtracter.ExtractTokenAsync(User, userManager);
                    PayIncentiveViewModel payIncentiveViewModel = await payIncentiveBLL.AddPayIncentive(model, token);
                    if (payIncentiveViewModel != null)
                    {
                        return Ok(new { status = 200, obj = payIncentiveViewModel, message = "Pay Incentive created successfull." });
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
        public async Task<ActionResult> Put(PayIncentiveViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    token = await TokenExtracter.ExtractTokenAsync(User, userManager);
                    PayIncentiveViewModel payIncentiveViewModel = await payIncentiveBLL.UpdatePayIncentive(model, token);
                    if (payIncentiveViewModel != null)
                    {
                        return Ok(new { status = 200, obj = payIncentiveViewModel, message = "Pay Incentive updated successfull." });
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
                PayIncentiveViewModel payIncentiveViewModel = await payIncentiveBLL.DeletePayIncentive(id);
                if (payIncentiveViewModel != null)
                {
                    return Ok(new { status = 200, obj = payIncentiveViewModel, message = "Pay Incentive Deleted successfull." });
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
                PayIncentiveDetailsViewModel payIncentiveDetailsViewModel = await payIncentiveBLL.GetDetails(id);
                if (payIncentiveDetailsViewModel != null)
                {
                    return Ok(new { status = 200, obj = payIncentiveDetailsViewModel, message = "Pay Incentive details data retrive successfull." });
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
                List<PayIncentiveDetailsViewModel> payIncentiveDetailsViewModel = await payIncentiveBLL.GetTableData();
                if (payIncentiveDetailsViewModel != null)
                {
                    return Ok(new { status = 200, obj = payIncentiveDetailsViewModel, message = "Pay Incentive table data retrive successfull." });
                }
            }
            catch (Exception e)
            {

            }
            return BadRequest(new { status = 404, message = message });
        }
    }
}