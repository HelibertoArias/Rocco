namespace Rocco.Application.Models.Authentication;

public class AuthenticationRequest
{
    public string Email { get; set; } = null!;

    public string Password { get; set; } = null!;
}
