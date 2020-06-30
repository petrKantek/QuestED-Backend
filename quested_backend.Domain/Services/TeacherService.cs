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
        private readonly ITeacherRepository _teacherRepository;
        private readonly IPupilRepository _pupilRepository;
        private readonly ITeacherMapper _teacherMapper;

        public TeacherService(ITeacherRepository teacherRepository, IPupilRepository pupilRepository,
            ITeacherMapper teacherMapper)
        {
            _teacherRepository = teacherRepository;
            _pupilRepository = pupilRepository;
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
           // var course = await _courseRepository.ReadOnlyGetByIdAsync(courseId);
           // var pupils = course.PupilInCourse;
        }

        public async Task EditScore(EditScoreRequest request) 
        {
            if (request == null) 
                throw new ArgumentNullException();
            
            var primaryKey = new int[]
            {
                request.CourseId, request.PupilId, request.QuestionId, 
                request.EpisodeId, request.SeasonId
            };

            var answer = 
                await _teacherRepository.GetAnswerByPrimaryKey(primaryKey);
            
            if (answer == null)
            {
                throw new ArgumentException($"Pupil with id {request.PupilId} in course with id " +
                                            $"{request.CourseId} did not answer question with id {request.QuestionId}");
            }
            answer.AchievedPoints = request.NewScore;
        }

        public async Task AddPupilToClass(AddPupilToClassRequest request)
        {
            var teacher = await _teacherRepository.GetByIdAsync(request.TeacherId);
            
            if (teacher == null)
                throw new ArgumentNullException();

            var pupil = await _pupilRepository.GetByIdAsync(request.PupilId);
            
            if (pupil == null)
                throw new ArgumentNullException();
            
            var _class = teacher.Class.FirstOrDefault(x => x.Id == request.ClassId);
            
            if (_class == null)
                throw new ArgumentNullException();
            
            _class.PupilInClass.Add(new PupilInClass
            {
                ClassId = request.ClassId,
                PupilId = request.PupilId
            });

            await _pupilRepository.UnitOfWork.SaveEntitiesAsync();
        }
        
    }
}