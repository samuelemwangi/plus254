using App.Application.EntitiesCommandsQueries.Roles.Queries.ViewModels;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;


/// <summary>
/// Define Query and its handler 
/// </summary>

namespace App.Application.EntitiesCommandsQueries.Roles.Queries.GetRole
{
    public class GetRoleQuery : IRequest<RoleViewModel>
    {
        public string RoleName { get; set; }
    }
    internal sealed class GetRoleQueryHandler : IRequestHandler<GetRoleQuery, RoleViewModel>
    {
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IConfigurationSection _configurationSection;

        public GetRoleQueryHandler(RoleManager<IdentityRole> roleManager, IConfiguration configuration)
        {
            _roleManager = roleManager;
            _configurationSection = configuration.GetSection("MessageTemplates");

        }
        public async Task<RoleViewModel> Handle(GetRoleQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var role = await _roleManager.FindByNameAsync(request.RoleName);

                if (role == null) throw new Exception("No role found");

                return new RoleViewModel
                {
                    Role = new RoleDTO
                    {
                        RoleId = role.Id,
                        RoleName = role.Name

                    },
                    StatusMessage = _configurationSection["Success"],
                    RequestStatus = 1
                };

            }
            catch (Exception e)
            {
                return new RoleViewModel
                {
                    StatusMessage = e.Message,
                    RequestStatus = 0


                };

            }



        }
    }
}
