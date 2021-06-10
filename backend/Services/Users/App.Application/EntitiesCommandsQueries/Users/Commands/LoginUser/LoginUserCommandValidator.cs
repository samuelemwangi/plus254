using FluentValidation;

/// <summary>
/// Validate logins
/// </summary>

namespace App.Application.EntitiesCommandsQueries.Users.Commands.LoginUser
{
    public class LoginUserCommandValidator : AbstractValidator<LoginUserCommand>
    {
        public LoginUserCommandValidator()
        {
            RuleFor(x => x.UserEmail).NotEmpty();
            RuleFor(x => x.Password).NotEmpty();

        }
    }
}
