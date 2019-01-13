using FluentValidation;

namespace App.Application.EntitiesCommandsQueries.Notifications.Commands.UpdateNotification
{
    public class UpdateNotificationValidator : AbstractValidator<UpdateNotificationCommand>
    {
        public UpdateNotificationValidator()
        {
            RuleFor(e => e.MailQueued).NotEmpty();
        }

    }
}
