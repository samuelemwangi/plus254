using App.Application.Interfaces.Notifications;
using App.Persistence;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

/// <summary>
/// Reset Password Command & Handler
/// </summary>

namespace App.Application.EntitiesCommandsQueries.Users.Commands.ResetPassword
{

    public class ResetPasswordCommand : BaseCommand, IRequest<int>
    {
        public string UserEmail { get; set; }
    }

    internal sealed class ResetPasswordCommandHandler : IRequestHandler<ResetPasswordCommand, int>
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly AppDbContext _appDbContext;
        private readonly INotificationService _notificationService;
        private readonly ILogger<ResetPasswordCommandHandler> _resetPasswordLogger;
        public ResetPasswordCommandHandler(UserManager<IdentityUser> userManager, INotificationService notificationService, AppDbContext appDbContext)
        {
            _userManager = userManager;
            _notificationService = notificationService;
            _appDbContext = appDbContext;
        }

        public async Task<int> Handle(ResetPasswordCommand request, CancellationToken cancellationToken)
        {
            try
            {
                Console.WriteLine(request.UserEmail);

                var user = await _userManager.FindByNameAsync(request.UserEmail);

                var userDetails = await _appDbContext.AppUser
                    .Where(e => e.UserEmail == user.Email && e.Id == user.Id)
                    .FirstOrDefaultAsync(cancellationToken);

                if (userDetails == null) throw new Exception("No user Exists");



                var resetTokenBytes = Encoding.UTF8.GetBytes(await _userManager.GeneratePasswordResetTokenAsync(user));
                var resetToken = WebEncoders.Base64UrlEncode(resetTokenBytes);



                await _notificationService.PublishNotificationAsync("PasswordReset", "password-reset/" + user.Id + "/" + resetToken, user.Email, userDetails.FirstName + " " + userDetails.LastName);
                

                return 1;


            }
            catch (Exception e)
            {
                
                _resetPasswordLogger.LogError(e.StackTrace);

                return 0;
            }
        }
    }
}
