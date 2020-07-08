using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using quested_backend.Domain.Mappers.Interfaces;
using quested_backend.Domain.Repositories;
using quested_backend.Domain.Requests_DTOs.Course;
using quested_backend.Domain.Responses_DTOs;
using quested_backend.Domain.Services.Interfaces;

namespace quested_backend.Domain.Services
{
    using Marks = Task<Dictionary<int, List<int>>>;
    using AvgMark = Task<Dictionary<int, double>>;
    
    public class CourseService : ICourseService
    {
        private readonly ICourseRepository _courseRepository;
        private readonly ICourseMapper _courseMapper;

        public CourseService(ICourseRepository courseRepository, ICourseMapper courseMapper)
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
                throw new ArgumentNullException($"Request is null");

            var result = await _courseRepository.GetByIdAsync(request.Id);
            return _courseMapper.Map(result);
        }

        public async Task<CourseResponse> ReadOnlyGetCourseAsync(GetCourseRequest request)
        {
            if (request == null) 
                throw new ArgumentNullException($"Request is null");

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
                throw new ArgumentException($"Course with ID {request.Id} does not exist in the database");
            }
            
            var editedCourse = _courseMapper.Map(request);
            var result = _courseRepository.Update(editedCourse);

            await _courseRepository.UnitOfWork.SaveChangesAsync();
            return _courseMapper.Map(await _courseRepository.ReadOnlyGetByIdAsync(result.Id));
        }

        public async Task<CourseResponse> DeleteCourseById(int courseId)
        {
            var existingRecord = await _courseRepository.DeleteById(courseId);
            await _courseRepository.UnitOfWork.SaveChangesAsync();

            return _courseMapper.Map(existingRecord);
        }

        public async Marks GetScoresOfAllPupils(int courseId)
        {
            var course = await _courseRepository.GetByIdAsync(courseId);

            var scores = course.PupilInCourse
                .ToDictionary( pupil => pupil.PupilId, pupil =>
                    pupil.PupilInCourseAnswersQuestion
                        .Select(pupilAnswer => pupilAnswer.AchievedPoints).ToList());

            return scores;
        }

        public async AvgMark GetAvgScoreOfPupils(int courseId)
        {
            var marks = await GetScoresOfAllPupils(courseId);

            return marks
                .ToDictionary(pupil => 
                    pupil.Key, pupil => pupil.Value.Average());
        }
    }
}