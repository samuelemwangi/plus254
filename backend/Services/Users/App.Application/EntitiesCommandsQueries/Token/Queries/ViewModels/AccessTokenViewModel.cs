/// <summary>
/// Return this for access token
/// </summary>

namespace App.Application.EntitiesCommandsQueries.Token.Queries.ViewModels
{
    public class AccessTokenViewModel
    {
        public AccessTokenDTO AccessToken { get; set; }
        public string RefreshToken { get; set; }
    }
}
