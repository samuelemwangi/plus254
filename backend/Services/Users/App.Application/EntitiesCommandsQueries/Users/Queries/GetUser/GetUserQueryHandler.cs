using App.Application.EntitiesCommandsQueries.Users.Queries.ViewModels;
using App.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace App.Application.EntitiesCommandsQueries.Users.Queries.GetUser
{
    public class GetUserQuery : IRequest<UserViewModel>
    {
        public string UserId { get; set; }

    }
    public class GetUserQueryHandler : IRequestHandler<GetUserQuery, UserViewModel>
    {
        private readonly AppDbContext _appDbContext;
        private readonly IConfigurationSection _configurationSection;

        public GetUserQueryHandler(AppDbContext appDbContext, IConfiguration configuration)
        {
            _appDbContext = appDbContext;
            _configurationSection = configuration.GetSection("MessageTemplates");
        }
        public async Task<UserViewModel> Handle(GetUserQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var user = await (from u in _appDbContext.AppUser
                                  where u.Id == request.UserId
                                  select new UserDetailDTO
                                  {
                                      Id = u.Id,
                                      FirstName = u.FirstName,
                                      LastName = u.LastName,
                                      UserEmail = u.UserEmail,
                                      EmailConfirmed = false

                                  }).FirstOrDefaultAsync(cancellationToken);
                if (user == null) throw new Exception(_configurationSection["ItemDetailsNotFound"]);

                return new UserViewModel
                {
                    UserDetails = user,
                    StatusMessage = _configurationSection["Success"],
                    RequestStatus = 1
                };

            }
            catch (Exception e)
            {
                return new UserViewModel
                {
                    StatusMessage = e.Message,
                    RequestStatus = 0

                };
            }
        }
    }
}
