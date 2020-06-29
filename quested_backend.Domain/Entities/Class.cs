using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using quested_backend.Domain.Responses;

namespace quested_backend.Domain.Entities
{
    public class Class : BaseEntity
    {
        public Class()
        {
            PupilInClass = new HashSet<PupilInClass>();
        }
        public int TeacherId { get; set; }
        public string Name { get; set; }

        public Teacher Teacher { get; set; }
        public virtual ICollection<PupilInClass> PupilInClass { get; set; }
    }
}
