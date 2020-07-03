using System.Threading;
using System.Threading.Tasks;
using quested_backend.Domain.Entities;

namespace quested_backend.Domain.Repositories
{
    /// <summary>
    /// 
    /// </summary>
    public interface IUserRepository
    {
        /// <summary>
        /// Authenticates the user with email and password
        /// </summary>
        /// <param name="email">user's email</param>
        /// <param name="password">user's password</param>
        /// <param name="cancellationToken">token propagating information whether
        /// authentication should be cancelled</param>
        /// <returns>true if the authentication was successful, false otherwise</returns>
        Task<bool> AuthenticateAsync(string email, string password,
            CancellationToken cancellationToken = default);
        /// <summary>
        /// Sign's up user with his email and password
        /// </summary>
        /// <param name="user">user entity</param>
        /// <param name="password">user's password</param>
        /// <param name="role">user's role</param>
        /// <param name="cancellationToken">token propagating information whether
        /// sign up task should be cancelled</param>
        /// <returns>true if user was successfully signed up, false otherwise</returns>
        Task<bool> SignUpAsync(User user, string password, string role,
            CancellationToken cancellationToken = default);
        /// <summary>
        /// Obtains user entity by email
        /// </summary>
        /// <param name="requestEmail">user's email</param>
        /// <param name="cancellationToken">token propagating information whether
        /// user lookup task should be cancelled</param>
        /// <returns>user entity if user exists, null otherwise</returns>
        Task<User> GetByEmailAsync(string requestEmail, 
            CancellationToken cancellationToken = default);
    }
}