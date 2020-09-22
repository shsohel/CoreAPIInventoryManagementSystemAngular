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
    public class SpecificationAttrValueController : ControllerBase
    {
        private string message = "Sorry! Something going wrong. Please try again.";
        private ApplicationUser toekn;
        private readonly UserManager<User> userManager;
        private ApplicationUser token;
        private SpecificationAttrValueBLL specificationAttrValueBLL;
        public SpecificationAttrValueController(IRepository<SpecificationAttribute> attriRepository, IRepository<SpecificationAttrValue> attrValueRepository, UserManager<User> userManager)
        {
            specificationAttrValueBLL = new SpecificationAttrValueBLL(attriRepository, attrValueRepository, userManager);
            this.userManager = userManager;
        }
        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult> Get(int id)
        {
            try
            {
                toekn = await TokenExtracter.ExtractTokenAsync(User, userManager);
                if (id > 0)
                {
                    List<SpecificationAttrValueViewModel> specificationAttrValueViewModels = await specificationAttrValueBLL.GetAttriValuebyAttributeId(id);
                    if (specificationAttrValueViewModels != null)
                    {
                        return Ok(new { status = 200, obj = specificationAttrValueViewModels, message = " Attribute Value data retrive successfull." });
                    }
                }
                else
                {
                    IEnumerable<SpecificationAttrValueViewModel> specificationAttrValueViewModels = await specificationAttrValueBLL.GetAttrValues();
                    if (specificationAttrValueViewModels.Count() > 0)
                    {
                        return Ok(new { status = 200, obj = specificationAttrValueViewModels, message = "Attribute Value retrive successfull." });
                    }
                }
            }
            catch (Exception e)
            {

            }
            return BadRequest(new { status = 404, message = message });
        }
        [HttpPost]
        public async Task<ActionResult> Post(ExtraSpAttrValueViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    token = await TokenExtracter.ExtractTokenAsync(User, userManager);
                    ExtraSpAttrValueViewModel extraSpAttrValue = await specificationAttrValueBLL.AddSpAttrValue(model, token);
                    if (extraSpAttrValue != null)
                    {
                        return Ok(new { status = 200, obj = extraSpAttrValue, message = "Attribute Value created successfull." });
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
        public async Task<ActionResult> Put(ExtraSpAttrValueViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    token = await TokenExtracter.ExtractTokenAsync(User, userManager);
                    ExtraSpAttrValueViewModel extraSpAttrValue = await specificationAttrValueBLL.UpdateSpAttrValue(model, token);
                    if (extraSpAttrValue != null)
                    {
                        return Ok(new { status = 200, obj = extraSpAttrValue, message = "Attribute Value updated successfully." });
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
        public async Task<ActionResult> Delete(int id)
        {
            try
            {
                List<SpecificationAttrValueViewModel> specificationAttrValueViewModel = await specificationAttrValueBLL.DeleteSpAttrValue(id);
                if (specificationAttrValueViewModel != null)
                {
                    return Ok(new { status = 200, obj = specificationAttrValueViewModel, message = "Attribute Value Deleted successfull." });
                }
            }
            catch (Exception e)
            {

            }
            return BadRequest(new { status = 404, message = message });
        }
        //[HttpGet]
        //[Route("details/{id}")]
        //public async Task<ActionResult> GetDetails(long id)
        //{
        //    try
        //    {
        //        EmployeeViewModel employeeViewModel = await employeeBLL.GetDetails(id);
        //        if (employeeViewModel != null)
        //        {
        //            return Ok(new { status = 200, obj = employeeViewModel, message = "Attribute Value details data retrive successfull." });
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
        //            return Ok(new { status = 200, obj = employeeViewModels, message = "Attribute Value table data retrive successfull." });
        //        }
        //    }
        //    catch (Exception e)
        //    {

        //    }
        //    return BadRequest(new { status = 404, message = message });
        //}
    }
}