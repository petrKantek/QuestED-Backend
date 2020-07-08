using System.Threading;
using System.Threading.Tasks;
using quested_backend.Domain.Requests_DTOs.User;
using quested_backend.Domain.Responses_DTOs;

namespace quested_backend.Domain.Services.Interfaces
{
    /// <summary>
    /// Interface securing the application.
    /// </summary>
    public interface IUserService
    {
        /// <summary>
        /// Gets user by get user request
        /// </summary>
        /// <param name="request">object with information about requested user</param>
        /// <param name="cancellationToken">token propagating information whether get user task should
        /// be cancelled</param>
        /// <returns>user response if requested user exists, null otherwise</returns>
        Task<UserResponse> GetUserAsync(GetUserRequest request,
            CancellationToken cancellationToken = default);
        
        /// <summary>
        /// Signs up user from sign up request
        /// </summary>
        /// <param name="request">object containing information about user to be signed up</param>
        /// <param name="cancellationToken">token propagating information whether sign up
        /// user task should be cancelled </param>
        /// <returns>user response if sign up was successful, null otherwise</returns>
        Task<UserResponse> SignUpAsync(SignUpRequest request,
            CancellationToken cancellationToken = default);
        
        /// <summary>
        /// Signs in user from sign in request
        /// </summary>
        /// <param name="request">object containing information about user to be signed in</param>
        /// <param name="cancellationToken">token propagating information whether sign in
        /// user task should be cancelled</param>
        /// <returns>token response object containing the JWT, null otherwise</returns>
        Task<TokenResponse> SignInAsync(SignInRequest request,
            CancellationToken cancellationToken = default);
    }
}