using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.WebUtilities;
using System;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

/// <summary>
/// use this when confirming Email
/// </summary>

namespace App.Application.EntitiesCommandsQueries.Users.Commands.ConfirmEmail
{
    public class ConfirmEmailCommand : BaseCommand, IRequest<int>
    {
        public string UserIdentityId { get; set; }
        public string ConfirmEmailToken { get; set; }
    }

    internal sealed class ConfirmEmailCommandHandler : IRequestHandler<ConfirmEmailCommand, int>
    {
        private readonly UserManager<IdentityUser> _userManager;
        public ConfirmEmailCommandHandler(UserManager<IdentityUser> userManager)
        {
            _userManager = userManager;

        }
        public async Task<int> Handle(ConfirmEmailCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var appUser = await _userManager.FindByIdAsync(request.UserIdentityId);

                var emailToken = Encoding.UTF8.GetString(WebEncoders.Base64UrlDecode(request.ConfirmEmailToken));

                Console.WriteLine(emailToken);

                var result = await _userManager.ConfirmEmailAsync(appUser, emailToken);

                if (!result.Succeeded) throw new Exception("Confirmation failed");

                return 1;

            }
            catch (Exception e)
            {

                Console.WriteLine(e.Message);
                return 0;
            }
        }
    }
}
