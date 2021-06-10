using App.Application.EntitiesCommandsQueries.Token.Queries.ViewModels;

/// <summary>
/// Return this on authentication
/// </summary>

namespace App.Application.EntitiesCommandsQueries.Users.Queries.ViewModels
{
    public class AuthUserViewModel : ItemDetailBaseViewModel
    {
        public UserDTO UserDetails { get; set; }
        public AccessTokenViewModel UserToken { get; set; }

    }
}