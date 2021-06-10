using System.Security.Claims;

/// <summary>
/// JWT Token validator
/// </summary>

namespace App.Application.Interfaces.Auth
{
    public interface IJwtTokenValidator
    {
        ClaimsPrincipal GetPrincipalFromToken(string token, string signingKey);
    }
}
