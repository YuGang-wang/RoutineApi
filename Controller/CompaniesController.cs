using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Routine.Api.Model;
using Routine.Api.Services;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Routine.Api.Controller
{
    [Route("api/companies")]
    [ApiController]
    public class CompaniesController : ControllerBase
    {
        private readonly ICompanyRepository _companyRepository;

        private readonly IMapper _mapper;       //引入 AutoMapper

        public CompaniesController(ICompanyRepository companyRepository, IMapper mapper)
        {
            _companyRepository = companyRepository ?? throw new ArgumentNullException(nameof(companyRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        /// <summary>
        /// 使用 ActionResult<IEnumerable<CompanyDto>> 作为返回类型在swagger中可以看到具体的类型
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CompanyDto>>> GetCompanies()
        {
            var companies = await _companyRepository.GetCompaniesAsync();

            // 令实体类型Company 映射为CompanyDto类型
            var companyDtos = _mapper.Map<IEnumerable<CompanyDto>>(companies);

            return new JsonResult(companyDtos);
        }


        [HttpGet("{companyId}")]
        public async Task<ActionResult<IEnumerable<CompanyDto>>> GetCompany(Guid companyId)
        {
            var company = await _companyRepository.GetCompanyAsync(companyId);
            if (company == null)
            {
                return NotFound();
            }

            var companyDto = _mapper.Map<CompanyDto>(company);
            return Ok(companyDto);
        }
    }
}
