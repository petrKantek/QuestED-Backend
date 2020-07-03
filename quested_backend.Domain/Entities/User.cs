using Microsoft.AspNetCore.Identity;

namespace quested_backend.Domain.Entities
{
    /// <summary>
    /// User entity inheriting all the necessary functionality from
    /// ASP.NET Core Identity library
    /// </summary>
    public class User : IdentityUser
    {
        public string Name { get; set; }
    }
}