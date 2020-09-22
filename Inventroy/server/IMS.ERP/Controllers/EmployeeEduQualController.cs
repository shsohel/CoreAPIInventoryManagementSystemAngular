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
using Newtonsoft.Json;

namespace IMSERP.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeEduQualController : ControllerBase
    {
        private string message = "Sorry! Something going wrong. Please try again.";
        private readonly IRepository<EmployeeEduQual> repository;
        private ApplicationUser toekn;
        private readonly UserManager<User> userManager;
        private ApplicationUser token;
        private EmployeeEduQualBLL employeeEduQualBLL;
        public EmployeeEduQualController(IRepository<EmployeeEduQual> repository, IRepository<Employee> emRepository, UserManager<User> userManager)
        {
            employeeEduQualBLL = new EmployeeEduQualBLL(repository, emRepository, userManager);
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
                    List<EmployeeEduQualViewModel> employeeEduQualViewModels = await employeeEduQualBLL.GetEmployeeEduQual(id);
                    if (employeeEduQualViewModels != null)
                    {
                        return Ok(new { status = 200, obj = employeeEduQualViewModels, message = "Employee Education Qualification Info data retrive successfull." });
                    }
                }
                else
                {
                    IEnumerable<EmployeeEduQualViewModel> employeeViewModels = await employeeEduQualBLL.GetEmployeeEduQuals();
                    if (employeeViewModels.Count() > 0)
                    {
                        return Ok(new { status = 200, obj = employeeViewModels, message = "Employee Education Qualification data retrive successfull." });
                    }
                }
            }
            catch (Exception e)
            {

            }
            return BadRequest(new { status = 404, message = message });
        }
        [HttpPost]
        public async Task<ActionResult> Post(CreateEduQualViewModel model)
        {
            try
            {
              //  var data = JsonConvert.DeserializeObject<EmployeeEduQualViewModel[]>(model.EmployeeEduQualViewModels);
                if (ModelState.IsValid)
                {
                    token = await TokenExtracter.ExtractTokenAsync(User, userManager);
                   CreateEduQualViewModel employeeEduQualViewModels = await employeeEduQualBLL.AddEmployeeEduQual(model, token);
                    if (employeeEduQualViewModels != null)
                    {
                        return Ok(new { status = 200, obj = employeeEduQualViewModels, message = "Employee Education Qualification created successfull." });
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
        public async Task<ActionResult> Put(CreateEduQualViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    token = await TokenExtracter.ExtractTokenAsync(User, userManager);
                    CreateEduQualViewModel employeeViewModels = await employeeEduQualBLL.UpdateEmployeeQual(model, token);
                    if (employeeViewModels != null)
                    {
                        return Ok(new { status = 200, obj = employeeViewModels, message = "Employee updated successfully." });
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