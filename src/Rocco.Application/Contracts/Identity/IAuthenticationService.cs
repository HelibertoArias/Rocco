using Rocco.Application.Models.Authentication;
using System.Threading.Tasks;

namespace Rocco.Application.Contracts.Identity;

public interface IAuthenticationService
{
    Task<AuthenticationResponse> AuthenticateAsync(AuthenticationRequest request);
    Task<RegistrationResponse> RegisterAsync(RegistrationRequest request);
}