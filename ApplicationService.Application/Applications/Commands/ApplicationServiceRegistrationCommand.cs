using System.ComponentModel.DataAnnotations;
using ApplicationService.Domain.Entities;
using KDS.Primitives.FluentResult;
using MediatR;

namespace ApplicationService.Application.Applications.Commands;

public class ApplicationServiceRegistrationCommand : IRequest<Result<User>>
{
    public ApplicationServiceRegistrationCommand(string login, string fullName, string email, string password)
    {
        Login = login;
        FullName = fullName;
        Email = email;
        Password = password;
    }

    [Required]
    public string Login { get; }
    [Required]
    public string FullName { get;  }
    [Required]
    [EmailAddress]
    public string Email { get;  }
    [Required]
    public string Password { get;  }

}