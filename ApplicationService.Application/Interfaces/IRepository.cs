using Microsoft.EntityFrameworkCore.Storage;
using ApplicationService.Domain.Entities;

namespace ApplicationService.Application.Interfaces
{
    public interface IRepository
    {
        Task SaveChangesAsync(CancellationToken cancellationToken);

        Task AddUserAsync(User user, CancellationToken cancellationToken);
    }
}