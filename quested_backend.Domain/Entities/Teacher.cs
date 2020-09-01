using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace quested_backend.Domain.Entities
{
    /// <summary>
    /// Entity representing Teacher. Each teacher has his firstname and lastname. Further
    /// information about respective teachers is omitted, but can be possibly added later.
    /// Each teacher teaches only in max. one school. Each teacher has a collection of courses
    /// and classes one teaches.
    /// </summary>
    public partial class Teacher : BaseEntity
    {
        public Teacher()
        {
            Class = new HashSet<Class>();
            Course = new HashSet<Course>();
        }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        
        /* relationships */
        public int SchoolId { get; set; }
        public virtual School School { get; set; }
        public virtual ICollection<Class> Class { get; set; }
        public virtual ICollection<Course> Course { get; set; }
    }
}
