using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CommonBLL.Helper;
using CommonDAL.Models;
using CommonDAL.Repository;
using CommonDAL.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using StockBLL;

namespace IMSERP.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class WarehouseController : ControllerBase
    {
        private string message = "Sorry! Something going wrong. Please try again.";
        private readonly IRepository<Warehouse> repository;
        private readonly UserManager<User> userManager;
        private WarehouseBLL warehouseBLL;
        private ApplicationUser token;
        public WarehouseController(IRepository<Warehouse> repository, UserManager<User> userManager)
        {
            warehouseBLL = new WarehouseBLL(repository, userManager);
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
                    WarehouseViewModel warehouseViewModel = await warehouseBLL.GetWarehouse(id);
                    if (warehouseViewModel != null)
                    {
                        return Ok(new { status = 200, obj = warehouseViewModel, message = "Warehouse data retrive successfull." });
                    }
                }
                else
                {
                    IEnumerable<WarehouseViewModel> warehouseViewModels = await warehouseBLL.GetWarehouses();
                    if (warehouseViewModels.Count() > 0)
                    {
                        return Ok(new { status = 200, obj = warehouseViewModels, message = "Warehouse data retrive successfull." });
                    }
                }
            }
            catch (Exception e)
            {

            }
            return BadRequest(new { status = 404, message = message });
        }
        [HttpPost]
        public async Task<ActionResult> Post(WarehouseViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    token = await TokenExtracter.ExtractTokenAsync(User, userManager);
                    WarehouseViewModel warehouseViewModel = await warehouseBLL.AddWarehouse(model, token);
                    if (warehouseViewModel != null)
                    {
                        return Ok(new { status = 200, obj = warehouseViewModel, message = "Warehouse created successfull." });
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
        public async Task<ActionResult> Put(WarehouseViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    token = await TokenExtracter.ExtractTokenAsync(User, userManager);
                    WarehouseViewModel warehouseViewModel = await warehouseBLL.UpdateWarehouse(model, token);
                    if (warehouseViewModel != null)
                    {
                        return Ok(new { status = 200, obj = warehouseViewModel, message = "Warehouse updated successfull." });
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
                WarehouseViewModel warehouseViewModel = await warehouseBLL.DeleteWarehouse(id);
                if (warehouseViewModel != null)
                {
                    return Ok(new { status = 200, obj = warehouseViewModel, message = "Warehouse Deleted successfull." });
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
                WarehouseDetailsViewModel warehouseDetailsViewModel = await warehouseBLL.GetDetails(id);
                if (warehouseDetailsViewModel != null)
                {
                    return Ok(new { status = 200, obj = warehouseDetailsViewModel, message = "Warehouse details data retrive successfull." });
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
                List<WarehouseDetailsViewModel> warehouseDetailsViewModel = await warehouseBLL.GetTableData();
                if (warehouseDetailsViewModel != null)
                {
                    return Ok(new { status = 200, obj = warehouseDetailsViewModel, message = "Warehouse table data retrive successfull." });
                }
            }
            catch (Exception e)
            {

            }
            return BadRequest(new { status = 404, message = message });
        }
    }
}