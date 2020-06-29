namespace quested_backend.Exceptions
{
    public class JsonError
    {
        public int EventId { get; set; }
        public object DetailedMessage { get; set; }
    }
}