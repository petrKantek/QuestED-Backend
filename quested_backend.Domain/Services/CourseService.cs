using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using quested_backend.Domain.Entities;
using quested_backend.Domain.Mappers.Interfaces;
using quested_backend.Domain.Repositories;
using quested_backend.Domain.Requests.Course;
using quested_backend.Domain.Responses;
using quested_backend.Domain.Services.Interfaces;

namespace quested_backend.Domain.Services
{
    public class CourseService : ICourseService
    {
        private readonly IRepository< Course > _courseRepository;
        private readonly ICourseMapper _courseMapper;

        public CourseService(IRepository<Course> courseRepository, ICourseMapper courseMapper)
        {
            _courseRepository = courseRepository;
            _courseMapper = courseMapper;
        }
        
        public async Task<IEnumerable<CourseResponse>> GetCoursesAsync()
        {
            var result = await _courseRepository.GetAllAsync();
            return result.Select( x => _courseMapper.Map(x));
        }

        public async Task<CourseResponse> GetCourseAsync(GetCourseRequest request)
        {
            if (request == null) 
                throw new ArgumentNullException($"Entity is null");
            if (request.Id <= 0) 
                throw new ArgumentException($"Entity has an invalid ID: {request.Id} ");
            
            var result = await _courseRepository.GetByIdAsync(request.Id);
            return _courseMapper.Map(result);
        }

        public async Task<CourseResponse> ReadOnlyGetCourseAsync(GetCourseRequest request)
        {
            if (request == null) 
                throw new ArgumentNullException($"Entity is null");
            if (request.Id <= 0) 
                throw new ArgumentException($"Entity has an invalid ID: {request.Id} ");
            
            var result = await _courseRepository.ReadOnlyGetByIdAsync(request.Id);
            return _courseMapper.Map(result);
        }

        public async Task<CourseResponse> AddCourseAsync(AddCourseRequest request)
        {
            var newCourse = _courseMapper.Map(request);
            var result = _courseRepository.Create(newCourse);

            await _courseRepository.UnitOfWork.SaveChangesAsync();
            return _courseMapper.Map(result);
        }

        public async Task<CourseResponse> EditCourseAsync(EditCourseRequest request)
        {
            var existingRecord = _courseRepository.ReadOnlyGetByIdAsync(request.Id);
            if (existingRecord == null)
            {
                throw new ArgumentException($"Entity with {request.Id} is not present in the database");
            }
            
            var editedCourse = _courseMapper.Map(request);
            var result = _courseRepository.Update(editedCourse);

            await _courseRepository.UnitOfWork.SaveChangesAsync();
            return _courseMapper.Map(result);
        }
    }
}