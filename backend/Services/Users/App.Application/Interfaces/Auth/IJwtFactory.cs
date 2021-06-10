using App.Application.EntitiesCommandsQueries.Token.Queries.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;


/// <summary>
/// Define how you create a token
/// </summary>

namespace App.Application.Interfaces.Auth
{
    public interface IJwtFactory
    {
        Task<AccessTokenDTO> GenerateEncodedToken(string id, string userName, IList<string> userRoles);

    }
}
