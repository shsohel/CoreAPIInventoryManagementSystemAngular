using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AdminBLL;
using CommonBLL.Helper;
using CommonDAL.Models;
using CommonDAL.Repository;
using CommonDAL.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace IMSERP.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class CustomerController : ControllerBase
    {
        private string message = "Sorry! Something going wrong. Please try again.";
        readonly CustomerBLL customerBLL;
        private readonly UserManager<User> userManager;
        private ApplicationUser token;

        public CustomerController(IRepository<Customer> repository, UserManager<User> userManager)
        {
            customerBLL = new CustomerBLL(repository, userManager);
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
                    CustomerViewModel customerViewModel = await customerBLL.GetCustomer(id);
                    if(customerViewModel != null)
                    {
                        return Ok(new { status = 200, obj = customerViewModel, message = "Customer data retrive successfull." });
                    }
                }
                else
                {
                    IEnumerable<CustomerViewModel> customerViewModels = await customerBLL.GetCustomers();
                    if (customerViewModels.Count() > 0)
                    {
                        return Ok(new { status = 200, obj = customerViewModels, message = "Customer data retrive successfull." });
                    }
                }
            }
            catch (Exception e)
            {

            }
            return BadRequest(new { status = 404, message = message });
        }
        [HttpPost]
        public async Task<ActionResult> Post(CustomerViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    token = await TokenExtracter.ExtractTokenAsync(User, userManager);
                    CustomerViewModel customerViewModel = await customerBLL.AddCustomer(model, token);
                    if (customerViewModel != null)
                    {
                        return Ok(new { status = 200, obj = customerViewModel, message = "Customer created successfull." });
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
        public async Task<ActionResult> Put(CustomerViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    token = await TokenExtracter.ExtractTokenAsync(User, userManager);
                    CustomerViewModel customerViewModel = await customerBLL.UpdateCustomer(model, token);
                    if (customerViewModel != null)
                    {
                        return Ok(new { status = 200, obj = customerViewModel, message = "Customer updated successfull." });
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
        public async Task<ActionResult> Delete(long id)
        {
            try
            {
                token = await TokenExtracter.ExtractTokenAsync(User, userManager);
                CustomerViewModel customerViewModel = await customerBLL.DeleteCustomer(id);
                if (customerViewModel != null)
                {
                    return Ok(new { status = 200, obj = customerViewModel, message = "Customer Deleted successfull." });
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
                CustomerViewModel customerViewModel = await customerBLL.GetDetails(id);
                if (customerViewModel != null)
                {
                    return Ok(new { status = 200, obj = customerViewModel, message = "Customer details data retrive successfull." });
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
                List<CustomerDetailsViewModel> customerViewModel = await customerBLL.GetTableData();
                if (customerViewModel != null)
                {
                    return Ok(new { status = 200, obj = customerViewModel, message = "Customer table data retrive successfull." });
                }
            }
            catch (Exception e)
            {

            }
            return BadRequest(new { status = 404, message = message });
        }
    }
}