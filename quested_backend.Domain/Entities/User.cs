using Microsoft.AspNetCore.Identity;

namespace quested_backend.Domain.Entities
{
    public class User : IdentityUser
    {
        public string Name { get; set; }
    }
}