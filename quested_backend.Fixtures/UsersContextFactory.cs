using System.Collections.Generic;
using System.Linq;
using System.Threading;
using Microsoft.AspNetCore.Identity;
using Moq;
using quested_backend.Domain.Entities;
using quested_backend.Domain.Repositories;

namespace quested_backend.Fixtures
{
    /// <summary>
    /// In-memory database used for testing user service class 
    /// </summary>
    public class UsersContextFactory
    {
        private readonly PasswordHasher<User> _passwordHasher;
        private readonly IList<User> _users;

        /// <summary>
        /// Populates DB with some user data
        /// </summary>
        public UsersContextFactory()
        {
            _passwordHasher = new PasswordHasher<User>();
            _users = new List<User>();

            var user = new User
            {
                Id = "test_id",
                Email = "test_email@email.com",
                Name = "test_user",
            };
            user.PasswordHash = _passwordHasher.HashPassword(user, "quested");
            
            _users.Add(user);
        }

        public IUserRepository InMemoryUserManager => GetInMemoryUserManager();

        /// <summary>
        /// creates mock user manager
        /// </summary>
        /// <returns> mock user manager </returns>
        private IUserRepository GetInMemoryUserManager()
        {
            var fakeUserService = new Mock<IUserRepository>();

            fakeUserService.Setup(x => x.AuthenticateAsync(
                        It.IsAny<string>(), It.IsAny<string>(), CancellationToken.None))
                .ReturnsAsync((string email, string password, CancellationToken token) =>
                {
                    var user = _users.FirstOrDefault(x => x.Email == email);
                    if (user == null)
                        return false;
                    var result = _passwordHasher.VerifyHashedPassword(
                            user, user.PasswordHash, password);
                    
                    return result == PasswordVerificationResult.Success;
                });

            fakeUserService.Setup(x =>
                    x.GetByEmailAsync(It.IsAny<string>(), CancellationToken.None))
                    .ReturnsAsync((string email, CancellationToken token) =>
                        _users.First(x =>
                            x.Email == email));
            
            fakeUserService.Setup(x =>
                    x.SignUpAsync(It.IsAny<User>(), It.IsAny<string>(), 
                        It.IsAny<string>(), CancellationToken.None))
                .ReturnsAsync((User user, string password, string role, CancellationToken token) =>
                {
                    user.PasswordHash = _passwordHasher.HashPassword(user, password);
                    _users.Add(user);
                    return true;
                });
            return fakeUserService.Object;
        }
    }
}