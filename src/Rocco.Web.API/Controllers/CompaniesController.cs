// <copyright file="CompaniesController.cs" company="Rocco Company">
// Copyright (c) 2022, Heliberto Arias
// </copyright>

using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Rocco.Application.Models;
using Rocco.Application.Services.Contracts;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Rocco.Web.API.Controllers;

// [Authorize]
[Route("api/[controller]")]
[ApiController]

public class CompaniesController : ControllerBase
{
    private readonly ICompanyService _serviceCompany;

    public CompaniesController(ICompanyService serviceCompany)
    {
        if (serviceCompany is null)
        {
            throw new ArgumentNullException(nameof(serviceCompany));
        }

        _serviceCompany = serviceCompany;
    }

    // Code commented to avoid errors like "The request matched multiple endpoints"
    // GET: api/<CompaniesController>
    //[HttpGet]
    //[ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<CompanyDto>))]
    //public ActionResult<IEnumerable<CompanyDto>> Get()
    //{
    //    return Ok(_serviceCompany.FindAll());
    //}

    // GET: api/<CompaniesController>
    [HttpGet]

    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<CompanyDto>))]
    public async Task<ActionResult<IEnumerable<CompanyDto>>> Get([FromQuery] CompanyListQueryDto companyListQueryDto)
    {
        if (companyListQueryDto != null && companyListQueryDto.PageSize > 0)
        {
            return Ok(await _serviceCompany.FindPagedAll(companyListQueryDto));
        }
        return Ok(_serviceCompany.FindAll());

    }

    // GET api/<CompaniesController>/5
    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(CompanyDto))]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Get(Guid id)
    {
        var dto = await _serviceCompany
            .FindOneByCondition(id)
            .ConfigureAwait(false);

        return Ok(dto);
    }

    // POST api/<CompaniesController>
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public async Task<IActionResult> Post([FromBody] CompanyDtoForInsert dto)
    {
        await _serviceCompany.AddCompanyAsync(dto)
                             .ConfigureAwait(false);

        return NoContent();
    }

    // PUT api/<CompaniesController>/5
    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public async Task<IActionResult> Put([FromBody] CompanyDtoForUpdate dto, Guid id)
    {
        await _serviceCompany.UpdateCompany(dto, id)
                             .ConfigureAwait(false);

        return NoContent();
    }

    // PATCH api/<CompaniesController>/5
    [HttpPatch("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public async Task<IActionResult> Patch([FromBody] JsonPatchDocument<CompanyDtoForUpdate> patchDocument, Guid id)
    {
        await _serviceCompany.PartialUpdateCompany(patchDocument, id).ConfigureAwait(false);
        return NoContent();
    }

    // DELETE api/<CompaniesController>/5
    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public async Task<IActionResult> Delete(Guid id)
    {
        await _serviceCompany.DeleteCompany(id);
        return NoContent();
    }



}
