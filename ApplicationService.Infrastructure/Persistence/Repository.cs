using ApplicationService.Application.Interfaces;
using ApplicationService.Domain.Entities;
using Microsoft.EntityFrameworkCore;

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
        public async Task<User> GetUserByLoginOrEmailAsync(string login, string email, CancellationToken cancellationToken)
        {
            return await _dataContext.Users.FirstOrDefaultAsync(u => u.Login == login || u.Email == email, cancellationToken);
        }

        public async Task AddRequestAsync(Request eRequest, CancellationToken cancellationToken)
        {
            await _dataContext.Requests.AddAsync(eRequest, cancellationToken);
        }

        public IQueryable<Request> GetMyRequests()
        {
            return _dataContext.Set<Request>();
        }

        public  async Task<User> GetUserByLoginAsync(string login)
        {
            return await _dataContext.Users.SingleOrDefaultAsync(u => u.Login == login);
        }

        public async Task<bool> VerifyPasswordAsync(User user, string password)
        {
            return user.Password == password;
        }
    }
}
