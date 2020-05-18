using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using quested_backend.Domain.Responses;

namespace quested_backend.Domain.Entities
{
    public class Class
    {
        public Class()
        {
            PupilInClass = new HashSet<PupilInClass>();
        }

        [DatabaseGenerated((DatabaseGeneratedOption.Identity))]
        public int Id { get; set; }
        public int TeacherId { get; set; }
        public string Name { get; set; }

        public Teacher Teacher { get; set; }
        public virtual ICollection<PupilInClass> PupilInClass { get; set; }
    }
}
