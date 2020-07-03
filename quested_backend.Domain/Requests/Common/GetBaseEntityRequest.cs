namespace quested_backend.Domain.Requests.Common
{
    /// <summary>
    /// Get request object from which all specific-entities get requests inherit.
    /// </summary>
    public class GetBaseEntityRequest
    {
        public int Id { get; set; }
    }
}