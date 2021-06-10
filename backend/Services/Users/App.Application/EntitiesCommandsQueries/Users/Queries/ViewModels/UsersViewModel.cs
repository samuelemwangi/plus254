using System.Collections.Generic;

/// <summary>
/// Get all users
/// </summary>

namespace App.Application.EntitiesCommandsQueries.Users.Queries.ViewModels
{
    public class UsersViewModel: ItemsBaseViewModel
    {
        public ICollection<UserDTO> Users { get; set; }
    }
}
