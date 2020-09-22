using CommonDAL.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace CommonDAL.ViewModels
{
    public class CommonDataListViewModel
    {
        public IEnumerable<Country> lstCountries { get; set; }
        public IEnumerable<Division> lstDivisions { get; set; }
        public IEnumerable<District> lstDistricts { get; set; }
        public IEnumerable<DistrictUpazila> lstUpazilas { get; set; }
        public IEnumerable<DistrictPostOffice> lstPostOffices { get; set; }
        public IEnumerable<RelationShip> lstRelationShips { get; set; }
        public IEnumerable<Nationality> lstNationalities { get; set; }
        public IEnumerable<Profession> lstProfessions { get; set; }
        public IEnumerable<Shop> lstShops { get; set; }
        public IEnumerable<Organization> lstOrganizations { get; set; }
        public IEnumerable<ShiftSection> lstShiftSections { get; set; }
        public IEnumerable<Employee> lstEmployees { get; set; }
        public IEnumerable<Designation> lstDesignations { get; set; }
        public IEnumerable<Category> lstCategories { get; set; }
        public IEnumerable<Product> lstProducts { get; set; }
        public IEnumerable<VAT> lstVats { get; set; }
        public IEnumerable<Unit> lstUnits { get; set; }
        public IEnumerable<Manufacturer> lstManufacturers { get; set; }
        public IEnumerable<SpecificationAttribute> lstSpecificationAttributes { get; set; }
        public IEnumerable<SpecificationAttrValue> lstSpecificationAttrValues { get; set; }



    }
}
