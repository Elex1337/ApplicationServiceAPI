using ApplicationService.Domain.Entities;
using KDS.Primitives.FluentResult;
using MediatR;

namespace ApplicationService.Application.Applications.Commands;

public class ApplicationServiceRequestCommand : IRequest<Result<Request>>
{
    public ApplicationServiceRequestCommand(string phoneNumber, string fullName, string email, int requestTypeId, int userId)
    {
        PhoneNumber = phoneNumber;
        FullName = fullName;
        Email = email;
        RequestTypeId = requestTypeId;
        UserId = userId;
    }


    public string PhoneNumber { get; }
    public string FullName { get; }
    public string Email { get; }
    public int RequestTypeId { get; }
    public int UserId { get; }
    
}