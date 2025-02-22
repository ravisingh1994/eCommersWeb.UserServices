using eCommerce.Core.DTO;
using FluentValidation;

namespace eCommerce.Core.Validation;

public class RegisterRequestValidator : AbstractValidator<RegisterRequest>
{
    public RegisterRequestValidator()
    {
        RuleFor(item => item.Email).NotEmpty().WithMessage("Email can't be empty")
            .EmailAddress().WithMessage("Enter the write Email");
        RuleFor(item => item.PersonName).NotEmpty().WithMessage("Person can't be Blank")
            .MaximumLength(50);
        RuleFor(item => item.Password).NotEmpty().WithMessage("Password can't be Empty")
           .MaximumLength(50);
        RuleFor(item => item.Gender).IsInEnum();

    }

}

