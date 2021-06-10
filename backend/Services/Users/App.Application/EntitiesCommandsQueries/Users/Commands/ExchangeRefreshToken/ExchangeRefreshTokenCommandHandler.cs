using App.Application.EntitiesCommandsQueries.Token.Queries.ViewModels;
using App.Application.EntitiesCommandsQueries.Users.Queries.ViewModels;
using App.Application.Interfaces.Auth;
using App.Application.Interfaces.Utilities;
using App.Persistence;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

/// <summary>
/// Handle Exchange Refresh Token
/// </summary>

namespace App.Application.EntitiesCommandsQueries.Users.Commands.ExchangeRefreshToken
{
    public class ExchangeRefreshTokenCommand : IRequest<AuthUserViewModel>
    {
        public string AccessToken { get; set; }
        public string RefreshToken { get; set; }
        public string RemoteIPAddress { get; set; }

    }
    public class ExchangeRefreshTokenCommandHandler : IRequestHandler<ExchangeRefreshTokenCommand, AuthUserViewModel>
    {
        private readonly IJwtTokenValidator _jwtTokenValidator;
        private readonly IJwtFactory _jwtFactory;
        private readonly ITokenFactory _tokenFactory;
        private readonly IConfigurationSection _configurationSection;
        private readonly AppDbContext _appDbContext;
        private readonly IMachineDateTime _dateTime;
        private readonly UserManager<IdentityUser> _userManager;

        public ExchangeRefreshTokenCommandHandler(
            IJwtTokenValidator jwtTokenValidator, 
            IJwtFactory jwtFactory,
            ITokenFactory tokenFactory, 
            IConfiguration configuration,
            AppDbContext appDbContext, 
            IMachineDateTime dateTime, 
            UserManager<IdentityUser> userManager
           )
        {
            _jwtTokenValidator = jwtTokenValidator;
            _jwtFactory = jwtFactory;
            _tokenFactory = tokenFactory;
            _configurationSection = configuration.GetSection("AuthSettings");
            _appDbContext = appDbContext;
            _dateTime = dateTime;
            _userManager = userManager;
        }

        public async Task<AuthUserViewModel> Handle(ExchangeRefreshTokenCommand request, CancellationToken cancellationToken)
        {
            try
            {

                var signingKey = _configurationSection["SecretKey"];

                var claimsPrincipal = _jwtTokenValidator.GetPrincipalFromToken(request.AccessToken, signingKey);
                if (claimsPrincipal == null) throw new Exception("Invalid access Token provided");

                var id = claimsPrincipal.Claims.First(c => c.Type == "id");

                var user = await _appDbContext.AppUser
                    .Where(u => u.Id == id.Value)
                    .Select(UserDTO.Projection)
                    .FirstOrDefaultAsync(cancellationToken);

                var userTokenDetails = await _appDbContext.RefreshToken
                    .Where(t => t.Token == request.RefreshToken && t.UserId == user.Id)
                    .FirstOrDefaultAsync(cancellationToken);

                if (user == null || userTokenDetails == null) throw new Exception("Kindly sign in to continue");

                var userRoles = await _userManager.GetRolesAsync(new IdentityUser { Id = id.Value });

                var accessToken = await _jwtFactory.GenerateEncodedToken(id.Value, user.UserEmail, userRoles);

                var refreshToken = _tokenFactory.GenerateToken();

                userTokenDetails.LastEditedBy = id.Value;
                userTokenDetails.Token = refreshToken;
                userTokenDetails.LastEditedDate = _dateTime.Now;
                userTokenDetails.Expires = _dateTime.Now.AddSeconds((double)accessToken.ExpiresIn);
                userTokenDetails.RemoteIpAddress = request.RemoteIPAddress;


                _appDbContext.RefreshToken.Update(userTokenDetails);
                await _appDbContext.SaveChangesAsync(cancellationToken);

                return new AuthUserViewModel
                {
                    UserDetails = user,
                    UserToken = new AccessTokenViewModel
                    {
                        AccessToken = accessToken,
                        RefreshToken = refreshToken,
                    },
                    RequestStatus = 1,
                    StatusMessage = "Success"
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
