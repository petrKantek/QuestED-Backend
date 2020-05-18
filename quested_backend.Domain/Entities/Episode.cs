using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace quested_backend.Domain.Entities
{
    public class Episode
    {
        public Episode()
        {
            Question = new HashSet<Question>();
        }
        
        [DatabaseGenerated((DatabaseGeneratedOption.Identity))]
        public int Id { get; set; }
        public int SeasonId { get; set; }
        public string Name { get; set; }

        public virtual Season Season { get; set; }
        public virtual ICollection<Question> Question { get; set; }
    }
}
