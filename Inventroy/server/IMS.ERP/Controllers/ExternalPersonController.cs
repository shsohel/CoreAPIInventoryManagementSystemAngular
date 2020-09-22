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
    public class ExternalPersonController : ControllerBase
    {
        private string message = "Sorry! Something going wrong. Please try again.";
        private readonly IRepository<ExternalPerson> repository;
        private readonly UserManager<User> userManager;
        private ExternalPersonBLL externalPersonBLL;
        private ApplicationUser token;
        public ExternalPersonController(IRepository<ExternalPerson> repository, UserManager<User> userManager)
        {
            externalPersonBLL = new ExternalPersonBLL(repository, userManager);
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
                    ExternalPersonViewModel externalPersonViewModel = await externalPersonBLL.GetExternalPerson(id);
                    if (externalPersonViewModel != null)
                    {
                        return Ok(new { status = 200, obj = externalPersonViewModel, message = "External Person data retrive successfull." });
                    }
                }
                else
                {
                    IEnumerable<ExternalPersonViewModel> externalPersonViewModel = await externalPersonBLL.GetExternalPersons();
                    if (externalPersonViewModel.Count() > 0)
                    {
                        return Ok(new { status = 200, obj = externalPersonViewModel, message = "External Person data retrive successfull." });
                    }
                }
            }
            catch (Exception e)
            {

            }
            return BadRequest(new { status = 404, message = message });
        }
        [HttpPost]
        public async Task<ActionResult> Post(ExternalPersonViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    token = await TokenExtracter.ExtractTokenAsync(User, userManager);
                    ExternalPersonViewModel externalPersonViewModel = await externalPersonBLL.AddExternalPerson(model, token);
                    if (externalPersonViewModel != null)
                    {
                        return Ok(new { status = 200, obj = externalPersonViewModel, message = "External Person created successfull." });
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
        public async Task<ActionResult> Put(ExternalPersonViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    token = await TokenExtracter.ExtractTokenAsync(User, userManager);
                    ExternalPersonViewModel externalPersonViewModel = await externalPersonBLL.UpdateExternalPerson(model, token);
                    if (externalPersonViewModel != null)
                    {
                        return Ok(new { status = 200, obj = externalPersonViewModel, message = "External Person updated successfull." });
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
        public async Task<ActionResult> Delete(long id)
        {
            try
            {
                token = await TokenExtracter.ExtractTokenAsync(User, userManager);
                ExternalPersonViewModel externalPersonViewModel = await externalPersonBLL.DeleteExternalPerson(id);
                if (externalPersonViewModel != null)
                {
                    return Ok(new { status = 200, obj = externalPersonViewModel, message = "External Person Deleted successfull." });
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
                ExternalPersonDetailsViewModel externalPersonDetailsViewModel = await externalPersonBLL.GetDetails(id);
                if (externalPersonDetailsViewModel != null)
                {
                    return Ok(new { status = 200, obj = externalPersonDetailsViewModel, message = "External Person details retrive successfull." });
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
                List<ExternalPersonDetailsViewModel> externalPersonDetailsViewModel = await externalPersonBLL.GetTableData();
                if (externalPersonDetailsViewModel != null)
                {
                    return Ok(new { status = 200, obj = externalPersonDetailsViewModel, message = "External Person table data retrive successfull." });
                }
            }
            catch (Exception e)
            {

            }
            return BadRequest(new { status = 404, message = message });
        }
    }
}