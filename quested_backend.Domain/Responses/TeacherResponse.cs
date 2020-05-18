namespace quested_backend.Domain.Responses
{
    public class TeacherResponse
    {
        public int Id { get; set; }
        public int SchoolId { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }

        public virtual SchoolResponse SchoolResponse { get; set; }
        
    }
}