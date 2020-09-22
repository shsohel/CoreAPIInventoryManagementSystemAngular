using CommonBLL.Enums;
using CommonBLL.Helper;
using CommonDAL.Models;
using CommonDAL.Repository;
using CommonDAL.ViewModels;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AdminBLL
{
    public class CategoryBLL
    {
        private readonly IRepository<Category> repository;
        private readonly UserManager<User> userManager;

        public CategoryBLL(IRepository<Category> repository, UserManager<User> userManager)
        {
            this.repository = repository;
            this.userManager = userManager;
        }
        public async Task<IEnumerable<CategoryViewModel>> GetCategories()
        {
            try
            {
                IEnumerable<Category> categories = await repository.GetAsync();
                List<CategoryViewModel> categoryViewModels = new List<CategoryViewModel>();
                if (categories != null)
                {
                    foreach (Category category in categories)
                    {
                        categoryViewModels.Add(assignDataToCategoryViewModel(category));
                    }
                    return categoryViewModels;
                }
            }
            catch (Exception e)
            {

            }
            return null;
        }
        public async Task<CategoryViewModel> GetCategory(int id)
        {
            try
            {
                Category category = await repository.GetAsync(id);
                if (category != null)
                {
                    return assignDataToCategoryViewModel(category);
                }
            }
            catch (Exception e)
            {
                e.Message.Contains("Something Wrong");
            }
            return null;
        }
        public async Task<CategoryViewModel> AddCategory(CategoryViewModel model, ApplicationUser token)
        {
            try
            {
                Category category = new Category
                {
                  //  Id = (int)model.Id,
                    CategoryNo= DateTime.Now.ToString("ddMMyyhhmmssmmm"),
                    Name = model.Name,
                    ParentId = model.ParentId,
                    Priority = model.Priority,
                    Description = model.Description,
                    OrganizationId=token.OrganizationId,
                    ShopId=token.ShopId,
                    CreatedBy = token.Id,
                    CreatedDate = DateTime.Now,
                    Status = (byte)Status.Active
                };
                Category result = await repository.AddAsync(category);
                model.Id = result.Id;
                if (result != null)
                {
                    return assignDataToCategoryViewModel(result);
                }
            }
            catch (Exception e)
            {

            }
            return null;
        }
        public async Task<CategoryViewModel> UpdateCategory(CategoryViewModel model, ApplicationUser token)
        {
            try
            {
                Category category = await repository.GetAsync(model.Id);
                if (category != null)
                {
                    category.Name = model.Name;
                    category.ParentId = (int)model.ParentId;
                    category.Priority = model.Priority;
                    category.Description = model.Description;
                    category.ModifiedBy = token.Id;
                    category.ModifiedDate = DateTime.Now;
                   // category.Status = (byte)Status.Active;
                    Category result = await repository.UpdateAsync(category);
                    if (result != null)
                    {
                        return assignDataToCategoryViewModel(result);
                    }
                }
            }
            catch (Exception e)
            {

            }
            return null;
        }
        public async Task<CategoryViewModel> DeleteCategory(int id)
        {
            try
            {
                Category category = await repository.GetAsync(id);
                if (category != null)
                {
                    Category result = await repository.DeleteAsync(category);
                    if (result != null)
                    {
                        return assignDataToCategoryViewModel(result);
                    }
                }
            }
            catch (Exception e)
            {

            }
            return null;
        }
        public async Task<CategoryViewModel> GetDetails(int id)
        {
            try
            {
                Category category = await repository.GetAsync(id);
                if (category != null)
                {
                    CategoryDetailsViewModel categoryViewModel = new CategoryDetailsViewModel
                    {
                        Id = category.Id,
                        Name = category.Name,
                        CategoryNo=category.CategoryNo,
                        ParentId = category.ParentId,
                        Priority = category.Priority,
                        Description = category.Description,
                        CreatedByName = category.CreatedBy != null ? userManager.FindByIdAsync(category.CreatedBy).Result.UserName : null,
                        CreatedDateString = category.CreatedDate != null ? Formater.FormatDateddMMyyyy((DateTime)category.CreatedDate) : null,
                        ModifiedByName = category.ModifiedBy != null ? userManager.FindByIdAsync(category.ModifiedBy).Result.UserName : null,
                        ModifiedDateString = category.ModifiedDate != null ? Formater.FormatDateddMMyyyy((DateTime)category.ModifiedDate) : null,
                        Status = category.Status
                    };
                    return categoryViewModel;
                }
            }
            catch (Exception e)
            {

            }
            return null;
        }
        public async Task<List<CategoryViewModel>> GetTableData()
        {
            try
            {
                IEnumerable<Category> categories = await repository.GetAsync();
                List<CategoryViewModel> categoryViewModels = new List<CategoryViewModel>();
                foreach (Category category in categories)
                {
                    CategoryViewModel categoryViewModel = new CategoryViewModel
                    {
                        Id = category.Id,
                        Name = category.Name,
                        CategoryNo=category.CategoryNo,
                        ParentId = category.ParentId,
                        Priority = category.Priority,
                        Description = category.Description,
                        Status = category.Status
                    };
                    categoryViewModels.Add(categoryViewModel);
                }
                if (categoryViewModels != null)
                {
                    return categoryViewModels;
                }
            }
            catch (Exception e)
            {

            }
            return null;
        }
        public CategoryViewModel assignDataToCategoryViewModel(Category category)
        {
            CategoryViewModel  categoryViewModel = new CategoryViewModel
            {
                Id = category.Id,
                Name=category.Name,
                CategoryNo = category.CategoryNo,
                ParentId = category.ParentId,
                Priority=category.Priority,
                Description=category.Description,
            //    CreatedBy = category.CreatedBy,
                CreatedDate = Convert.ToDateTime(category.CreatedDate),
             //   ModifiedBy = category.ModifiedBy,
                ModifiedDate = Convert.ToDateTime(category.ModifiedDate),
                Status = category.Status
            };
            return categoryViewModel;
        }
    }
}