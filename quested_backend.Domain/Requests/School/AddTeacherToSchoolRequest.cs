namespace quested_backend.Domain.Requests.School
{
    public class AddTeacherToSchoolRequest
    {
        public int SchoolId { get; set; }

        public int TeacherId { get; set; }
    }
}