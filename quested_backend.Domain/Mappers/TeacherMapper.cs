using quested_backend.Domain.Entities;
using quested_backend.Domain.Mappers.Interfaces;
using quested_backend.Domain.Requests.Teacher;
using quested_backend.Domain.Responses;

namespace quested_backend.Domain.Mappers
{
    public class TeacherMapper : ITeacherMapper
    {
        private readonly ISchoolMapper _schoolMapper;
        
        public TeacherMapper(ISchoolMapper schoolMapper)
        {
            _schoolMapper = schoolMapper;
        }

        public Teacher Map(AddTeacherRequest request)
        {
            if (request == null) return null;

            var teacher = new Teacher
            {
                Firstname = request.Firstname,
                Lastname = request.Lastname,
                SchoolId = request.SchoolId,
            };

            return teacher;
        }

        public Teacher Map(EditTeacherRequest request)
        {
            if (request == null) return null;
            
            var teacher = new Teacher
            {
                Id = request.Id,
                Firstname = request.Firstname,
                Lastname = request.Lastname,
                SchoolId = request.SchoolId,
            };

            return teacher;
        }

        public TeacherResponse Map(Teacher teacher)
        {
            if (teacher == null) return null;
            
            var teacherResponse = new TeacherResponse
            {
                Id = teacher.Id,
                Firstname = teacher.Firstname,
                Lastname = teacher.Lastname,
                SchoolId = teacher.SchoolId,
                SchoolResponse = _schoolMapper.Map(teacher.School),
                
            };

            return teacherResponse;
        }
    }
}