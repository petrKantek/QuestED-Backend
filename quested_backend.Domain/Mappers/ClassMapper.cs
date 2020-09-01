using System.Linq;
using quested_backend.Domain.Entities;
using quested_backend.Domain.Mappers.Interfaces;
using quested_backend.Domain.Requests_DTOs.Class;
using quested_backend.Domain.Responses_DTOs;

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
                TaughtBy = HelperMapper.BasicMap(_class.Teacher),
                PupilInClass = _class.PupilInClass
                    .Select(x => HelperMapper.BasicMap(x.Pupil))
            };

            return classResponse;
        }
    }
}