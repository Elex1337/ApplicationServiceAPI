using FluentValidation;

namespace ApplicationService.Application.Applications.Commands;

public class ApplicationServiceRequestValidator : AbstractValidator<ApplicationServiceRequestCommand>
{
    public ApplicationServiceRequestValidator()
    {
        RuleFor(x => x.UserId)
            .NotEmpty().WithMessage("Поле не должно быть пустым");
        RuleFor(x => x.RequestTypeId)
            .NotEmpty().WithMessage("Поле не должн быть пустым")
            .InclusiveBetween(1,3).WithMessage("только 3 requestTypeId");
    }


}