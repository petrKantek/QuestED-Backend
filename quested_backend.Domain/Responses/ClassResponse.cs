using System.Collections.Generic;
using quested_backend.Domain.Entities;

namespace quested_backend.Domain.Responses
{
    public class ClassResponse
    {
        public int Id { get; set; }
        
        public string Name { get; set; }

        public TeacherResponse TeacherResponse { get; set; }
        
        public int TeacherId { get; set; }
         
        public ICollection<PupilInClass> PupilInClass { get; set; }
    }
}