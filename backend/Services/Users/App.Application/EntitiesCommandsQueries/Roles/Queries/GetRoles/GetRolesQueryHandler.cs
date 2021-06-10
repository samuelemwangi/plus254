using App.Application.EntitiesCommandsQueries.Roles.Queries.ViewModels;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;


/// <summary>
/// Handle Get Roles
/// </summary>

namespace App.Application.EntitiesCommandsQueries.Roles.Queries.GetRoles
{

    public class GetRolesQuery : IRequest<RolesViewModel>
    {


    }
    internal sealed class GetRolesQueryHandler : IRequestHandler<GetRolesQuery, RolesViewModel>
    {
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IConfigurationSection _configurationSection;

        public GetRolesQueryHandler(RoleManager<IdentityRole> roleManager, IConfiguration configuration)
        {
            _roleManager = roleManager;
            _configurationSection = configuration.GetSection("MessageTemplates");

        }
        public async Task<RolesViewModel> Handle(GetRolesQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var roles = await _roleManager.Roles
                    .Select(RoleDTO.Projection)
                    .ToListAsync(cancellationToken);

                return new RolesViewModel
                {
                    Roles = roles,
                    StatusMessage = _configurationSection["Success"],
                    RequestStatus = 1

                };

            }
            catch (Exception e)
            {
                return new RolesViewModel
                {
                    StatusMessage = e.Message,
                    RequestStatus = 0

                };
            }
        }
    }
}
