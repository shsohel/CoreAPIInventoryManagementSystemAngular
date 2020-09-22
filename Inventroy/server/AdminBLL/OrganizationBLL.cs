using CommonBLL.Enums;
using CommonBLL.Helper;
using CommonDAL.Models;
using CommonDAL.Repository;
using CommonDAL.ViewModels;
using Microsoft.AspNetCore.Hosting;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AdminBLL
{
    public class OrganizationBLL
    {
        private readonly IRepository<Organization> repository;
        public OrganizationBLL(IRepository<Organization> repository)
        {
            this.repository = repository;
        }
        public async Task<IEnumerable<OrganizationViewModel>> GetOrganizations()
        {
            try
            {
                IEnumerable<Organization> organizations = await repository.GetAsync();
                List<OrganizationViewModel> organizationViewModels = new List<OrganizationViewModel>();
                if (organizations != null)
                {
                    foreach (Organization organization in organizations)
                    {
                        organizationViewModels.Add(assignDataToOrganizationViewModel(organization));
                    }
                    return organizationViewModels;
                }
            }
            catch (Exception e)
            {

            }
            return null;
        }
        public async Task<OrganizationViewModel> GetOrganization(int id)
        {
            try
            {
                Organization organization = await repository.GetAsync(id);
                if (organization != null)
                {
                    return assignDataToOrganizationViewModel(organization);
                }
            }
            catch (Exception e)
            {
                e.Message.Contains("Something Wrong");
            }
            return null;
        }
        public async Task<OrganizationViewModel> AddOrganization(OrganizationViewModel model, IHostingEnvironment hostingEnvironment, ApplicationUser token)
        {
            try
            {
                Organization organization = new Organization
                {
                    Name = model.Name,
                    OrganizationNo = DateTime.Now.ToString("ddMMyyhhmmssmmm"),
                    OrganizationTypeId = model.OrganizationTypeId,
                    Email = model.Email,
                    MobileNo = model.MobileNo,
                    FounderName = model.FounderName,
                    TelephoneNo = model.TelephoneNo,
                    RegistrationNo = model.RegistrationNo,
                    RegisteredDate = model.RegisteredDate,
                    WebAddress = model.WebAddress,
                    EstablishedOn = model.EstablishedOn,
                    AddressCountry = model.AddressCountry,
                    AddressDistrict = model.AddressDistrict,
                    AddressPostCode = model.AddressPostCode,
                    AddressPostOffice = model.AddressPostOffice,
                    AddressRoadBlockSector = model.AddressRoadBlockSector,
                    AddressUpazila = model.AddressUpazila,
                    AddressVillageHouse = model.AddressVillageHouse,
                    LogoImage = FileUploader.Upload(model.LogoImage, "OrganizationImages", model.LogoImageName, hostingEnvironment),
                    NameCardImage = FileUploader.Upload(model.NameCardImage, "OrganizationImages", model.NameCardImageName, hostingEnvironment),
                    CapturedBy = token.Id,
                    CapturedDate = DateTime.Now,
                    Status = (byte)CommonBLL.Enums.Status.Active
                };
                Organization result = await repository.AddAsync(organization);
                model.Id = result.Id;
                if (result != null)
                {
                    return assignDataToOrganizationViewModel(result);
                }
            }
            catch (Exception e)
            {

            }
            return null;
        }
        public async Task<OrganizationViewModel> UpdateOrganization(OrganizationViewModel model, IHostingEnvironment hostingEnvironment, ApplicationUser token)
        {
            try
            {
                Organization organization = await repository.GetAsync(model.Id);
                if (organization != null)
                {
                    if (model.LogoImage != null)
                    {
                        FileDeleter.Delete(organization.LogoImage, "OrganizationImages", hostingEnvironment);
                        organization.LogoImage = FileUploader.Upload(model.LogoImage, "OrganizationImages", model.LogoImageName, hostingEnvironment);
                    }
                    if (model.NameCardImage != null)
                    {
                        FileDeleter.Delete(organization.NameCardImage, "OrganizationImages", hostingEnvironment);
                        organization.NameCardImage = FileUploader.Upload(model.NameCardImage, "OrganizationImages", model.NameCardImageName, hostingEnvironment);
                    }
                    organization.Name = model.Name;
                    organization.OrganizationTypeId = model.OrganizationTypeId;
                    organization.Email = model.Email;
                    organization.MobileNo = model.MobileNo;
                    organization.FounderName = model.FounderName;
                    organization.TelephoneNo = model.TelephoneNo;
                    organization.RegistrationNo = model.RegistrationNo;
                    organization.RegisteredDate = model.RegisteredDate;
                    organization.WebAddress = model.WebAddress;
                    organization.EstablishedOn = model.EstablishedOn;
                    organization.AddressCountry = model.AddressCountry;
                    organization.AddressDistrict = model.AddressDistrict;
                    organization.AddressPostCode = model.AddressPostCode;
                    organization.AddressPostOffice = model.AddressPostOffice;
                    organization.AddressRoadBlockSector = model.AddressRoadBlockSector;
                    organization.AddressUpazila = model.AddressUpazila;
                    organization.AddressVillageHouse = model.AddressVillageHouse;
                    organization.UpdatedBy = token.Id;
                    organization.UpdatedDate = DateTime.Now;
                    Organization result = await repository.UpdateAsync(organization);
                    if (result != null)
                    {
                        return assignDataToOrganizationViewModel(result);
                    }
                }
            }
            catch (Exception e)
            {

            }
            return null;
        }
        public async Task<OrganizationViewModel> DeleteOrganization(int id)
        {
            try
            {
                Organization organization = await repository.GetAsync(id);
                if (organization != null)
                {
                    Organization result = await repository.DeleteAsync(organization);
                    if (result != null)
                    {
                        return assignDataToOrganizationViewModel(result);
                    }
                }
            }
            catch (Exception e)
            {

            }
            return null;
        }
        public async Task<OrganizationViewModel> GetDetails(int id)
        {
            try
            {
                Organization organization = await repository.GetAsync(id);
                if (organization != null)
                {
                    OrganizationDetailsViewModel organizationDetailsViewModel = new OrganizationDetailsViewModel
                    {
                        Id = organization.Id,
                        Name = organization.Name,
                        MobileNo=organization.MobileNo,
                        AddressCountry=organization.AddressCountry,
                        OrganizationNo=organization.OrganizationNo,
                        RegistrationNo=organization.RegistrationNo,
                        AddressPostOffice=organization.AddressPostOffice,
                        AddressDistrict=organization.AddressDistrict,
                        OrganizationTypeId=organization.OrganizationTypeId,
                        OrganizationTypeName = Enum.GetName(typeof(CommonBLL.Enums.OrganizationTypeEnum), organization.OrganizationTypeId),
                        TelephoneNo=organization.TelephoneNo,
                        AddressPostCode=organization.AddressPostCode,
                        AddressRoadBlockSector=organization.AddressRoadBlockSector,
                        AddressUpazila=organization.AddressUpazila,
                        AddressVillageHouse=organization.AddressVillageHouse,
                        WebAddress=organization.WebAddress,
                        NameCardImage=organization.NameCardImage,
                        LogoImage=organization.LogoImage,
                        FounderName=organization.FounderName,
                        Email=organization.Email,        
                        RegisteredDateString = organization.RegisteredDate != null ? Formater.FormatDateddMMyyyy((DateTime)organization.RegisteredDate) : null,
                        EstablishedOnDateString = organization.EstablishedOn != null ? Formater.FormatDateddMMyyyy((DateTime)organization.EstablishedOn) : null,
                      //  CapturedBy = organization.CapturedBy,
                        CreatedDateString = organization.CapturedDate != null ? Formater.FormatDateddMMyyyy((DateTime)organization.CapturedDate) : null,
                      ///  UpdatedBy = organization.UpdatedBy,
                        ModifiedDateString = organization.UpdatedDate != null ? Formater.FormatDateddMMyyyy((DateTime)organization.UpdatedDate) : null,
                        Status = organization.Status
                    };
                    return organizationDetailsViewModel;
                }
            }
            catch (Exception e)
            {

            }
            return null;
        }
        public async Task<List<OrganizationViewModel>> GetTableData()
        {
            try
            {
                IEnumerable<Organization> organizations = await repository.GetAsync();
                List<OrganizationViewModel> organizationViewModels = new List<OrganizationViewModel>();
                foreach (Organization organization in organizations)
                {
                    OrganizationViewModel organizationViewModel = new OrganizationViewModel
                    {
                        Id = organization.Id,
                        OrganizationNo = organization.OrganizationNo,
                        Name = organization.Name,
                        MobileNo = organization.MobileNo,
                        Email = organization.Email,
                        WebAddress = organization.WebAddress,
                        Status = organization.Status
                    };
                    organizationViewModels.Add(organizationViewModel);
                }
                if (organizationViewModels != null)
                {
                    return organizationViewModels;
                }
            }
            catch (Exception e)
            {

            }
            return null;
        }
        public OrganizationViewModel assignDataToOrganizationViewModel(Organization org)
        {
            OrganizationDetailsViewModel organizationViewModel = new OrganizationDetailsViewModel
            {
                Id = org.Id,
                Name = org.Name,
                OrganizationNo = org.OrganizationNo,
                OrganizationTypeId=org.OrganizationTypeId,
                OrganizationTypeName= Enum.GetName(typeof(CommonBLL.Enums.OrganizationTypeEnum), org.OrganizationTypeId),
                Email = org.Email,
                MobileNo = org.MobileNo,
                FounderName = org.FounderName,
                TelephoneNo = org.TelephoneNo,
                RegistrationNo = org.RegistrationNo,
                RegisteredDate = Convert.ToDateTime(org.RegisteredDate),
                WebAddress = org.WebAddress,
                EstablishedOn = Convert.ToDateTime(org.EstablishedOn),
                AddressCountry = org.AddressCountry,
                AddressDistrict = org.AddressDistrict,
                AddressPostCode = org.AddressPostCode,
                AddressPostOffice = org.AddressPostOffice,
                AddressRoadBlockSector = org.AddressRoadBlockSector,
                AddressUpazila = org.AddressUpazila,
                AddressVillageHouse = org.AddressVillageHouse,
                LogoImage = org.LogoImage,
                NameCardImage = org.NameCardImage,
              //  CapturedBy = org.CapturedBy,
                CapturedDate = Convert.ToDateTime(org.CapturedDate),
              ///  UpdatedBy = org.UpdatedBy,
                UpdatedDate = Convert.ToDateTime(org.UpdatedDate),
                Status = org.Status
            };
            return organizationViewModel;
        }
    }
}
