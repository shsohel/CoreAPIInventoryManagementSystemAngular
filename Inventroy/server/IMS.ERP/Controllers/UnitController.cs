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
    public class UnitController : ControllerBase
    {
        private string message = "Sorry! Something going wrong. Please try again.";
        private readonly IRepository<Unit> repository;
        private readonly UserManager<User> userManager;
        private UnitBLL unitBLL;
        private ApplicationUser token;

        public UnitController(IRepository<Unit> repository, UserManager<User> userManager)
        {
            unitBLL = new UnitBLL(repository, userManager);
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
                    UnitViewModel unitViewModel = await unitBLL.GetUnit(id);
                    if (unitViewModel != null)
                    {
                        return Ok(new { status = 200, obj = unitViewModel, message = "Unit data retrive successfully." });
                    }
                }
                else
                {
                    IEnumerable<UnitViewModel> unitViewModels = await unitBLL.GetUnits();
                    if (unitViewModels.Count() > 0)
                    {
                        return Ok(new { status = 200, obj = unitViewModels, message = "Units data retrive successfull." });
                    }
                }
            }
            catch (Exception e)
            {

            }
            return BadRequest(new { status = 404, message = message });
        }
        [HttpPost]
        [Route("create")]
        public async Task<ActionResult> Post(UnitViewModel model)
        {
            try
            {
                if (ModelState.IsValid)                    
                {
                    token = await TokenExtracter.ExtractTokenAsync(User, userManager);
                    UnitViewModel unitViewModel = await unitBLL.AddUnit(model, token);
                    if (unitViewModel != null)
                    {
                        return Ok(new { status = 200, obj = unitViewModel, message = "Unit has been created successfully." });
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
        [Route("update")]
        public async Task<ActionResult> Put(UnitViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    token = await TokenExtracter.ExtractTokenAsync(User, userManager);

                    UnitViewModel unitViewModel = await unitBLL.UpdateUnit(model, token);
                    if (unitViewModel != null)
                    {
                        return Ok(new { status = 200, obj = unitViewModel, message = "Unit has been updated successfully." });
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
                token = await TokenExtracter.ExtractTokenAsync(User, userManager);
                UnitViewModel unitViewModel = await unitBLL.DeleteUnit(id);
                if (unitViewModel != null)
                {
                    return Ok(new { status = 200, obj = unitViewModel, message = "Unit has been Deleted successfull." });
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
                UnitViewModel unitViewModel = await unitBLL.GetDetails(id);
                if (unitViewModel != null)
                {
                    return Ok(new { status = 200, obj = unitViewModel, message = "Unit details data retrive successfully." });
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
                List<UnitViewModel> unitViewModels = await unitBLL.GetTableData();
                if (unitViewModels != null)
                {
                    return Ok(new { status = 200, obj = unitViewModels, message = "Unit table data retrive successfully." });
                }
            }
            catch (Exception e)
            {

            }
            return BadRequest(new { status = 404, message = message });
        }
    }
}