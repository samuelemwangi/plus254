using App.Application.EntitiesCommandsQueries.Users.Commands.LoginUser;
using App.Application.EntitiesCommandsQueries.Users.Queries.ViewModels;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.WebUtilities;
using System;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace App.Application.EntitiesCommandsQueries.Users.Commands.UpdateUserPassword
{
    public class UpdateUserPasswordCommand : BaseCommand, IRequest<AuthUserViewModel>
    {
        public string NewPassword { get; set; }
        public string PassWordResetToken { get; set; }
    }
    internal sealed class UpdateUserPasswordCommandHandler : IRequestHandler<UpdateUserPasswordCommand, AuthUserViewModel>
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly IMediator _mediator;

        public UpdateUserPasswordCommandHandler(UserManager<IdentityUser> userManager, IMediator mediator)
        {
            _userManager = userManager;
            _mediator = mediator;

        }

        public async Task<AuthUserViewModel> Handle(UpdateUserPasswordCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var user = await _userManager.FindByIdAsync(request.UserId);

                var resetPasswordToken = Encoding.UTF8.GetString(WebEncoders.Base64UrlDecode(request.PassWordResetToken));

                var updatePSWDResult = await _userManager.ResetPasswordAsync(user, resetPasswordToken, request.NewPassword);

                if (!updatePSWDResult.Succeeded) throw new Exception("Update Password Failed. Please try again");

                return await _mediator.Send(new LoginUserCommand { UserEmail = user.Email, Password = request.NewPassword });
            }
            catch (Exception e)
            {
                return new AuthUserViewModel
                {
                    StatusMessage = e.Message,
                    RequestStatus = 0
                };
            }
        }
    }
}
