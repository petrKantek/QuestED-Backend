namespace quested_backend.Domain.Entities
{
    /// <summary>
    /// Representation of many-to-many relationship between Pupil and Class
    /// </summary>
    public partial class PupilInClass
    {
        /* relationships */
        public int PupilId { get; set; }
        public int ClassId { get; set; }
        public virtual Class Class { get; set; }
        public virtual Pupil Pupil { get; set; }
    }
}
