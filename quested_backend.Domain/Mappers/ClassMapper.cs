using System.Linq;
using quested_backend.Domain.Entities;
using quested_backend.Domain.Mappers.Interfaces;
using quested_backend.Domain.Requests_DTOs.Class;
using quested_backend.Domain.Responses_DTOs;
using quested_backend.Domain.Responses_DTOs.AdditionalInfoResponses;

namespace quested_backend.Domain.Mappers
{
    public class ClassMapper : IClassMapper
    {
        public Class Map(AddClassRequest request)
        {
            if (request == null) return null;

            var _class = new Class
            { 
                Name = request.Name,
                TeacherId = request.TeacherId
            };

            return _class;
        }

        public Class Map(EditClassRequest request)
        {
            if (request == null) return null;

            var _class = new Class
            {
                Id = request.Id,
                Name = request.Name,
                TeacherId = request.TeacherId,
            };

            return _class;
        }

        public ClassResponse Map(Class _class)
        {
            if (_class == null) return null;
            
            var classResponse = new ClassResponse
            {
                Id = _class.Id,
                Name = _class.Name,
                TaughtBy = new TeacherBasicInfo
                {
                    Id = _class.Teacher?.Id,
                    Firstname = _class.Teacher?.Firstname,
                    Lastname = _class.Teacher?.Lastname
                },
                PupilInClass = _class.PupilInClass.Select(x => new PupilBasicInfo
                {
                    Id = x.Pupil?.Id,
                    Firstname = x.Pupil?.Firstname
                })
            };

            return classResponse;
        }

        public ClassBasicInfo MapAdditionalInfo(Class _class)
        {
            if (_class == null) return null;
            
            var classResponse = new ClassBasicInfo()
            {
                Id = _class.Id,
                Name = _class.Name,
            };

            return classResponse;
        }
    }
}