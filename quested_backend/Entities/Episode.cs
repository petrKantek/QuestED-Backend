using System;
using System.Collections.Generic;

namespace quested_backend.Entities
{
    public partial class Episode
    {
        public Episode()
        {
            Question = new HashSet<Question>();
        }

        public int Id { get; set; }
        public int SeasonId { get; set; }
        public string Name { get; set; }

        public virtual Season Season { get; set; }
        public virtual ICollection<Question> Question { get; set; }
    }
}
