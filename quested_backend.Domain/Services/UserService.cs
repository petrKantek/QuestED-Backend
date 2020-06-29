using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using quested_backend.Domain.Configurations;
using quested_backend.Domain.Entities;
using quested_backend.Domain.Repositories;
using quested_backend.Domain.Requests.User;
using quested_backend.Domain.Responses;
using quested_backend.Domain.Services.Interfaces;

namespace quested_backend.Domain.Services
{
    public class UserService : IUserService
    {
        private readonly AuthenticationSettings _authenticationSettings;
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository,
            IOptions<AuthenticationSettings> authenticationSettings)
        {
            _authenticationSettings = authenticationSettings.Value;
            _userRepository = userRepository;
        }
        
        public async Task<UserResponse> GetUserAsync(GetUserRequest request,
            CancellationToken cancellationToken)
        {
            var response = await _userRepository.GetByEmailAsync(request.Email, cancellationToken);
            return new UserResponse
            {
                Name = response.Name,
                Email = response.Email
            };
        }

        public async Task<UserResponse> SignUpAsync(SignUpRequest request,
            CancellationToken cancellationToken)
        {
            var user = new User
            {
                Email = request.Email,
                UserName = request.Email,
                Name = request.Name
            };
            bool result = await _userRepository.SignUpAsync(user,
                request.Password, cancellationToken);

            return result ? new UserResponse { Name = request.Name, Email = request.Email } 
                          : null;
        }

        public async Task<TokenResponse> SignInAsync(SignInRequest request,
            CancellationToken cancellationToken)
        {
            bool response = await _userRepository.AuthenticateAsync(request.Email,
                request.Password, cancellationToken);
            
            return response ? new TokenResponse{ Token = GenerateSecurityToken(request) }
                            : null;
        }

        /// <summary>
        /// Bruuh I am on fire
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        private string GenerateSecurityToken(SignInRequest request)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_authenticationSettings.Secret);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                    {
                        new Claim(ClaimTypes.Email, request.Email)
                      }),
                Expires = DateTime.UtcNow.AddDays(_authenticationSettings.ExpirationDays),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key),
                    SecurityAlgorithms.HmacSha256Signature )
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}