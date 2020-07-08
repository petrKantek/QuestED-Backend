using Microsoft.Extensions.Configuration;

namespace quested_backend
{
    /// <summary>
    /// This class used to be a startup class for testing containing mock authorization.
    /// The functionality was then transferred to InMemoryApplicationFactory.cs. It is only kept for future
    /// adjustments.
    /// </summary>
    public class TestStartup : Startup
    {
        public TestStartup(IConfiguration configuration) : base(configuration)
            { }
    }
}