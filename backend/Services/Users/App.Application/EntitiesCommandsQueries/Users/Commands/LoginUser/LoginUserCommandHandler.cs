using App.Application.EntitiesCommandsQueries.Token.Queries.ViewModels;
using App.Application.EntitiesCommandsQueries.Users.Queries.ViewModels;
using App.Application.Interfaces.Auth;
using App.Application.Interfaces.Utilities;
using App.Domain.Entities.Identity;
using App.Persistence;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

/// <summary>
/// Handle Login
/// </summary>

namespace App.Application.EntitiesCommandsQueries.Users.Commands.LoginUser
{
    public class LoginUserCommand : IRequest<AuthUserViewModel>
    {
        public string UserEmail { get; set; }
        public string Password { get; set; }

        public string RemoteIPAddress { get; set; }
    }
    public class LoginUserCommandHandler : IRequestHandler<LoginUserCommand, AuthUserViewModel>
    {
        private readonly IJwtFactory _jwtFactory;
        private readonly ITokenFactory _tokenFactory;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly AppDbContext _appDbContext;
        private readonly IMachineDateTime _dateTime;


        public LoginUserCommandHandler(IJwtFactory jwtFactory, ITokenFactory tokenFactory, UserManager<IdentityUser> userManager, AppDbContext appDbContext, IMachineDateTime dateTime)
        {
            _jwtFactory = jwtFactory;
            _tokenFactory = tokenFactory;
            _userManager = userManager;
            _appDbContext = appDbContext;
            _dateTime = dateTime;

        }
        public async Task<AuthUserViewModel> Handle(LoginUserCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var user = await _userManager.FindByNameAsync(request.UserEmail);


                var appUserDetails = await _appDbContext.AppUser
                    .Where(e => e.UserEmail == request.UserEmail)
                    .Select(UserDTO.Projection)
                    .FirstOrDefaultAsync(cancellationToken);


                if (user != null && appUserDetails != null)
                {

                    bool userExists = await _userManager.CheckPasswordAsync(user, request.Password);


                    if (userExists)
                    {
                        //get user roles
                        var userRoles = await _userManager.GetRolesAsync(user);

                        var refreshToken = _tokenFactory.GenerateToken();
                        var userToken = await _jwtFactory.GenerateEncodedToken(user.Id, user.UserName, userRoles);

                        var newRefreshToken = new RefreshToken
                        {
                            CreatedDate = _dateTime.Now,
                            Expires = _dateTime.Now.AddSeconds((double)userToken.ExpiresIn),
                            UserId = user.Id,
                            Token = refreshToken,
                            RemoteIpAddress = request.RemoteIPAddress

                        };

                        _appDbContext.RefreshToken.Add(newRefreshToken);

                        await _appDbContext.SaveChangesAsync(cancellationToken);

                        //check if email is confirmed
                        //appUserDetails.EmailConfirmed = user.EmailConfirmed;

                        return new AuthUserViewModel
                        {
                            UserDetails = appUserDetails,
                            UserToken = new AccessTokenViewModel
                            {
                                AccessToken = userToken,
                                RefreshToken = refreshToken

                            },
                            StatusMessage = "Success",
                            RequestStatus = 1
                        };

                    }
                    else
                    {

                        throw new Exception("Invalid Username or password");
                    }

                }
                else
                {
                    throw new Exception("Invalid Username or password");
                }

            }
            catch (Exception e)
            {

                return new AuthUserViewModel
                {
                    RequestStatus = 0,
                    StatusMessage = e.Message
                };
            }
        }


    }
}
