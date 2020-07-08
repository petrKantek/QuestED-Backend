using System.Linq;
using quested_backend.Domain.Entities;
using quested_backend.Domain.Mappers.Interfaces;
using quested_backend.Domain.Requests_DTOs.Pupil;
using quested_backend.Domain.Responses_DTOs;
using quested_backend.Domain.Responses_DTOs.AdditionalInfoResponses;

namespace quested_backend.Domain.Mappers
{
    public class PupilMapper : IPupilMapper
    {
        public Pupil Map(AddPupilRequest request)
        {
            if (request == null) return null;

            var pupil = new Pupil
            {
                Firstname = request.Firstname,
            };

            return pupil;
        }

        public Pupil Map(EditPupilRequest request)
        {
            if (request == null) return null;

            var pupil = new Pupil
            {
                Id = request.Id,
                Firstname = request.Firstname
            };

            return pupil;
        }

        public PupilResponse Map(Pupil pupil)
        {
            if (pupil == null) return null;

            var pupilResponse = new PupilResponse
            {
                Id = pupil.Id,
                Firstname = pupil.Firstname,
                EnrolledInClasses = pupil.PupilInClass
                    .Select(x => new ClassBasicInfo
                    {
                        Id = x.Class?.Id,
                        Name = x.Class?.Name
                    }).ToList(),
                EnrolledInCourses = pupil.PupilInCourse
                    .Select(x => new CourseBasicInfo
                    {
                        Id = x.Course?.Id,
                        Name = x.Course?.Name
                    })
            };

            return pupilResponse;
        }

        public PupilBasicInfo MapAdditionalInfo(Pupil pupil)
        {
            if (pupil == null) return null;

            var pupilResponse = new PupilBasicInfo()
            {
                Id = pupil.Id,
                Firstname = pupil.Firstname
            };

            return pupilResponse;
        }
    }
}