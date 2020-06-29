using System.ComponentModel.DataAnnotations.Schema;

namespace quested_backend.Domain.Entities
{
    public class BaseEntity
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
    }
}