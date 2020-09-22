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
    public class SpecificationAttributeController : ControllerBase
    {
        private string message = "Sorry! Something going wrong. Please try again.";
        private readonly IRepository<ProductAttributeMapping> repository;
        private ApplicationUser toekn;
        private readonly UserManager<User> userManager;
        private ApplicationUser token;
        private SpecificationAttributeBLL specificationAttributeBLL;
        public SpecificationAttributeController(IRepository<SpecificationAttribute> attrRepository, IRepository<SpecificationAttrValue> attrValueRepository,
            UserManager<User> userManager)
        {
            specificationAttributeBLL = new SpecificationAttributeBLL(attrRepository, attrValueRepository, userManager);
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
                    SpecificationAttributeViewModel specificationAttributeViewModel = await specificationAttributeBLL.GetSpecificationAttribute(id);
                    if (specificationAttributeViewModel != null)
                    {
                        return Ok(new { status = 200, obj = specificationAttributeViewModel, message = "Specification Attribute data retrive successfull." });
                    }
                }
                else
                {
                    IEnumerable<SpecificationAttributeViewModel> specificationAttributeViewModels = await specificationAttributeBLL.GetSpAttributes();
                    if (specificationAttributeViewModels.Count() > 0)
                    {
                        return Ok(new { status = 200, obj = specificationAttributeViewModels, message = "Specification Attribute retrived successfull." });
                    }
                }
            }
            catch (Exception e)
            {

            }
            return BadRequest(new { status = 404, message = message });
        }
        [HttpPost]
        public async Task<ActionResult> Post(SpecificationAttributeViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    token = await TokenExtracter.ExtractTokenAsync(User, userManager);
                    SpecificationAttributeViewModel specificationAttributeViewModel = await specificationAttributeBLL.AddSpecificationAttribute(model, token);
                    if (specificationAttributeViewModel != null)
                    {
                        return Ok(new { status = 200, obj = specificationAttributeViewModel, message = "Specification Attribute created successfull." });
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
        public async Task<ActionResult> Put(SpecificationAttributeViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    token = await TokenExtracter.ExtractTokenAsync(User, userManager);
                    SpecificationAttributeViewModel specificationAttributeViewModel = await specificationAttributeBLL.UpdateSpecificationAttribute(model, token);
                    if (specificationAttributeViewModel != null)
                    {
                        return Ok(new { status = 200, obj = specificationAttributeViewModel, message = "Specification Attribute updated successfully." });
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
                SpecificationAttributeViewModel specificationAttributeViewModel = await specificationAttributeBLL.DeleteSpecificationAttribute(id);
                if (specificationAttributeViewModel != null)
                {
                    return Ok(new { status = 200, obj = specificationAttributeViewModel, message = "Specification Attribute  Deleted successfull." });
                }
            }
            catch (Exception e)
            {

            }
            return BadRequest(new { status = 404, message = message });
        }
        [HttpGet]
        [Route("details/{id}")]
        public async Task<ActionResult> GetDetails(int id)
        {
            try
            {
                FullAttributeDetailsViewModel fullAttributeDetailsViewModel = await specificationAttributeBLL.GetDetails(id);
                if (fullAttributeDetailsViewModel != null)
                {
                    return Ok(new { status = 200, obj = fullAttributeDetailsViewModel, message = "Specification Attribute  details data retrive successfull." });
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
                List<SpecificationAttributeViewModel> specificationAttributeViewModels = await specificationAttributeBLL.GetTableData();
                if (specificationAttributeViewModels != null)
                {
                    return Ok(new { status = 200, obj = specificationAttributeViewModels, message = "Specification Attribute  table data retrive successfull." });
                }
            }
            catch (Exception e)
            {

            }
            return BadRequest(new { status = 404, message = message });
        }
    }
}