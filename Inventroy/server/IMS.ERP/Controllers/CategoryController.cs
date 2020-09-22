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
    public class CategoryController : ControllerBase
    {
        private string message = "Sorry! Something going wrong. Please try again.";
        private readonly IRepository<Category> repository;
        private readonly UserManager<User> userManager;
        private CategoryBLL categoryBLL;
        private ApplicationUser token;

        public CategoryController(IRepository<Category> repository, UserManager<User> userManager)
        {
            categoryBLL = new CategoryBLL(repository, userManager);
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
                    CategoryViewModel categoryViewModel = await categoryBLL.GetCategory(id);
                    if (categoryViewModel != null)
                    {
                        return Ok(new { status = 200, obj = categoryViewModel, message = "Category data retrive successfully." });
                    }
                }
                else
                {
                    IEnumerable<CategoryViewModel> categoryViewModels = await categoryBLL.GetCategories();
                    if (categoryViewModels.Count() > 0)
                    {
                        return Ok(new { status = 200, obj = categoryViewModels, message = "Categrories data retrive successfull." });
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
        public async Task<ActionResult> Post(CategoryViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    token = await TokenExtracter.ExtractTokenAsync(User, userManager);
                    CategoryViewModel categoryViewModel = await categoryBLL.AddCategory(model, token);
                    if (categoryViewModel != null)
                    {
                        return Ok(new { status = 200, obj = categoryViewModel, message = "Category has been created successfully." });
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
        public async Task<ActionResult> Put(CategoryViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    token = await TokenExtracter.ExtractTokenAsync(User, userManager);
                    CategoryViewModel categoryViewModel = await categoryBLL.UpdateCategory(model, token);
                    if (categoryViewModel != null)
                    {
                        return Ok(new { status = 200, obj = categoryViewModel, message = "Category has been updated successfully." });
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
                CategoryViewModel categoryViewModel = await categoryBLL.DeleteCategory(id);
                if (categoryViewModel != null)
                {
                    return Ok(new { status = 200, obj = categoryViewModel, message = "Category has been Deleted successfull." });
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
                CategoryViewModel categoryViewModel = await categoryBLL.GetDetails(id);
                if (categoryViewModel != null)
                {
                    return Ok(new { status = 200, obj = categoryViewModel, message = "Category details data retrive successfull." });
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
                List<CategoryViewModel> categoryViewModels = await categoryBLL.GetTableData();
                if (categoryViewModels != null)
                {
                    return Ok(new { status = 200, obj = categoryViewModels, message = "Category table data retrive successfully." });
                }
            }
            catch (Exception e)
            {

            }
            return BadRequest(new { status = 404, message = message });
        }
    }
}