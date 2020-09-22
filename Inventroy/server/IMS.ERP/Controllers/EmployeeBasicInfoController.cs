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
    public class EmployeeBasicInfoController : ControllerBase
    {
        private string message = "Sorry! Something going wrong. Please try again.";
        private readonly IRepository<EmployeeBasicInfo> repository;
        private readonly IRepository<Employee> emrepository;

        private ApplicationUser toekn;
        private readonly UserManager<User> userManager;
        private ApplicationUser token;
        private EmployeeBasicInfoBLL employeeBasicInfoBLL;
        public EmployeeBasicInfoController(IRepository<EmployeeBasicInfo> repository, IRepository<Employee> emrepository, UserManager<User> userManager)
        {
            employeeBasicInfoBLL = new EmployeeBasicInfoBLL(repository, emrepository, userManager);
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
                    EmployeeBasicInfoViewModel employeeBasicInfoViewModel = await employeeBasicInfoBLL.GetEmployeeBasicInfo(id);
                    if (employeeBasicInfoViewModel != null)
                    {
                        return Ok(new { status = 200, obj = employeeBasicInfoViewModel, message = "Employee Basic Info data retrive successfull." });
                    }
                }
                else
                {
                    IEnumerable<EmployeeBasicInfoViewModel> employeeViewModels = await employeeBasicInfoBLL.GetEmployeeBasicInfos();
                    if (employeeViewModels.Count() > 0)
                    {
                        return Ok(new { status = 200, obj = employeeViewModels, message = "Employee Basic Info data retrive successfull." });
                    }
                }
            }
            catch (Exception e)
            {

            }
            return BadRequest(new { status = 404, message = message });
        }
        [HttpPost]
        public async Task<ActionResult> Post(EmployeeBasicInfoViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    token = await TokenExtracter.ExtractTokenAsync(User, userManager);
                    EmployeeBasicInfoViewModel employeeBasicInfoViewModel = await employeeBasicInfoBLL.AddEmployeeBasic(model, token);
                    if (employeeBasicInfoViewModel != null)
                    {
                        return Ok(new { status = 200, obj = employeeBasicInfoViewModel, message = "Employee Basic Info created successfull." });
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
        public async Task<ActionResult> Put(EmployeeBasicInfoViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    token = await TokenExtracter.ExtractTokenAsync(User, userManager);
                    EmployeeBasicInfoViewModel basicInfoViewModel = await employeeBasicInfoBLL.UpdateEmployeeBasic(model, token);
                    if (basicInfoViewModel != null)
                    {
                        return Ok(new { status = 200, obj = basicInfoViewModel, message = "Employee Basic updated successfully." });
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