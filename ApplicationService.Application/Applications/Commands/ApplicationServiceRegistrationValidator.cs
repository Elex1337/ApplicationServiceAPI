using FluentValidation;

namespace ApplicationService.Application.Applications.Commands;

public class ApplicationServiceRegistrationValidator : AbstractValidator<ApplicationServiceRegistrationCommand>
{
    public ApplicationServiceRegistrationValidator()
    {
        RuleFor(x => x.Login);
        RuleFor(x => x.FullName);
        RuleFor(x => x.Email);
        RuleFor(x => x.PasswordHash);
    }
}