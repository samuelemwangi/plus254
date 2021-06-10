using FluentValidation;

/// <summary>
/// Validate Register Commands
/// </summary>

namespace App.Application.EntitiesCommandsQueries.Users.Commands.RegisterUser
{
    public class RegisterUserCommandValidator : AbstractValidator<RegisterUserCommand>
    {
        public RegisterUserCommandValidator()
        {
            RuleFor(u => u.FirstName).NotEmpty();
            RuleFor(u => u.LastName).NotEmpty();
            RuleFor(u => u.UserEmail).NotEmpty().EmailAddress();
            RuleFor(u => u.UserPassWord).NotEmpty()
                .Matches("[A-Z]").WithMessage("Password must contain one or more capital letters.")
                .Matches("[a-z]").WithMessage("Password must contain one or more lowercase letters.")
                .Matches(@"\d").WithMessage("Password must contain one or more digits.")
                .Matches(@"[][""!@$%^&*(){}:;<>,.?/+_=|'~\\-]").WithMessage("Password must contain one or more special characters.")
                .Matches("^[^£# “”]*$").WithMessage("Password must not contain the following characters £ # “” or spaces.");

        }
    }
}
