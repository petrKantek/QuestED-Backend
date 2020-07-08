using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace quested_backend.Domain.Entities
{
    /// <summary>
    /// Entity representing Class. Class has a name and reference to the teacher
    /// of the class. It also has a collection of pupils in the class.
    /// </summary>
    public class Class : BaseEntity
    {
        public Class()
        {
            PupilInClass = new HashSet<PupilInClass>();
        }
        public string Name { get; set; }
        
        /* relationships */
        public int TeacherId { get; set; }
        public Teacher Teacher { get; set; }
        public virtual ICollection<PupilInClass> PupilInClass { get; set; }
    }
}
