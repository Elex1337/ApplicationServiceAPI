using ApplicationService.Domain.Entities;
using KDS.Primitives.FluentResult;
using MediatR;

namespace ApplicationService.Application.Applications.Commands;

public class ApplicationServiceRegistrationCommand : IRequest<Result<User>>
{
    public ApplicationServiceRegistrationCommand(string login, string fullName, string email, string passwordHash)
    {
        Login = login;
        FullName = fullName;
        Email = email;
        PasswordHash = passwordHash;
    }

    public string Login { get; }
    public string FullName { get;  }
    public string Email { get;  }
    public string PasswordHash { get;  }

}