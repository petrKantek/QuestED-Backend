namespace quested_backend.Exceptions
{
    /// <summary>
    /// User-defined object for json exception
    /// </summary>
    public class JsonError
    {
        public int EventId { get; set; }
        public object DetailedMessage { get; set; }
    }
}