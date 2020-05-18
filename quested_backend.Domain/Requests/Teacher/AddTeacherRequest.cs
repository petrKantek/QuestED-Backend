﻿using System.Collections.Generic;

namespace quested_backend.Domain.Requests.Teacher
{
    public class AddTeacherRequest
    {
        public int SchoolId { get; set; }
        
        public string Firstname { get; set; }
        
        public string Lastname { get; set; }

        public virtual ICollection<int> ClassIds { get; set; }
        
        public virtual ICollection<int> CourseIds { get; set; }
    }
}