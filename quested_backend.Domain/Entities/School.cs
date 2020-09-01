using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace quested_backend.Domain.Entities
{
    /// <summary>
    /// Entity representing schools. The main purpose of this entity is to
    /// keep a collection of Teachers teaching in the school and a collection
    /// of seasons(semesters) during which the school operates
    /// </summary>
    public partial class School : BaseEntity
    {
        public School()
        {
            SchoolOwnsSeason = new HashSet<SchoolOwnsSeason>();
            Teacher = new HashSet<Teacher>();
        }
        public string Name { get; set; }
        public string Country { get; set; }
        
        /* relationships */
        public virtual ICollection<SchoolOwnsSeason> SchoolOwnsSeason { get; set; }
        public virtual ICollection<Teacher> Teacher { get; set; }
    }
}
