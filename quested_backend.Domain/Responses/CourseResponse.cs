namespace quested_backend.Domain.Responses
{
    public class CourseResponse
    {

        public int Id { get; set; }
        public string Name { get; set; }

        public int TeacherId { get; set; }

        public int SeasonId { get; set; }

    }
}