// <copyright file="CompaniesController.cs" company="Rocco Company">
// Copyright (c) 2022, Heliberto Arias
// </copyright>

using Microsoft.AspNetCore.Mvc;
using Rocco.Application.Models;
using Rocco.Application.Services.Contracts;

namespace Rocco.Web.API.Controllers;

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

    // GET: api/Companies
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<CompanyDto>))]
    public ActionResult<IEnumerable<CompanyDto>> Get()
    {
        return Ok(_serviceCompany.FindAll());
    }
}
