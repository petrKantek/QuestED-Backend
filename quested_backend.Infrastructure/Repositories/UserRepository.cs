using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using quested_backend.Domain.Entities;
using quested_backend.Domain.Repositories;

namespace quested_backend.Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly SignInManager<User> _signInManager;
        private readonly UserManager<User> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public UserRepository(UserManager<User> userManager, SignInManager<User> signInManager,
            RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
        }
        public async Task<bool> AuthenticateAsync(string email, string password, CancellationToken cancellationToken)
        {
            var result = await _signInManager.PasswordSignInAsync(
                email, password, false, false);
            return result.Succeeded;
        }

        public async Task<bool> SignUpAsync(User user, string password, string role, CancellationToken cancellationToken)
        {
            
            var isCreated = await _userManager.CreateAsync(user, password);
            if (!isCreated.Succeeded) return false;
            if (!await _roleManager.RoleExistsAsync(role))
            {
                var newRole = new IdentityRole();
                newRole.Name = role;
                var addedRole = await _roleManager.CreateAsync(newRole);
                if (!addedRole.Succeeded) return false;
                var hasRole = await _userManager.AddToRoleAsync(user, role);
                return  hasRole.Succeeded;
            }
            var _hasRole = await _userManager.AddToRoleAsync(user, role);
            return  _hasRole.Succeeded;
        }
    
        public async Task<User> GetByEmailAsync(string requestEmail, CancellationToken cancellationToken)
        {
            return await _userManager.Users.FirstOrDefaultAsync(
                u => u.Email == requestEmail, cancellationToken);
        }
    }
}