using System.Collections.Generic;

namespace quested_backend.Domain.Requests_DTOs.Class
{
    public class EditClassRequest
    {
        public int Id { get; set; }
        
        public string Name { get; set; }
        
        public int TeacherId { get; set; }
        
       // public virtual ICollection<int> PupilInClass { get; set; }
    }
}