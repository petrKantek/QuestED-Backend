using System.Threading;
using System.Threading.Tasks;
using quested_backend.Domain.Entities;

namespace quested_backend.Domain.Repositories
{
    public interface IUserRepository
    {
        Task<bool> AuthenticateAsync(string email, string password,
            CancellationToken cancellationToken = default);
        Task<bool> SignUpAsync(User user, string password, 
            CancellationToken cancellationToken = default);
        Task<User> GetByEmailAsync(string requestEmail, 
            CancellationToken cancellationToken = default);
    }
}