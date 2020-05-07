using System;
using System.Collections.Generic;

namespace quested_backend.Entities
{
    public partial class Teacher
    {
        public Teacher()
        {
            Class = new HashSet<Class>();
            Course = new HashSet<Course>();
        }

        public int Id { get; set; }
        public int SchoolId { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }

        public virtual School School { get; set; }
        public virtual ICollection<Class> Class { get; set; }
        public virtual ICollection<Course> Course { get; set; }
    }
}
