using FluentValidation;

namespace ApplicationService.Application.Applications.Commands;

public class ApplicationServiceRegistrationValidator : AbstractValidator<ApplicationServiceRegistrationCommand>
{
    public ApplicationServiceRegistrationValidator()
    {
        RuleFor(x => x.Login)
            .NotEmpty().WithMessage("не должно быть пустым")
            .Length(4, 20).WithMessage("должно быть от 4 до 20 символов");

        RuleFor(x => x.FullName)
            .NotEmpty().WithMessage("не должно быть пустым")
            .Length(2, 50).WithMessage("должно быть от 2 до 50 символов");

        RuleFor(x => x.Email)
            .NotEmpty().WithMessage("не должно быть пустым")
            .EmailAddress().WithMessage("должен быть действительным адресом электронной почты");

        RuleFor(x => x.Password)
            .NotEmpty().WithMessage("Password не должно быть пустым")
            .MinimumLength(6).WithMessage("Password должно быть не менее 6 символов")
            .Matches("[A-Z]").WithMessage("Password должно содержать хотя бы одну заглавную букву")
            .Matches("[a-z]").WithMessage("Password должно содержать хотя бы одну строчную букву")
            .Matches("[0-9]").WithMessage("Password должно содержать хотя бы одну цифру");
    }
}