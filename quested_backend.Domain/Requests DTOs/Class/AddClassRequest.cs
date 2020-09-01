using System.Collections.Generic;

namespace quested_backend.Domain.Requests_DTOs.Class
{
    public class AddClassRequest
    { 
        public string Name { get; set; }

        public int TeacherId { get; set; }
    }
}