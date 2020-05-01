using System;
using System.Collections.Generic;

namespace quested_backend.Entities
{
    public partial class Class
    {
        public Class()
        {
            PupilInClass = new HashSet<PupilInClass>();
        }

        public int Id { get; set; }
        public int TeacherId { get; set; }
        public string Name { get; set; }

        public virtual Teacher Teacher { get; set; }
        public virtual ICollection<PupilInClass> PupilInClass { get; set; }
    }
}
