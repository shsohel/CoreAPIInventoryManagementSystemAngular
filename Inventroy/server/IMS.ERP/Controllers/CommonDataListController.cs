using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CommonBLL;
using CommonDAL.Models;
using CommonDAL.Repository;
using CommonDAL.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace IMSERP.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommonDataListController : ControllerBase
    {
        private string message = "Sorry! Something going wrong. Please try again.";
        //  private readonly IRepository<Organization> repository;
        private CommonDataListBLL commonDataListBLL;
        public CommonDataListController(IRepository<Country> countryRepository, IRepository<District> districtRepository,
            IRepository<DistrictUpazila> districtUpozilaRepository, IRepository<DistrictPostOffice> districtPostOfficeRepository,
            IRepository<Nationality> nationalityRepository, IRepository<RelationShip> relationShipRepository,
            IRepository<Profession> professionRepository, IRepository<Shop> shopRepository, IRepository<Employee> employeeRepository,
            IRepository<ShiftSection> shifSectionRepository, IRepository<Division> divisionRepository, IRepository<Organization> organizationRepository,
            IRepository<Designation> designationRepository, IRepository<Category> categoryRepository, IRepository<Product> productRepository,
            IRepository<VAT> vatRepository, IRepository<Unit> unitRepository, IRepository<Manufacturer> manufacturerRepository,
            IRepository<SpecificationAttribute> specAttriRepository, IRepository<SpecificationAttrValue> specAttriValueRepository
            )
        {
            commonDataListBLL = new CommonDataListBLL(countryRepository, districtRepository, districtUpozilaRepository, districtPostOfficeRepository,
                nationalityRepository, relationShipRepository, professionRepository, shopRepository, employeeRepository, shifSectionRepository,
                divisionRepository, organizationRepository, designationRepository, categoryRepository, productRepository,vatRepository,unitRepository,
                manufacturerRepository, specAttriRepository, specAttriValueRepository);
        }
        [HttpGet]
        [Route("commonDataList")]
        public async Task<ActionResult> GetcommonDataList()
        {
            try
            {
                CommonDataListViewModel organizationViewModels = await commonDataListBLL.GetCommondDataLists();
                if (organizationViewModels != null)
                {
                    return Ok(new { status = 200, obj = organizationViewModels, message = "Common Data List has retrive successfully." });
                }
            }
            catch (Exception e)
            {

            }
            return BadRequest(new { status = 404, message = message });
        }
    }
}