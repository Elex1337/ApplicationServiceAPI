using ApplicationService.Application.Interfaces;
using ApplicationService.Domain.Entities;
using KDS.Primitives.FluentResult;
using MediatR;
using Microsoft.Extensions.Logging;

namespace ApplicationService.Application.Applications.Commands
{
    public class ApplicationRegisterUserCommandHandler : IRequestHandler<ApplicationServiceRegistrationCommand, Result<User>>
    {
        private readonly IRepository _repository;
        private readonly ILogger<ApplicationRegisterUserCommandHandler> _logger;

        public ApplicationRegisterUserCommandHandler(IRepository repository, ILogger<ApplicationRegisterUserCommandHandler> logger)
        {
            _repository = repository;
            _logger = logger;
        }

        public async Task<Result<User>> Handle(ApplicationServiceRegistrationCommand request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Start command");
            
            var existingUser = await _repository.GetUserByLoginOrEmailAsync(request.Login, request.Email, cancellationToken);
            
            if (existingUser != null)
            {
                return Result.Failure<User>(new Error("400", "Пользователь с таким логином или же почтой уже существует"));
            }

            var user = new User
            {
                Login = request.Login,
                FullName = request.FullName,
                Email = request.Email,
                Password = request.Password
            };

            await _repository.AddUserAsync(user, cancellationToken);
            await _repository.SaveChangesAsync(cancellationToken);

            _logger.LogInformation("End command");

            return Result.Success(user);
        }


    }
}