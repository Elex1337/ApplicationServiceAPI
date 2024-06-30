using Microsoft.EntityFrameworkCore.Storage;
using ApplicationService.Domain.Entities;

namespace ApplicationService.Application.Interfaces
{
    public interface IRepository
    {
        Task SaveChangesAsync(CancellationToken cancellationToken);

        Task AddUserAsync(User user, CancellationToken cancellationToken);
        Task<User> GetUserByLoginOrEmailAsync(string login, string email, CancellationToken cancellationToken); // Новый метод
        Task AddRequestAsync(Request eRequest, CancellationToken cancellationToken);
        IQueryable<Request> GetMyRequests();
    }
}