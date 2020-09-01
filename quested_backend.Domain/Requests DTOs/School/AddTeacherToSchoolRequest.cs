namespace quested_backend.Domain.Requests_DTOs.School
{
    public class AddTeacherToSchoolRequest
    {
        public int SchoolId { get; set; }

        public int TeacherId { get; set; }
    }
}