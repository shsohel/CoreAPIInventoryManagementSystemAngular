using CommonDAL.Models;
using CommonDAL.Repository;
using CommonDAL.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonBLL
{
    public class CommonDataListBLL
    {
        private readonly IRepository<Country> countryRepository;
        private readonly IRepository<Division> divisionRepository;
        private readonly IRepository<District> districtRepository;
        private readonly IRepository<DistrictUpazila> districtUpozilaRepository;
        private readonly IRepository<DistrictPostOffice> districtPostOfficeRepository;
        private readonly IRepository<Nationality> nationalityRepository;
        private readonly IRepository<RelationShip> relationShipRepository;
        private readonly IRepository<Profession> professionRepository;
        private readonly IRepository<Shop> shopRepository;
        private readonly IRepository<Employee> employeeRepository;
        private readonly IRepository<ShiftSection> shifSectionRepository;
        private readonly IRepository<Organization> organizationRepository;
        private readonly IRepository<Designation> designationRepository;
        private readonly IRepository<Category> categoryRepository;
        private readonly IRepository<Product> productRepository;
        private readonly IRepository<VAT> vatRepository;
        private readonly IRepository<Unit> unitRepository;
        private readonly IRepository<Manufacturer> manufacturerRepository;
        private readonly IRepository<SpecificationAttribute> specAttriRepository;
        private readonly IRepository<SpecificationAttrValue> specAttriValueRepository;

        public CommonDataListBLL(IRepository<Country> countryRepository, IRepository<District> districtRepository,
            IRepository<DistrictUpazila> districtUpozilaRepository, IRepository<DistrictPostOffice> districtPostOfficeRepository,
            IRepository<Nationality> nationalityRepository, IRepository<RelationShip> relationShipRepository,
            IRepository<Profession> professionRepository, IRepository<Shop> shopRepository, IRepository<Employee> employeeRepository,
            IRepository<ShiftSection> shifSectionRepository, IRepository<Division> divisionRepository, IRepository<Organization> organizationRepository,
            IRepository<Designation> designationRepository, IRepository<Category> categoryRepository, IRepository<Product> productRepository,
            IRepository<VAT> vatRepository, IRepository<Unit> unitRepository, IRepository<Manufacturer> manufacturerRepository, 
            IRepository<SpecificationAttribute> specAttriRepository, IRepository<SpecificationAttrValue> specAttriValueRepository
            )
        {
            this.countryRepository = countryRepository;
            this.divisionRepository = divisionRepository;
            this.districtRepository = districtRepository;
            this.districtUpozilaRepository = districtUpozilaRepository;
            this.districtPostOfficeRepository = districtPostOfficeRepository;
            this.nationalityRepository = nationalityRepository;
            this.relationShipRepository = relationShipRepository;
            this.professionRepository = professionRepository;
            this.shopRepository = shopRepository;
            this.employeeRepository = employeeRepository;
            this.shifSectionRepository = shifSectionRepository;
            this.organizationRepository = organizationRepository;
            this.designationRepository = designationRepository;
            this.categoryRepository = categoryRepository;
            this.productRepository = productRepository;
            this.vatRepository = vatRepository;
            this.unitRepository = unitRepository;
            this.manufacturerRepository = manufacturerRepository;
            this.specAttriRepository = specAttriRepository;
            this.specAttriValueRepository = specAttriValueRepository;
        }
        public async Task<CommonDataListViewModel> GetCommondDataLists()
        {
            try
            {
                IEnumerable<Country> countries = await countryRepository.GetAsync();
                IEnumerable<Division> divisions = await divisionRepository.GetAsync();
                IEnumerable<District> districts = await districtRepository.GetAsync();
                IEnumerable<DistrictUpazila> districtUpazilas = await districtUpozilaRepository.GetAsync();
                IEnumerable<DistrictPostOffice> districtPostOffices = await districtPostOfficeRepository.GetAsync();
                IEnumerable<Nationality> nationalities = await nationalityRepository.GetAsync();
                IEnumerable<RelationShip> relationShips = await relationShipRepository.GetAsync();
                IEnumerable<Profession> professions = await professionRepository.GetAsync();
                IEnumerable<Shop> shops = await shopRepository.GetAsync();
                IEnumerable<Employee> employees = await employeeRepository.GetAsync();
                IEnumerable<ShiftSection> shiftSections = await shifSectionRepository.GetAsync();
                IEnumerable<Organization> organizations = await organizationRepository.GetAsync();
                IEnumerable<Designation> designations = await designationRepository.GetAsync();
                IEnumerable<Category> categories = await categoryRepository.GetAsync();
                IEnumerable<Product> products = await productRepository.GetAsync();
                IEnumerable<VAT> vATs = await vatRepository.GetAsync();
                IEnumerable<Unit> units = await unitRepository.GetAsync();
                IEnumerable<Manufacturer> manufacturers = await manufacturerRepository.GetAsync();
                IEnumerable<SpecificationAttribute> specificationAttributes = await specAttriRepository.GetAsync();
                IEnumerable<SpecificationAttrValue> specificationAttrValues = await specAttriValueRepository.GetAsync();
                CommonDataListViewModel commonDataListViewModels = new CommonDataListViewModel
                {
                    lstCountries = countries,
                    lstDistricts = districts,
                    lstDivisions = divisions,
                    lstEmployees = employees,
                    lstNationalities = nationalities,
                    lstOrganizations = organizations,
                    lstPostOffices = districtPostOffices,
                    lstProfessions = professions,
                    lstRelationShips = relationShips,
                    lstShiftSections = shiftSections,
                    lstShops = shops,
                    lstUpazilas = districtUpazilas,
                    lstDesignations=designations,
                    lstCategories=categories,
                    lstProducts=products,
                    lstVats=vATs,
                    lstUnits=units, 
                    lstManufacturers=manufacturers,
                    lstSpecificationAttributes= specificationAttributes,
                    lstSpecificationAttrValues= specificationAttrValues,
                };
                return commonDataListViewModels;
            }
            catch (Exception e)
            {

            }
            return null;
        }
    }
}
