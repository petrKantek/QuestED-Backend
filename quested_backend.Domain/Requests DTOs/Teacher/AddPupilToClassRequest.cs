namespace quested_backend.Domain.Requests_DTOs.Teacher
{
    public class AddPupilToClassRequest
    {
        public int TeacherId { get; set; }
        
        public int PupilId { get; set; }

        public int ClassId { get; set; }
    }
}