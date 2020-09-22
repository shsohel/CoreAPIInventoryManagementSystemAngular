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
    public class CustomerBLL
    {
        private readonly IRepository<Customer> repository;
        private readonly UserManager<User> userManager;

        public CustomerBLL(IRepository<Customer> repository, UserManager<User> userManager)
        {
            this.repository = repository;
            this.userManager = userManager;
        }
        public async Task<IEnumerable<CustomerViewModel>> GetCustomers()
        {
            try
            {
                IEnumerable<Customer> customers = await repository.GetAsync();
                List<CustomerViewModel> customerViewModels = new List<CustomerViewModel>();
                if (customers != null)
                {
                    foreach (Customer customer in customers)
                    {
                        customerViewModels.Add(assignDataToCustomerViewModel(customer));
                    }
                    return customerViewModels;
                }
            }
            catch (Exception e)
            {

            }
            return null;
        }
        public async Task<CustomerViewModel> GetCustomer(long id)
        {
            try
            {
                Customer customer = await repository.GetAsync(id);
                if (customer != null)
                {
                    return assignDataToCustomerViewModel(customer);
                }
            }
            catch (Exception e)
            {

            }
            return null;
        }
        public async Task<CustomerViewModel> AddCustomer(CustomerViewModel model, ApplicationUser token)
        {
            try
            {
                Customer customer = new Customer
                {
                    OrganizationId = token.OrganizationId,
                    ShopId = token.ShopId,
                    CustomerNo = DateTime.Now.ToString("ddMMyyhhmmssmmm"),
                    Name = model.Name,
                    Mobile = model.Mobile,
                    Address = model.Address,
                    CreatedBy = token.Id,
                    CreatedDate = DateTime.Now,
                    Status = (byte)Status.InActive
                };
                Customer result = await repository.AddAsync(customer);
                model.Id = result.Id;
                if (result != null)
                {
                    return assignDataToCustomerViewModel(result);
                }
            }
            catch (Exception e)
            {

            }
            return null;
        }
        public async Task<CustomerViewModel> UpdateCustomer(CustomerViewModel model, ApplicationUser token)
        {
            try
            {
                Customer customer = await repository.GetAsync((long)model.Id);
                if (customer != null)
                {
                    customer.Name = model.Name;
                    customer.Mobile = model.Mobile;
                    customer.ModifiedBy = token.Id;
                    customer.Address = model.Address;
                    customer.ModifiedDate = DateTime.Now;
                    customer.Status = (byte)Status.InActive;
                    Customer result = await repository.UpdateAsync(customer);
                    if (result != null)
                    {
                        return assignDataToCustomerViewModel(result);
                    }
                }
            }
            catch (Exception e)
            {

            }
            return null;
        }
        public async Task<CustomerViewModel> DeleteCustomer(long id)
        {
            try
            {
                Customer customer = await repository.GetAsync(id);
                if (customer != null)
                {
                    Customer result = await repository.DeleteAsync(customer);
                    if (result != null)
                    {
                        return assignDataToCustomerViewModel(result);
                    }
                }
            }
            catch (Exception e)
            {

            }
            return null;
        }
        public async Task<CustomerViewModel> GetDetails(long id)
        {
            try
            {
                Customer customer = await repository.GetAsync(id);
                if (customer != null)
                {
                    CustomerDetailsViewModel customerDetailsViewModel = new CustomerDetailsViewModel()
                    {
                        CustomerNo = customer.CustomerNo,
                        Name = customer.Name,
                        Mobile = customer.Mobile,
                        Address = customer.Address,
                        CreatedByName = customer.CreatedBy != null ? userManager.FindByIdAsync(customer.CreatedBy).Result.UserName : null,
                        CreatedDateString = customer.CreatedDate != null ? Formater.FormatDateddMMyyyy((DateTime)customer.CreatedDate) : null,
                        //ModifiedByName = customer.CreatedBy != null ? userManager.FindByIdAsync(customer.CreatedBy).Result.UserName : null,
                        ModifiedDateString = customer.ModifiedDate != null ? Formater.FormatDateddMMyyyy((DateTime)customer.ModifiedDate) : null,
                        Status = customer.Status
                    };
                    return customerDetailsViewModel;
                }

            }
            catch (Exception)
            {

            }
            return null;
        }
        public async Task<List<CustomerDetailsViewModel>> GetTableData()
        {
            try
            {
                IEnumerable<Customer> customers = await repository.GetAsync();
                List<CustomerDetailsViewModel> customerDetailsViewModels = new List<CustomerDetailsViewModel>();
                foreach (Customer customer in customers)
                {
                    CustomerDetailsViewModel customerDetailsViewModel = new CustomerDetailsViewModel
                    {
                        Id = customer.Id,
                        Name = customer.Name,
                        Mobile = customer.Mobile,
                        Address = customer.Address,
                        CustomerNo = customer.CustomerNo,
                        CreatedByName = customer.CreatedBy,
                        CreatedDate = customer.CreatedDate,
                        ModifiedByName = customer.ModifiedBy,
                        ModifiedDate = customer.ModifiedDate,
                        Status = customer.Status,
                    };
                    customerDetailsViewModels.Add(customerDetailsViewModel);
                }
                if (customerDetailsViewModels != null)
                {
                    return customerDetailsViewModels;
                }
            }
            catch (Exception e)
            {

            }
            return null;
        }
        public CustomerViewModel assignDataToCustomerViewModel(Customer customer)
        {
            CustomerViewModel customerViewModel = new CustomerViewModel
            {
                Id = customer.Id,
                OrganizationId = customer.OrganizationId,
                ShopId = customer.ShopId,
                CustomerNo = customer.CustomerNo,                
                Name = customer.Name,
                Mobile = customer.Mobile,
                Address = customer.Address,
                CreatedBy = customer.CreatedBy,
                CreatedDate = customer.CreatedDate,
                ModifiedBy = customer.ModifiedBy,
                ModifiedDate = customer.ModifiedDate,
                Status = customer.Status,
            };
            return customerViewModel;
        }

    }
}
