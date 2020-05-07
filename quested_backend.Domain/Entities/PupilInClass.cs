using System;
using System.Collections.Generic;

namespace quested_backend.Entities
{
    public partial class PupilInClass
    {
        public int PupilId { get; set; }
        public int ClassId { get; set; }

        public virtual Class Class { get; set; }
        public virtual Pupil Pupil { get; set; }
    }
}
