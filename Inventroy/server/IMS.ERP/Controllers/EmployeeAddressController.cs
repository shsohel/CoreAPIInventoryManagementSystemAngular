using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AdminBLL;
using CommonBLL.Helper;
using CommonDAL.Models;
using CommonDAL.Repository;
using CommonDAL.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace IMSERP.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeAddressController : ControllerBase
    {
        private string message = "Sorry! Something going wrong. Please try again.";
       // private readonly IRepository<Employee> repository;
        private ApplicationUser toekn;
        private readonly UserManager<User> userManager;
        private ApplicationUser token;
      
        private EmployeeAddressBLL employeeAddressBLL;
        public EmployeeAddressController(IRepository<EmployeeAddress> repository, IRepository<Employee> emRepository, UserManager<User> userManager)
        {
            employeeAddressBLL = new EmployeeAddressBLL(repository, emRepository, userManager);
            this.userManager = userManager;
        }
        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult> Get(long id)
        {
            try
            {
                toekn = await TokenExtracter.ExtractTokenAsync(User, userManager);
                if (id > 0)
                {
                    EmployeeAddressViewModel employeeAddressViewModel = await employeeAddressBLL.GetEmployeeAddress(id);
                    if (employeeAddressViewModel != null)
                    {
                        return Ok(new { status = 200, obj = employeeAddressViewModel, message = "Employee Address data retrive successfull." });
                    }
                }
                else
                {
                    IEnumerable<EmployeeAddressViewModel> employeeAddressViewModels = await employeeAddressBLL.GetEmployeeAddresses();
                    if (employeeAddressViewModels.Count() > 0)
                    {
                        return Ok(new { status = 200, obj = employeeAddressViewModels, message = "Employee Address data retrive successfull." });
                    }
                }
            }
            catch (Exception e)
            {

            }
            return BadRequest(new { status = 404, message = message });
        }
        [HttpPost]
        public async Task<ActionResult> Post(EmployeeAddressViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    token = await TokenExtracter.ExtractTokenAsync(User, userManager);
                    EmployeeAddressViewModel employeeAddressViewModel = await employeeAddressBLL.AddEmployeeAddress(model, token);
                    if (employeeAddressViewModel != null)
                    {
                        return Ok(new { status = 200, obj = employeeAddressViewModel, message = "Employee Address created successfull." });
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
        public async Task<ActionResult> Put(EmployeeAddressViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    token = await TokenExtracter.ExtractTokenAsync(User, userManager);
                    EmployeeAddressViewModel employeeAddressViewModel = await employeeAddressBLL.UpdateEmployeeAddress(model, token);
                    if (employeeAddressViewModel != null)
                    {
                        return Ok(new { status = 200, obj = employeeAddressViewModel, message = "Employee Addrees updated successfully." });
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
        //[HttpDelete]
        //[Route("delete/{id}")]
        //public async Task<ActionResult> Delete(long id)
        //{
        //    try
        //    {
        //        EmployeeViewModel employeeViewModel = await employeeBLL.DeleteEmployee(id);
        //        if (employeeViewModel != null)
        //        {
        //            return Ok(new { status = 200, obj = employeeViewModel, message = "Employee Deleted successfull." });
        //        }
        //    }
        //    catch (Exception e)
        //    {

        //    }
        //    return BadRequest(new { status = 404, message = message });
        //}
        //[HttpGet]
        //[Route("details/{id}")]
        //public async Task<ActionResult> GetDetails(long id)
        //{
        //    try
        //    {
        //        EmployeeViewModel employeeViewModel = await employeeBLL.GetDetails(id);
        //        if (employeeViewModel != null)
        //        {
        //            return Ok(new { status = 200, obj = employeeViewModel, message = "Employee details data retrive successfull." });
        //        }
        //    }
        //    catch (Exception e)
        //    {

        //    }
        //    return BadRequest(new { status = 404, message = message });
        //}
        //[HttpGet]
        //[Route("tableData")]
        //[Authorize]
        //public async Task<ActionResult> GetTableData()
        //{
        //    try
        //    {
        //        toekn = await TokenExtracter.ExtractTokenAsync(User, userManager);
        //        List<EmployeeViewModel> employeeViewModels = await employeeBLL.GetTableData();
        //        if (employeeViewModels != null)
        //        {
        //            return Ok(new { status = 200, obj = employeeViewModels, message = "Employee table data retrive successfull." });
        //        }
        //    }
        //    catch (Exception e)
        //    {

        //    }
        //    return BadRequest(new { status = 404, message = message });
        //}
    }
}