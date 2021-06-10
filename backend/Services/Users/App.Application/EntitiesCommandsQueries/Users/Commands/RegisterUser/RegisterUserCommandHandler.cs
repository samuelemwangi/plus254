using App.Application.EntitiesCommandsQueries.Token.Queries.ViewModels;
using App.Application.EntitiesCommandsQueries.Users.Queries.ViewModels;
using App.Application.Interfaces.Auth;
using App.Application.Interfaces.Notifications;
using App.Application.Interfaces.Utilities;
using App.Domain.Entities.Identity;
using App.Persistence;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.Extensions.Configuration;
using System;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;


/// <summary>
/// Command for registering a user
/// </summary>

namespace App.Application.EntitiesCommandsQueries.Users.Commands.RegisterUser
{

    public class RegisterUserCommand : IRequest<AuthUserViewModel>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string UserEmail { get; set; }
        public string UserPassWord { get; set; }
        public string RemoteIPAddress { get; set; }

    }

    public class RegisterUserCommandHandler : IRequestHandler<RegisterUserCommand, AuthUserViewModel>
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly AppDbContext _appDbContext;
        private readonly IJwtFactory _jwtFactory;
        private readonly ITokenFactory _tokenFactory;
        private readonly IMachineDateTime _dateTime;
        private readonly IConfigurationSection _configurationSection;
        private readonly INotificationService _notificationService;

        public RegisterUserCommandHandler(
            UserManager<IdentityUser> userManager,
            AppDbContext appDbContext,
            IJwtFactory jwtFactory,
            ITokenFactory tokenFactory,
            IMachineDateTime dateTime,
            IConfiguration configuration,
            INotificationService notificationService
            )
        {
            _userManager = userManager;
            _appDbContext = appDbContext;
            _jwtFactory = jwtFactory;
            _tokenFactory = tokenFactory;
            _dateTime = dateTime;
            _configurationSection = configuration.GetSection("Roles");
            _notificationService = notificationService;
        }

        public async Task<AuthUserViewModel> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var appUser = new IdentityUser { Email = request.UserEmail, UserName = request.UserEmail, PhoneNumber = request.PhoneNumber, PhoneNumberConfirmed = false };

                var identityResult = await _userManager.CreateAsync(appUser, request.UserPassWord);

                if (identityResult.Succeeded)
                {
                    
                    var userRoleResult = await _userManager.AddToRoleAsync(appUser, _configurationSection["defaultRole"]);
                }
                else
                {
                    // Remove user if there is errors
                    await _userManager.DeleteAsync(appUser);

                    throw new Exception(String.Join(" ", identityResult.Errors.Select(e => e.Description)));

                }

                var emailTokenBytes = Encoding.UTF8.GetBytes(await _userManager.GenerateEmailConfirmationTokenAsync(appUser));
                var confirmEmailToken = WebEncoders.Base64UrlEncode(emailTokenBytes);

                var user = new User
                {
                    FirstName = request.FirstName,
                    LastName = request.LastName,
                    UserEmail = request.UserEmail,
                    CreatedDate = _dateTime.Now,
                    EmailConfirmationToken = "Check Email",
                    Id = appUser.Id,

                };


                _appDbContext.AppUser.Add(user);


                var refreshToken = _tokenFactory.GenerateToken();

                var userRoles = await _userManager.GetRolesAsync(appUser);

                var userToken = await _jwtFactory.GenerateEncodedToken(appUser.Id, appUser.UserName, userRoles);

                var userRefreshToken = new RefreshToken
                {
                    CreatedBy = appUser.Id,
                    CreatedDate = _dateTime.Now,
                    LastEditedBy = appUser.Id,
                    LastEditedDate = _dateTime.Now,
                    Expires = _dateTime.Now.AddSeconds((double)userToken.ExpiresIn),
                    UserId = appUser.Id,
                    Token = refreshToken,
                    RemoteIpAddress = request.RemoteIPAddress

                };

                _appDbContext.RefreshToken.Add(userRefreshToken);


                await _appDbContext.SaveChangesAsync();


                await _notificationService.PublishNotificationAsync("EmailConfirm", "email-confirmation/" + user.Id + "/" + confirmEmailToken, user.UserEmail, user.FirstName + " " + user.LastName);



                return new AuthUserViewModel
                {
                    UserDetails = new UserDTO
                    {
                        FirstName = user.FirstName,
                        LastName = user.LastName,
                        UserEmail = user.UserEmail,
                        Id = user.Id,

                    },
                    UserToken = new AccessTokenViewModel
                    {
                        AccessToken = userToken,
                        RefreshToken = refreshToken

                    },
                    StatusMessage = "Success",
                    RequestStatus = 1



                };

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
