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
    public class ManufacturerController : ControllerBase
    {
        private string message = "Sorry! Something going wrong. Please try again.";
        private ApplicationUser toekn;
        private readonly UserManager<User> userManager;
        private ApplicationUser token;
        private ManufacturerBLL manufacturerBLL;
        public ManufacturerController(IRepository<Manufacturer> repository, UserManager<User> userManager)
        {
            manufacturerBLL = new ManufacturerBLL(repository, userManager);
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
                    ManufacturerViewModel manufacturerViewModel = await manufacturerBLL.GetManufacturer(id);
                    if (manufacturerViewModel != null)
                    {
                        return Ok(new { status = 200, obj = manufacturerViewModel, message = "Manufacturer data retrive successfull." });
                    }
                }
                else
                {
                    IEnumerable<ManufacturerViewModel> manufacturerViewModels = await manufacturerBLL.GetManufacturers();
                    if (manufacturerViewModels.Count() > 0)
                    {
                        return Ok(new { status = 200, obj = manufacturerViewModels, message = "Manufacturer data retrive successfull." });
                    }
                }
            }
            catch (Exception e)
            {

            }
            return BadRequest(new { status = 404, message = message });
        }
        [HttpPost]
        public async Task<ActionResult> Post(ManufacturerViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    token = await TokenExtracter.ExtractTokenAsync(User, userManager);
                    ManufacturerViewModel manufacturerViewModel = await manufacturerBLL.AddManufacturer(model, token);
                    if (manufacturerViewModel != null)
                    {
                        return Ok(new { status = 200, obj = manufacturerViewModel, message = "Manufacturer created successfull." });
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
        public async Task<ActionResult> Put(ManufacturerViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    token = await TokenExtracter.ExtractTokenAsync(User, userManager);
                    ManufacturerViewModel manufacturerViewModel = await manufacturerBLL.UpdateManufacturer(model, token);
                    if (manufacturerViewModel != null)
                    {
                        return Ok(new { status = 200, obj = manufacturerViewModel, message = "Manufacturer updated successfully." });
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
                ManufacturerViewModel manufacturerViewModel = await manufacturerBLL.DeleteManufacturer(id);
                if (manufacturerViewModel != null)
                {
                    return Ok(new { status = 200, obj = manufacturerViewModel, message = "Manufacturer Deleted successfull." });
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
                ManufacturerViewModel manufacturerViewModel = await manufacturerBLL.GetDetails(id);
                if (manufacturerViewModel != null)
                {
                    return Ok(new { status = 200, obj = manufacturerViewModel, message = "Manufacterer details data retrive successfull." });
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
                List<ManufacturerViewModel> manufacturerViewModels = await manufacturerBLL.GetTableData();
                if (manufacturerViewModels != null)
                {
                    return Ok(new { status = 200, obj = manufacturerViewModels, message = "Manufacterer table data retrive successfull." });
                }
            }
            catch (Exception e)
            {

            }
            return BadRequest(new { status = 404, message = message });
        }
    }
}