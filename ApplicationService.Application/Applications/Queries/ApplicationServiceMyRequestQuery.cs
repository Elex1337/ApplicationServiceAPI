using ApplicationService.Domain.Entities;
using KDS.Primitives.FluentResult;
using MediatR;

namespace ApplicationService.Application.Applications.Queries;

public class ApplicationServiceMyRequestQuery : IRequest<Result<List<Request>>>, IRequest<Result<Request>>
{
    public ApplicationServiceMyRequestQuery(int userId)
    {
        UserId = userId;
    }

    public int UserId { get; }
}