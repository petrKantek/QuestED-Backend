using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using quested_backend.Domain.Configurations;
using quested_backend.Domain.Requests.User;
using quested_backend.Domain.Services;
using quested_backend.Domain.Services.Interfaces;
using quested_backend.Fixtures;
using Shouldly;
using Xunit;

namespace Domain.Tests.Services
{
    public class UserServiceTests : IClassFixture<UsersContextFactory>
    {
        private readonly IUserService _userService;

        public UserServiceTests(UsersContextFactory usersContextFactory)
        {
            _userService = new UserService(usersContextFactory.InMemoryUserManager, 
                Options.Create(
                    new AuthenticationSettings{ Secret = "long key-word to be matched", ExpirationDays = 7 }));
        }
        
    //     Id = "test_id",
    //     Email = "test_email@email.com",
    //     Name = "test_user"
    // };
    // user.PasswordHash = _passwordHasher.HashPassword(user, "quested");
    
        [Fact]
        public async Task signin_with_invalid_user_should_return_a_valid_token_response()
        {
            var result = await _userService.SignInAsync(
                new SignInRequest
                {
                    Email = "invalid_email", Password = "invalid_password"
                });
            
            result.ShouldBeNull();
        }

        [Fact]
        public async Task signin_with_valid_user_should_return_a_valid_token_response()
        {
            var result = await _userService.SignInAsync(new SignInRequest
            {
                Email = "test_email@email.com",
                Password = "quested",
                Role = "Student"
            });
            
            result.Token.ShouldNotBeEmpty();
        }
        
        [Fact]
        public async Task signup_should_create_a_new_user()
        {
            var newEmail = "new_email@email.com";
            var name = "Petr Kantek";

            var result =
                await _userService.SignUpAsync(new SignUpRequest
                    { Name = name, Email = newEmail, Password = "fimuni123" });

            result.Name.ShouldBe(name);
            result.Email.ShouldBe(newEmail);
        }
    }
}