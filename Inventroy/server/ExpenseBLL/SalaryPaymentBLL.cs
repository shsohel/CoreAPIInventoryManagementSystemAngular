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

namespace ExpenseBLL
{
    public class SalaryPaymentBLL
    {
        private readonly IRepository<SalaryPayment> repository;
        private readonly UserManager<User> userManager;
        public readonly IRepository<Employee> emprepository;

        public SalaryPaymentBLL(IRepository<SalaryPayment> repository, UserManager<User> userManager, IRepository<Employee> emprepository)
        {
            this.repository = repository;
            this.userManager = userManager;
            this.emprepository = emprepository;
        }
        public async Task<IEnumerable<SalaryPaymentViewModel>> GetSalaryPayments()
        {
            try
            {
                IEnumerable<SalaryPayment> salaryPayments = await repository.GetAsync();
                List<SalaryPaymentViewModel> salaryPaymentViewModels = new List<SalaryPaymentViewModel>();
                if (salaryPayments != null)
                {
                    foreach (SalaryPayment salaryPayment in salaryPayments)
                    {
                        salaryPaymentViewModels.Add(assignDataToSalaryPaymentViewModel(salaryPayment));
                    }
                    return salaryPaymentViewModels;
                }
            }
            catch (Exception e)
            {

            }
            return null;
        }
        public async Task<SalaryPaymentViewModel> GetSalaryPayment(long id)
        {
            try
            {
                SalaryPayment salaryPayment = await repository.GetAsync(id);
                if (salaryPayment != null)
                {
                    return assignDataToSalaryPaymentViewModel(salaryPayment);
                }
            }
            catch (Exception e)
            {

            }
            return null;
        }
        public async Task<SalaryPaymentViewModel> AddSalaryPayment(SalaryPaymentViewModel model, ApplicationUser token)
        {
            try
            {
                SalaryPayment salaryPayment = new SalaryPayment
                {
                    OrganizationId = token.OrganizationId,
                    ShopId = token.ShopId,
                    SalaryPaymentNo = DateTime.Now.ToString("ddMMyyhhmmssmmm"),
                    PaidAmount = model.PaidAmount,
                    VoucherId = model.VoucherId,
                    SalaryPaymentDate = model.SalaryPaymentDate,
                    ExpenseHeadId = model.ExpenseHeadId,
                    EmployeeId = model.EmployeeId,
                    Note = model.Note,
                    CapturedBy = token.Id,
                    CapturedDate = DateTime.Now,
                    Status = (byte)Status.InActive
                };
                SalaryPayment result = await repository.AddAsync(salaryPayment);
                model.Id = result.Id;
                if (result != null)
                {
                    return assignDataToSalaryPaymentViewModel(result);
                }
            }
            catch (Exception e)
            {

            }
            return null;
        }
        public async Task<SalaryPaymentViewModel> UpdateSalaryPayment(SalaryPaymentViewModel model, ApplicationUser token)
        {
            try
            {
                SalaryPayment salaryPayment = await repository.GetAsync((long)model.Id);
                if (salaryPayment != null)
                {
                    salaryPayment.PaidAmount = model.PaidAmount;
                    salaryPayment.Note = model.Note;
                    salaryPayment.VoucherId = model.VoucherId;
                    salaryPayment.EmployeeId = model.EmployeeId;
                    salaryPayment.ExpenseHeadId = model.ExpenseHeadId;
                    salaryPayment.UpdatedBy = token.Id;
                    salaryPayment.SalaryPaymentDate = model.SalaryPaymentDate;
                    salaryPayment.UpdatedDate = DateTime.Now;
                    salaryPayment.Status = (byte)Status.Active;

                    SalaryPayment result = await repository.UpdateAsync(salaryPayment);
                    if (result != null)
                    {
                        return assignDataToSalaryPaymentViewModel(result);
                    }
                }
            }
            catch (Exception e)
            {

            }
            return null;
        }
        public async Task<SalaryPaymentViewModel> DeleteSalaryPayment(long id)
        {
            try
            {
                SalaryPayment salaryPayment = await repository.GetAsync(id);
                if (salaryPayment != null)
                {
                    SalaryPayment result = await repository.DeleteAsync(salaryPayment);
                    if (result != null)
                    {
                        return assignDataToSalaryPaymentViewModel(result);
                    }
                }
            }
            catch (Exception e)
            {

            }
            return null;
        }
        public async Task<SalaryPaymentDetailsViewModel> GetDetails(long id)
        {
            try
            {
                SalaryPayment salaryPayment = await repository.GetAsync(id);
                if (salaryPayment != null)
                {
                    SalaryPaymentDetailsViewModel salaryPaymentDetailsViewModel = new SalaryPaymentDetailsViewModel()
                    {
                        Id = salaryPayment.Id,
                        SalaryPaymentNo = salaryPayment.SalaryPaymentNo,
                        PaidAmount = salaryPayment.PaidAmount,
                        VoucherId = salaryPayment.VoucherId,
                        SalaryPaymentDateString = salaryPayment.SalaryPaymentDate != null ? Formater.FormatDateddMMyyyy((DateTime)salaryPayment.SalaryPaymentDate) : null,
                        Note = salaryPayment.Note,
                        EmployeeName = emprepository.GetAsync(salaryPayment.EmployeeId).Result.Name,                        
                        ExpenseHeadName = Enum.GetName(typeof(CommonBLL.Enums.ExpenseType), salaryPayment.ExpenseHeadId),
                        CapturedByName = salaryPayment.CapturedBy != null ? userManager.FindByIdAsync(salaryPayment.CapturedBy).Result.UserName : null,
                        CapturedDateString = salaryPayment.CapturedDate != null ? Formater.FormatDateddMMyyyy((DateTime)salaryPayment.CapturedDate) : null,
                        UpdatedByName = salaryPayment.UpdatedBy != null ? userManager.FindByIdAsync(salaryPayment.UpdatedBy).Result.UserName : null,
                        UpdatedDateString = salaryPayment.UpdatedDate != null ? Formater.FormatDateddMMyyyy((DateTime)salaryPayment.UpdatedDate) : null,
                        Status = salaryPayment.Status
                    };
                    return salaryPaymentDetailsViewModel;
                }

            }
            catch (Exception e)
            {

            }
            return null;
        }
        public async Task<List<SalaryPaymentDetailsViewModel>> GetTableData()
        {
            try
            {
                IEnumerable<SalaryPayment> salaryPayments = await repository.GetAsync();
                List<SalaryPaymentDetailsViewModel> salaryPaymentDetailsViewModels = new List<SalaryPaymentDetailsViewModel>();
                foreach (SalaryPayment salaryPayment in salaryPayments)
                {
                    SalaryPaymentDetailsViewModel salaryPaymentDetailsViewModel = new SalaryPaymentDetailsViewModel
                    {
                        Id = salaryPayment.Id,
                        SalaryPaymentNo = salaryPayment.SalaryPaymentNo,
                        EmployeeId = salaryPayment.EmployeeId,
                        EmployeeName = emprepository.GetAsync(Convert.ToInt64(salaryPayment.EmployeeId)).Result.Name,
                        ExpenseHeadName = Enum.GetName(typeof(CommonBLL.Enums.ExpenseType), salaryPayment.ExpenseHeadId),
                        SalaryPaymentDateString = salaryPayment.SalaryPaymentDate != null ? Formater.FormatDateddMMyyyy((DateTime)salaryPayment.SalaryPaymentDate) : null,
                        PaidAmount = salaryPayment.PaidAmount,
                        Status = salaryPayment.Status
                    };
                    salaryPaymentDetailsViewModels.Add(salaryPaymentDetailsViewModel);
                }
                if (salaryPaymentDetailsViewModels != null)
                {
                    return salaryPaymentDetailsViewModels;
                }
            }
            catch (Exception e)
            {

            }
            return null;
        }
        public SalaryPaymentViewModel assignDataToSalaryPaymentViewModel(SalaryPayment salaryPayment)
        {
            SalaryPaymentViewModel salaryPaymentViewModel = new SalaryPaymentViewModel
            {
                Id = salaryPayment.Id,
                OrganizationId = salaryPayment.OrganizationId,
                ShopId = salaryPayment.ShopId,
                EmployeeId = salaryPayment.EmployeeId,
                SalaryPaymentNo = salaryPayment.SalaryPaymentNo,
                PaidAmount = salaryPayment.PaidAmount,
                SalaryPaymentDate = salaryPayment.SalaryPaymentDate,
                Note = salaryPayment.Note,
                ExpenseHeadId = salaryPayment.ExpenseHeadId,
                VoucherId = salaryPayment.VoucherId,
                CapturedBy = salaryPayment.CapturedBy,
                CapturedDate = salaryPayment.CapturedDate,
                UpdatedBy = salaryPayment.UpdatedBy,
                UpdatedDate = salaryPayment.UpdatedDate,
                Status = salaryPayment.Status,
            };
            return salaryPaymentViewModel;
        }
    }
}
