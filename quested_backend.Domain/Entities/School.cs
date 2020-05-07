using System;
using System.Collections.Generic;

namespace quested_backend.Entities
{
    public partial class School
    {
        public School()
        {
            SchoolOwnsSeason = new HashSet<SchoolOwnsSeason>();
            Teacher = new HashSet<Teacher>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Country { get; set; }

        public virtual ICollection<SchoolOwnsSeason> SchoolOwnsSeason { get; set; }
        public virtual ICollection<Teacher> Teacher { get; set; }
    }
}
