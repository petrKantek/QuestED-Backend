namespace quested_backend.Domain.Configurations
{
    /// <summary>
    /// Contains the secret phrase used in encryption of JWT and the length
    /// of its validity
    /// </summary>
    public class AuthenticationSettings
    {
        public string Secret { get; set; }
        public int ExpirationDays { get; set; }
    }
}