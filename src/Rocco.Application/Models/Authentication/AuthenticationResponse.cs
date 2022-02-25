namespace Rocco.Application.Models.Authentication;

public class AuthenticationResponse
{
    public string Id { get; set; } = null!;

    public string UserName { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string Token { get; set; } = null!;
}
