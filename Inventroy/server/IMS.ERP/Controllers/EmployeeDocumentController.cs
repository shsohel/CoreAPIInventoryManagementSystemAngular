using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AdminBLL;
using CommonBLL.Helper;
using CommonDAL.Models;
using CommonDAL.Repository;
using CommonDAL.ViewModels;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace IMSERP.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeDocumentController : ControllerBase
    {
        private string message = "Sorry! Something going wrong. Please try again.";
        private readonly IRepository<EmployeeDocument> repository;
        private ApplicationUser toekn;
        private readonly IHostingEnvironment hostingEnvironment;
        private readonly UserManager<User> userManager;
        private ApplicationUser token;
        private EmployeeDocumentBLL employeeDocumentBLL;
        public EmployeeDocumentController(IRepository<EmployeeDocument> repository, IHostingEnvironment hostingEnvironment, IRepository<Employee> emRepository, UserManager<User> userManager)
        {
            employeeDocumentBLL = new EmployeeDocumentBLL(repository, emRepository, userManager);
            this.hostingEnvironment = hostingEnvironment;
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
                    List<EmployeeDocumentViewModel> employeeDocumentViewModels = await employeeDocumentBLL.GetEmployeeDocument(id);
                    if (employeeDocumentViewModels != null)
                    {
                        return Ok(new { status = 200, obj = employeeDocumentViewModels, message = "Employee Documents Info data retrive successfull." });
                    }
                }
                else
                {
                    IEnumerable<EmployeeDocumentViewModel> employeeDocumentViewModels = await employeeDocumentBLL.GetEmployeeDocuments();
                    if (employeeDocumentViewModels.Count() > 0)
                    {
                        return Ok(new { status = 200, obj = employeeDocumentViewModels, message = "Employee Documents data retrive successfull." });
                    }
                }
            }
            catch (Exception e)
            {

            }
            return BadRequest(new { status = 404, message = message });
        }
        [HttpPost]
        public async Task<ActionResult> Post(CreateUpdateEmpDocumentViewModel model)
        {
            try
            {
                //  var data = JsonConvert.DeserializeObject<EmployeeEduQualViewModel[]>(model.EmployeeEduQualViewModels);
                if (ModelState.IsValid)
                {
                    token = await TokenExtracter.ExtractTokenAsync(User, userManager);
                    CreateUpdateEmpDocumentViewModel employeeEduQualViewModels = await employeeDocumentBLL.AddEmployeeDocument(model, hostingEnvironment, token);
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
        public async Task<ActionResult> Put(CreateUpdateEmpDocumentViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    token = await TokenExtracter.ExtractTokenAsync(User, userManager);
                    CreateUpdateEmpDocumentViewModel employeeDocumentViewModels = await employeeDocumentBLL.UpdateEmployeeDocument(model, hostingEnvironment, token);
                    if (employeeDocumentViewModels != null)
                    {
                        return Ok(new { status = 200, obj = employeeDocumentViewModels, message = "Employee Document updated successfully." });
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