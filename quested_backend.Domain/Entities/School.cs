using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace quested_backend.Domain.Entities
{
    public partial class School : BaseEntity
    {
        public School()
        {
            SchoolOwnsSeason = new HashSet<SchoolOwnsSeason>();
            Teacher = new HashSet<Teacher>();
        }
        public string Name { get; set; }
        public string Country { get; set; }

        public virtual ICollection<SchoolOwnsSeason> SchoolOwnsSeason { get; set; }
        public virtual ICollection<Teacher> Teacher { get; set; }
    }
}
