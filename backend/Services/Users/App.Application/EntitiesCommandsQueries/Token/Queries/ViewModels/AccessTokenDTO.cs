/// <summary>
/// Access Token DTO
/// </summary>

namespace App.Application.EntitiesCommandsQueries.Token.Queries.ViewModels
{
    public class AccessTokenDTO
    {
        public string Token { get; }
        public int ExpiresIn { get; }

        public AccessTokenDTO(string token, int expiresIn)
        {
            Token = token;
            ExpiresIn = expiresIn;
        }
    }
}
