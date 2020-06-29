using quested_backend.Domain.Entities;
using quested_backend.Domain.Mappers.Interfaces;
using quested_backend.Domain.Requests.Class;
using quested_backend.Domain.Responses;

namespace quested_backend.Domain.Mappers
{
    public class ClassMapper : IClassMapper
    {
        private readonly ITeacherMapper _teacherMapper;
        
        public ClassMapper(ITeacherMapper teacherMapper)
        {
            _teacherMapper = teacherMapper;
        }

        public Class Map(AddClassRequest request)
        {
            if (request == null) return null;

            var _class = new Class
            { 
                Name = request.Name,
                TeacherId = request.TeacherId,
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
                TeacherId = _class.TeacherId,
                TeacherResponse = _teacherMapper.Map(_class.Teacher),
                PupilInClass = _class.PupilInClass
            };

            return classResponse;
        }
    }
}