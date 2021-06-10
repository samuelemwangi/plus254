using App.Application.EntitiesCommandsQueries.Users.Queries.ViewModels;
using App.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace App.Application.EntitiesCommandsQueries.Users.Queries.GetUsers
{
    public class GetUsersQuery : IRequest<UsersViewModel>
    {

    }

    public class GetUsersQueryHandler : IRequestHandler<GetUsersQuery, UsersViewModel>
    {
        private readonly AppDbContext _appDbContext;
        private readonly IConfigurationSection _configurationSection;
        public GetUsersQueryHandler(AppDbContext appDbContext, IConfiguration configuration)
        {
            _appDbContext = appDbContext;
            _configurationSection = configuration.GetSection("MessageTemplates");

        }
        public async Task<UsersViewModel> Handle(GetUsersQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var users = await _appDbContext.AppUser
                    .Select(UserDTO.Projection)
                    .ToListAsync(cancellationToken);


                return new UsersViewModel
                {
                    Users = users,
                    RequestStatus = 1,
                    StatusMessage = _configurationSection["Success"],

                };

            }
            catch (Exception e)
            {
                return new UsersViewModel
                {
                    RequestStatus = 0,
                    StatusMessage = e.Message

                };
            }

        }
    }
}
