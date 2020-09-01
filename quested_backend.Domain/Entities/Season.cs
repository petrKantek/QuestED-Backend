using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace quested_backend.Domain.Entities
{
    /// <summary>
    /// Entity representing Season(semester). Seasons are then further divided into
    /// episodes(lessons). Each seasons has its collection of courses that are taught
    /// in the season. 
    /// </summary>
    public partial class Season : BaseEntity
    {
        public Season()
        {
            Course = new HashSet<Course>();
            Episode = new HashSet<Episode>();
            SchoolOwnsSeason = new HashSet<SchoolOwnsSeason>();
        }
        public string Name { get; set; }
        
        /* relationships */
        public virtual ICollection<Course> Course { get; set; }
        public virtual ICollection<Episode> Episode { get; set; }
        public virtual ICollection<SchoolOwnsSeason> SchoolOwnsSeason { get; set; }
    }
}
