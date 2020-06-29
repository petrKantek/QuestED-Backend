using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace quested_backend.Domain.Entities
{
    public partial class Teacher : BaseEntity
    {
        public Teacher()
        {
            Class = new HashSet<Class>();
            Course = new HashSet<Course>();
        }
        public int SchoolId { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }

        public virtual School School { get; set; }
        public virtual ICollection<Class> Class { get; set; }
        public virtual ICollection<Course> Course { get; set; }
    }
}
