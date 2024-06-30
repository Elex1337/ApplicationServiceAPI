using ApplicationService.Application.Interfaces;
using ApplicationService.Domain.Entities;
using KDS.Primitives.FluentResult;
using MediatR;
using Microsoft.Extensions.Logging;

namespace ApplicationService.Application.Applications.Commands
{
    public class RegisterUserCommandHandler : IRequestHandler<ApplicationServiceRegistrationCommand, Result<User>>
    {
        private readonly IRepository _repository;
        private readonly ILogger<RegisterUserCommandHandler> _logger;

        public RegisterUserCommandHandler(IRepository repository, ILogger<RegisterUserCommandHandler> logger)
        {
            _repository = repository;
            _logger = logger;
        }

        public async Task<Result<User>> Handle(ApplicationServiceRegistrationCommand request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Start command");

            string hashedPassword = BCrypt.Net.BCrypt.HashPassword(request.PasswordHash);

            var user = new User
            {
                Login = request.Login,
                FullName = request.FullName,
                Email = request.Email,
                PasswordHash = hashedPassword
            };

            await _repository.AddUserAsync(user, cancellationToken);
            await _repository.SaveChangesAsync(cancellationToken);

            _logger.LogInformation("End command");

            return Result.Success(user);
        }


    }
}