using ApplicationService.Application.Interfaces;
using ApplicationService.Domain.Entities;

namespace ApplicationService.Infrastructure.Persistence
{
    public class Repository : IRepository
    {
        private readonly DataContext _dataContext;
        public Repository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }
        public async Task SaveChangesAsync(CancellationToken cancellationToken)
        {
            await _dataContext.SaveChangesAsync(cancellationToken);

        }
        public async Task AddUserAsync(User user, CancellationToken cancellationToken)
        {
            await _dataContext.Users.AddAsync(user, cancellationToken);
        }
    }
}
