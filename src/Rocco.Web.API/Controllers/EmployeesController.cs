using Microsoft.AspNetCore.Mvc;
using Rocco.Application.Models;
using Rocco.Application.Services.Contracts;

namespace Rocco.Web.API.Controllers
{
    // [Authorize]
    [Route("api/companies/{companyId}/employees")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly ICompanyService _serviceCompany;

        public EmployeesController(ICompanyService serviceCompany)
        {
            if (serviceCompany is null)
            {
                throw new ArgumentNullException(nameof(serviceCompany));
            }

            _serviceCompany = serviceCompany;
        }

        // GET: api/companies/5/employees
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<EmployeeDto>))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetEmployeeByCompany(Guid companyId)
        {
            var result = await _serviceCompany.GetEmployeesByCompanyId(companyId);
            return Ok(result);
        }

        // GET: api/companies/5/employees
        [HttpGet("{empleadoId}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(EmployeeDto))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetEmployeesByCompany(Guid companyId, Guid empleadoId)
        {
            var result = await _serviceCompany.GetEmployeeByCompanyId(companyId, empleadoId);
            return Ok(result);
        }
    }
}
