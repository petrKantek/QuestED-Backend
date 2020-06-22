using System.Threading;
using System.Threading.Tasks;
using quested_backend.Domain.Entities;
using quested_backend.Domain.Requests.User;
using quested_backend.Domain.Responses;

namespace quested_backend.Domain.Services
{
    public interface IUserService
    {
        Task<UserResponse> GetUserAsync(GetUserRequest request,
            CancellationToken cancellationToken = default);

        Task<UserResponse> SignUpAsync(SignUpRequest request,
            CancellationToken cancellationToken = default);

        Task<TokenResponse> SignInAsync(SignInRequest request,
            CancellationToken cancellationToken = default);
    }
}