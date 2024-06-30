using KDS.Primitives.FluentResult;
using MediatR;

namespace ApplicationService.Application.Applications.Commands
{
    public class LoginCommand : IRequest<Result<string>>
    {
        public LoginCommand(string login, string password)
        {
            Login = login;
            Password = password;
        }

        public string Login { get; }
        public string Password { get; }
    }
}