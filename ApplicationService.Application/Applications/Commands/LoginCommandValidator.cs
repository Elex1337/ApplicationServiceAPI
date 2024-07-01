using FluentValidation;

namespace ApplicationService.Application.Applications.Commands;

public class LoginCommandValidator : AbstractValidator<LoginCommand>

{
    public LoginCommandValidator()
    {
        RuleFor(x => x.Login).NotEmpty().WithMessage("Не долнж быть пустым");
        RuleFor(x => x.Password).NotEmpty().WithMessage("не должно быть пустым");
    }
}