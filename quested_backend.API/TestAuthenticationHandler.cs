using System;
using System.Security.Claims;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace quested_backend
{
    public class TestAuthenticationHandler : AuthenticationHandler<AuthenticationSchemeOptions>
    {
        public TestAuthenticationHandler(IOptionsMonitor<AuthenticationSchemeOptions> options,
            ILoggerFactory logger, UrlEncoder encoder, ISystemClock clock)
            : base(options, logger, encoder, clock)
            { }

        protected override Task<AuthenticateResult> HandleAuthenticateAsync()
        {
            // var authenticationTicket = new AuthenticationTicket
            // (
            //     new ClaimsPrincipal(Options.Identity),
            //     new AuthenticationProperties(),
            //     "Test Scheme");
            //
            // return Task.FromResult(AuthenticateResult.Success(authenticationTicket));
            
            var claims = new[]
            {
                new Claim(ClaimTypes.Name, "Test user"),
                new Claim(ClaimTypes.NameIdentifier, Guid.NewGuid().ToString()),
                new Claim(ClaimTypes.Role, "Admin"),
                new Claim(ClaimTypes.Role, "Teacher"),
                new Claim(ClaimTypes.Role, "Student")
            };
            var identity = new ClaimsIdentity(claims, "Test");
            var principal = new ClaimsPrincipal(identity);
            var ticket = new AuthenticationTicket(principal, "Test");
            
            var result = AuthenticateResult.Success(ticket);
            return Task.FromResult(result);
        }
    }

    // public static class TestAuthenticationExtensions
    // {
    //     public static AuthenticationBuilder AddTestAuth(this AuthenticationBuilder builder,
    //         Action<AuthenticationSchemeOptions> configureOptions)
    //     {
    //         return builder.AddScheme<AuthenticationSchemeOptions, TestAuthenticationHandler>(
    //             "Test Scheme", "Test Auth", configureOptions);
    //     }
    // }

    // public class TestAuthenticationOptions : AuthenticationSchemeOptions
    // {
    //     public virtual ClaimsIdentity Identity { get; } = new ClaimsIdentity(new[]
    //     {
    //         new Claim("http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier"
    //             , Guid.NewGuid().ToString(), "test"), 
    //     });
    // }
}