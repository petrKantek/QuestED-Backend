using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using quested_backend.Domain.Entities;
using quested_backend.Domain.Mappers.Interfaces;
using quested_backend.Domain.Repositories;
using quested_backend.Domain.Requests.Teacher;
using quested_backend.Domain.Responses;
using quested_backend.Domain.Services.Interfaces;

namespace quested_backend.Domain.Services
{
    public class TeacherService : ITeacherService
    {
        private readonly IRepository<Teacher> _teacherRepository;
        private readonly IRepository<Course> _courseRepository;
        private readonly ITeacherMapper _teacherMapper;

        public TeacherService(IRepository<Teacher> teacherRepository, IRepository<Course> courseRepository,
            ITeacherMapper teacherMapper)
        {
            _teacherRepository = teacherRepository;
            _courseRepository = courseRepository;
            _teacherMapper = teacherMapper;
        }
        
        public async Task<IEnumerable<TeacherResponse>> GetTeachersAsync()
        {
            var result = await _teacherRepository.GetAllAsync();
            return result.Select(x => _teacherMapper.Map(x));
        }

        public async Task<TeacherResponse> GetTeacherAsync(GetTeacherRequest request)
        {
            if (request == null) 
                throw new ArgumentNullException($"Entity is null");
            if (request.Id <= 0) 
                throw new ArgumentException($"Entity has an invalid ID: {request.Id} ");
            
            var result = await _teacherRepository.GetByIdAsync(request.Id);
            return _teacherMapper.Map(result);
        }

        public async Task<TeacherResponse> ReadOnlyGetTeacherAsync(GetTeacherRequest request)
        {
            if (request == null) 
                throw new ArgumentNullException($"Entity is null");
            if (request.Id <= 0) 
                throw new ArgumentException($"Entity has an invalid ID: {request.Id} ");
            
            var result = await _teacherRepository.ReadOnlyGetByIdAsync(request.Id);
            return _teacherMapper.Map(result);
        }

        public async Task<TeacherResponse> AddTeacherAsync(AddTeacherRequest request)
        {
            if (request == null) 
                throw new ArgumentNullException($"Entity is null");

            var teacher = _teacherMapper.Map(request);
            var result = _teacherRepository.Create(teacher);

            await _teacherRepository.UnitOfWork.SaveChangesAsync();
            return _teacherMapper.Map(result);
        }

        public async Task<TeacherResponse> EditTeacherAsync(EditTeacherRequest request)
        {
            var existingRecord = _teacherRepository.ReadOnlyGetByIdAsync(request.Id);
            if (existingRecord == null)
            {
                throw new ArgumentException($"Entity with {request.Id} is not present");
            }
            
            var entity = _teacherMapper.Map(request);
            var result = _teacherRepository.Update(entity);
            
            await _teacherRepository.UnitOfWork.SaveChangesAsync();
            return _teacherMapper.Map(result); 
        }

        public async Task GetPupilsScores(int courseId, int classId)
        {
           // var teacher = await _teacherRepository.ReadOnlyGetByIdAsync(teacherId);
           var course = await _courseRepository.ReadOnlyGetByIdAsync(courseId);
           var pupils = course.PupilInCourse;
        }

        public async Task ChangeScore(int pupilId)
        {
            throw new System.NotImplementedException();
        }

        public async Task AddPupilToClass(int pupilId, int classId)
        {
            throw new System.NotImplementedException();
        }
    }
}