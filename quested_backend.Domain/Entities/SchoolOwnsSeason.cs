namespace quested_backend.Domain.Entities
{
    /// <summary>
    /// Representation of many-to-many relationship between School and Season
    /// </summary>
    public class SchoolOwnsSeason
    {
        /* relationships */
        public int SeasonId { get; set; }
        public int SchoolId { get; set; }
        public virtual School School { get; set; }
        public virtual Season Season { get; set; }
    }
}
