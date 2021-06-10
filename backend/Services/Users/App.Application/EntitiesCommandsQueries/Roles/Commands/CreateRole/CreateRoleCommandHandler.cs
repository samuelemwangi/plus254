using App.Application.EntitiesCommandsQueries.Roles.Queries.GetRole;
using App.Application.EntitiesCommandsQueries.Roles.Queries.ViewModels;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

/// <summary>
/// Create Role Command and Command Handler
/// </summary>

namespace App.Application.EntitiesCommandsQueries.Roles.Commands.CreateRole
{
    public class CreateRoleCommand : IRequest<RoleViewModel>
    {
        public string RoleName { get; set; }
    }
    public class CreateRoleCommandHandler : IRequestHandler<CreateRoleCommand, RoleViewModel>
    {
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IMediator _mediator;
        public CreateRoleCommandHandler(RoleManager<IdentityRole> roleManager, IMediator mediator)
        {
            _roleManager = roleManager;
            _mediator = mediator;
        }
        public async Task<RoleViewModel> Handle(CreateRoleCommand request, CancellationToken cancellationToken)
        {
            try
            {
                bool roleExists = await _roleManager.RoleExistsAsync(request.RoleName);

                if (roleExists) throw new Exception("Role already exists");

                var createdRole = await _roleManager.CreateAsync(new IdentityRole(request.RoleName));

                if (!createdRole.Succeeded) throw new Exception(String.Join(" ", createdRole.Errors.Select(e => e.Description)));

                return await _mediator.Send(new GetRoleQuery { RoleName = request.RoleName });

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
