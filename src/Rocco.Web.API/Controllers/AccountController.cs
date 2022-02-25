using Microsoft.AspNetCore.Mvc;
using Rocco.Application.Contracts.Identity;
using Rocco.Application.Models.Authentication;

namespace Rocco.Web.API.Controllers;
[Route("api/[controller]")]
[ApiController]
public class AccountController : ControllerBase
{
    private readonly IAuthenticationService _authenticationService;
    public AccountController(IAuthenticationService authenticationService)
    {
        _authenticationService = authenticationService;
    }

    [HttpPost("authenticate", Name = "authenticate")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<ActionResult<AuthenticationResponse>> Authenticate(AuthenticationRequest request)
    {
        return Ok(await _authenticationService.AuthenticateAsync(request));
    }

    [HttpPost("register", Name = "register")]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status422UnprocessableEntity)]
    public async Task<ActionResult<RegistrationResponse>> Register(RegistrationRequest request)
    {

        var result = await _authenticationService.RegisterAsync(request);
        return Ok(result);

    }


}
