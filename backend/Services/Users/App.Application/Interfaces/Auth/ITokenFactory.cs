/// <summary>
/// Token Factory
/// </summary>

namespace App.Application.Interfaces.Auth
{
    public interface ITokenFactory
    {
        string GenerateToken(int size = 32);
    }
}
