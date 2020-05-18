using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace quested_backend.Domain.Entities
{
    public partial class Season
    {
        public Season()
        {
            Course = new HashSet<Course>();
            Episode = new HashSet<Episode>();
            SchoolOwnsSeason = new HashSet<SchoolOwnsSeason>();
        }

        [DatabaseGenerated((DatabaseGeneratedOption.Identity))]
        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Course> Course { get; set; }
        public virtual ICollection<Episode> Episode { get; set; }
        public virtual ICollection<SchoolOwnsSeason> SchoolOwnsSeason { get; set; }
    }
}
