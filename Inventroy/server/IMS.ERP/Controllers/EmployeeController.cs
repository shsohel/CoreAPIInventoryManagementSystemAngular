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
    public class EmployeeController : ControllerBase
    {
        private string message = "Sorry! Something going wrong. Please try again.";
        private readonly IRepository<Employee> repository;
        private ApplicationUser toekn;
        private readonly UserManager<User> userManager;
        private ApplicationUser token;
        private EmployeeBLL employeeBLL;
        public EmployeeController(IRepository<Employee> repository, UserManager<User> userManager)
        {
            employeeBLL = new EmployeeBLL(repository, userManager);
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
                    EmployeeViewModel employeeViewModel = await employeeBLL.GetEmployee(id);
                    if (employeeViewModel != null)
                    {
                        return Ok(new { status = 200, obj = employeeViewModel, message = "Employee data retrive successfull." });
                    }
                }
                else
                {
                    IEnumerable<EmployeeViewModel> employeeViewModels = await employeeBLL.GetEmployees();
                    if (employeeViewModels.Count() > 0)
                    {
                        return Ok(new { status = 200, obj = employeeViewModels, message = "Employee data retrive successfull." });
                    }
                }
            }
            catch (Exception e)
            {

            }
            return BadRequest(new { status = 404, message = message });
        }
        [HttpPost]
        public async Task<ActionResult> Post(EmployeeViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    token = await TokenExtracter.ExtractTokenAsync(User, userManager);
                    EmployeeViewModel employeeViewModel = await employeeBLL.AddEmployee(model, token);
                    if (employeeViewModel != null)
                    {
                        return Ok(new { status = 200, obj = employeeViewModel, message = "Employee created successfull." });
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
        public async Task<ActionResult> Put(EmployeeViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    token = await TokenExtracter.ExtractTokenAsync(User, userManager);
                    EmployeeViewModel employeeViewModel = await employeeBLL.UpdateEmployee(model, token);
                    if (employeeViewModel != null)
                    {
                        return Ok(new { status = 200, obj = employeeViewModel, message = "Employee updated successfully." });
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
        [Route("delete/{id}")]
        public async Task<ActionResult> Delete(long id)
        {
            try
            {
                EmployeeViewModel employeeViewModel = await employeeBLL.DeleteEmployee(id);
                if (employeeViewModel != null)
                {
                    return Ok(new { status = 200, obj = employeeViewModel, message = "Employee Deleted successfull." });
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
                EmployeeViewModel employeeViewModel = await employeeBLL.GetDetails(id);
                if (employeeViewModel != null)
                {
                    return Ok(new { status = 200, obj = employeeViewModel, message = "Employee details data retrive successfull." });
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
                toekn = await TokenExtracter.ExtractTokenAsync(User, userManager);
                List<EmployeeViewModel> employeeViewModels = await employeeBLL.GetTableData();
                if (employeeViewModels != null)
                {
                    return Ok(new { status = 200, obj = employeeViewModels, message = "Employee table data retrive successfull." });
                }
            }
            catch (Exception e)
            {

            }
            return BadRequest(new { status = 404, message = message });
        }
    }
}