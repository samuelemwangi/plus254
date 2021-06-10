using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// <summary>
/// User details
/// </summary>

namespace App.Application.EntitiesCommandsQueries.Users.Queries.ViewModels
{
    public class UserDetailDTO: UserDTO
    {
        public bool EmailConfirmed { get; set; }
        
    }
}
