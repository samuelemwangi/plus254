using Microsoft.AspNetCore.Identity;
using System;
using System.Linq.Expressions;


/// <summary>
/// Define DTO
/// </summary>

namespace App.Application.EntitiesCommandsQueries.Roles.Queries.ViewModels
{
    public class RoleDTO
    {
        public string RoleId { get; set; }

        public string RoleName { get; set; }

        public static Expression<Func<IdentityRole, RoleDTO>> Projection
        {
            get
            {
                return role => new RoleDTO
                {
                    RoleId = role.Id,
                    RoleName = role.Name
                };
            }
        }

    }
}
