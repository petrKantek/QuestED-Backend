namespace quested_backend.Domain.Requests.User
{
    public class SignInRequest
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }
    }
}