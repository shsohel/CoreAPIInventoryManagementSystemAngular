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
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace IMSERP.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class OrganizationController : ControllerBase
    {
        private string message = "Sorry! Something going wrong. Please try again.";
        private readonly IRepository<Organization> repository;
        private OrganizationBLL organizationBLL;
        private readonly IHostingEnvironment hostingEnvironment;
        private readonly UserManager<User> userManager;
        private ApplicationUser token;
        public OrganizationController(IRepository<Organization> repository, IHostingEnvironment hostingEnvironment, UserManager<User> userManager)
        {
            organizationBLL = new OrganizationBLL(repository);
            this.hostingEnvironment = hostingEnvironment;
            this.userManager = userManager;
        }
        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult> Get(int id)
        {
            try
            {
                if (id > 0)
                {
                    OrganizationViewModel organizationViewModel = await organizationBLL.GetOrganization(id);
                    if (organizationViewModel != null)
                    {
                        return Ok(new { status = 200, obj = organizationViewModel, message = "Organization data retrive successfull." });
                    }
                }
                else
                {
                    IEnumerable<OrganizationViewModel> organizationViewModels = await organizationBLL.GetOrganizations();
                    if (organizationViewModels.Count() > 0)
                    {
                        return Ok(new { status = 200, obj = organizationViewModels, message = "Organization data retrive successfull." });
                    }
                }
            }
            catch (Exception e)
            {

            }
            return BadRequest(new { status = 404, message = message });
        }
        [HttpPost]
        public async Task<ActionResult> Post(OrganizationViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    token = await TokenExtracter.ExtractTokenAsync(User, userManager);
                    OrganizationViewModel organizationViewModel = await organizationBLL.AddOrganization(model, hostingEnvironment, token);
                    if (organizationViewModel != null)
                    {
                        return Ok(new { status = 200, obj = organizationViewModel, message = "Organization created successfull." });
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
        public async Task<ActionResult> Put(OrganizationViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    token = await TokenExtracter.ExtractTokenAsync(User, userManager);
                    OrganizationViewModel organizationViewModel = await organizationBLL.UpdateOrganization(model, hostingEnvironment, token);
                    if (organizationViewModel != null)
                    {
                        return Ok(new { status = 200, obj = organizationViewModel, message = "Organization updated successfull." });
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
                OrganizationViewModel organizationViewModel = await organizationBLL.DeleteOrganization(id);
                if (organizationViewModel != null)
                {
                    return Ok(new { status = 200, obj = organizationViewModel, message = "Organization has been Deleted successfully." });
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
                OrganizationViewModel organizationViewModel = await organizationBLL.GetDetails(id);
                if (organizationViewModel != null)
                {
                    return Ok(new { status = 200, obj = organizationViewModel, message = "Organization details data has retrive successfully." });
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
                List<OrganizationViewModel> organizationViewModels = await organizationBLL.GetTableData();
                if (organizationViewModels != null)
                {
                    return Ok(new { status = 200, obj = organizationViewModels, message = "Organization table data has retrive successfully." });
                }
            }
            catch (Exception e)
            {

            }
            return BadRequest(new { status = 404, message = message });
        }
    }
}