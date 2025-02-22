using eCommerce.Core.DTO;
using FluentValidation;

namespace eCommerce.Core.Validation;

public class LoginRequestValidator : AbstractValidator<LogInRequest>
{
    public LoginRequestValidator()
    {
        //Email
        RuleFor(temp => temp.Email).NotEmpty().WithMessage("Email can't be empty")
        .EmailAddress().WithMessage("Invalid Email Address");
        RuleFor(temp => temp.Password).NotEmpty().WithMessage("Password Can't be empty");
    }
}

