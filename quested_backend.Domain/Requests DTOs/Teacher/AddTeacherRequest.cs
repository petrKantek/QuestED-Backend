using System.Collections.Generic;

namespace quested_backend.Domain.Requests_DTOs.Teacher
{
    public class AddTeacherRequest
    {
        public string Firstname { get; set; }
             
        public string Lastname { get; set; }
        
        public int SchoolId { get; set; }
    }
}