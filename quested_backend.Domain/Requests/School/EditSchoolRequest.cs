﻿using System.Collections.Generic;

namespace quested_backend.Domain.Requests.School
{
    public class EditSchoolRequest
    {
        public int Id { get; set; }

        public string Name { get; set; }
        
        public string Country { get; set; }
        
        // public virtual ICollection<int> SchoolOwnsSeasonIds { get; set; }
        //
        // public virtual ICollection<int> TeacherIds { get; set; }
    }
}