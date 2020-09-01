using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace quested_backend.Domain.Entities
{
    /// <summary>
    /// Entity representing Episode. Season has many episodes. Each Episode has
    /// a name and reference to the season it is a part of. It also has a collection of questions
    /// that were asked in the episode. 
    /// </summary>
    public class Episode : BaseEntity
    {
        public Episode()
        {
            Question = new HashSet<Question>();
        }
        public string Name { get; set; }
        
        /* relationships */
        public int SeasonId { get; set; }
        public virtual Season Season { get; set; }
        public virtual ICollection<Question> Question { get; set; }
    }
}
