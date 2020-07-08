using System.Linq;
using quested_backend.Domain.Entities;
using quested_backend.Domain.Mappers.Interfaces;
using quested_backend.Domain.Requests_DTOs.School;
using quested_backend.Domain.Responses_DTOs;
using quested_backend.Domain.Responses_DTOs.AdditionalInfoResponses;

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
                Id = request.Id,
                Name = request.Name,
                Country = request.Country,
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
                Country = school.Country,
                HasSeasons = school.SchoolOwnsSeason.Select(x => x.Season?.Name),
                HasTeachers = school.Teacher.Select(x => new TeacherBasicInfo
                {
                    Id = x.Id,
                    Firstname = x.Firstname,
                    Lastname = x.Lastname
                })
            };

            return schoolResponse;
        }

        public SchoolBasicInfo MapAdditionalInfo(School school)
        {
            if (school == null) return null;
            
            var schoolResponse = new SchoolBasicInfo()
            {
                Id = school.Id,
                Name = school.Name,
                Country = school.Country
            };

            return schoolResponse;
        }
    }
}