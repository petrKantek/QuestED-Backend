using System.ComponentModel.DataAnnotations;

namespace quested_backend.Domain.Requests_DTOs.Common
{
    /// <summary>
    /// Get request object from which all specific-entities-get requests inherit.
    /// </summary>
    public class GetBaseEntityRequest
    {
        [Range(1, int.MaxValue)]
        public int Id { get; set; }
    }
}