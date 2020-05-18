namespace quested_backend.Domain.Entities
{
    public partial class SchoolOwnsSeason
    {
        public int SeasonId { get; set; }
        public int SchoolId { get; set; }

        public virtual School School { get; set; }
        public virtual Season Season { get; set; }
    }
}
