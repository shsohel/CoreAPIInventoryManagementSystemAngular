using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CommonBLL.Helper;
using CommonDAL.Models;
using CommonDAL.Repository;
using CommonDAL.ViewModels;
using FinanceBLL;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace IMSERP.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class BusinessRelativeController : ControllerBase
    {
        private string message = "Sorry! Something going wrong. Please try again.";
        private readonly IRepository<BusinessRelative> repository;
        private readonly UserManager<User> userManager;
        private BusinessRelativeBLL businessRelativeBLL;
        private ApplicationUser token;
        public BusinessRelativeController(IRepository<BusinessRelative> repository, UserManager<User> userManager)
        {
            businessRelativeBLL = new BusinessRelativeBLL(repository, userManager);
            this.userManager = userManager;
        }
        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult> Get(int id)
        {
            try
            {
                token = await TokenExtracter.ExtractTokenAsync(User, userManager);
                if (id > 0)
                {
                    BusinessRelativeViewModel businessRelativeViewModel = await businessRelativeBLL.GetBusinessRelative(id);
                    if (businessRelativeViewModel != null)
                    {
                        return Ok(new { status = 200, obj = businessRelativeViewModel, message = "Business Relative data retrive successfull." });
                    }
                }
                else
                {
                    IEnumerable<BusinessRelativeViewModel> businessRelativeViewModels = await businessRelativeBLL.GetBusinessRelatives();
                    if (businessRelativeViewModels.Count() > 0)
                    {
                        return Ok(new { status = 200, obj = businessRelativeViewModels, message = "Business Relative data retrive successfull." });
                    }
                }
            }
            catch (Exception e)
            {

            }
            return BadRequest(new { status = 404, message = message });
        }
        [HttpPost]
        public async Task<ActionResult> Post(BusinessRelativeViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    token = await TokenExtracter.ExtractTokenAsync(User, userManager);
                    BusinessRelativeViewModel businessRelativeViewModel = await businessRelativeBLL.AddBusinessRelative(model, token);
                    if (businessRelativeViewModel != null)
                    {
                        return Ok(new { status = 200, obj = businessRelativeViewModel, message = "Business Relative created successfull." });
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
        public async Task<ActionResult> Put(BusinessRelativeViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    token = await TokenExtracter.ExtractTokenAsync(User, userManager);
                    BusinessRelativeViewModel businessRelativeViewModel = await businessRelativeBLL.UpdateBusinessRelative(model, token);
                    if (businessRelativeViewModel != null)
                    {
                        return Ok(new { status = 200, obj = businessRelativeViewModel, message = "Business Relative updated successfull." });
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
        public async Task<ActionResult> Delete(int id)
        {
            try
            {
                token = await TokenExtracter.ExtractTokenAsync(User, userManager);
                BusinessRelativeViewModel businessRelativeViewModel = await businessRelativeBLL.DeleteBusinessRelative(id);
                if (businessRelativeViewModel != null)
                {
                    return Ok(new { status = 200, obj = businessRelativeViewModel, message = "Business Relative Deleted successfull." });
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
                token = await TokenExtracter.ExtractTokenAsync(User, userManager);
                BusinessRelativeDetailsViewModel businessRelativeDetailsViewModel = await businessRelativeBLL.GetDetails(id);
                if (businessRelativeDetailsViewModel != null)
                {
                    return Ok(new { status = 200, obj = businessRelativeDetailsViewModel, message = "Business Relative details data retrive successfull." });
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
                List<BusinessRelativeDetailsViewModel> businessRelativeDetailsViewModel = await businessRelativeBLL.GetTableData();
                if (businessRelativeDetailsViewModel != null)
                {
                    return Ok(new { status = 200, obj = businessRelativeDetailsViewModel, message = "Business Relative table data retrive successfull." });
                }
            }
            catch (Exception e)
            {

            }
            return BadRequest(new { status = 404, message = message });
        }
    }
}