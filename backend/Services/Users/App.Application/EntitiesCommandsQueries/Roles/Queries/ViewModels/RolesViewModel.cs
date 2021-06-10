using System.Collections.Generic;

/// <summary>
/// Roles View Model
/// </summary>


namespace App.Application.EntitiesCommandsQueries.Roles.Queries.ViewModels
{
    public class RolesViewModel : BaseViewModel
    {
        public IEnumerable<RoleDTO> Roles { get; set; }
        public bool CreateEnabled { get; set; }
    }
}
