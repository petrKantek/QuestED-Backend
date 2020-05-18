using quested_backend.Domain.Entities;
using quested_backend.Domain.Mappers.Interfaces;
using quested_backend.Domain.Requests.School;
using quested_backend.Domain.Responses;

namespace quested_backend.Domain.Mappers
{
    public class SchoolMapper : ISchoolMapper
    {
        public School Map(AddSchoolRequest request)
        {
            if (request == null) return null;

            var school = new School
            {
                Name = request.Name,
                Country = request.Country
            };

            return school;
        }

        public School Map(EditSchoolRequest request)
        {
            if (request == null) return null;
            
            var school = new School
            {
                Name = request.Name,
                Country = request.Country
            };

            return school;
        }

        public SchoolResponse Map(School school)
        {
            if (school == null) return null;
            
            var schoolResponse = new SchoolResponse
            {
                Id = school.Id,
                Name = school.Name,
                Country = school.Country
            };

            return schoolResponse;
        }
    }
}