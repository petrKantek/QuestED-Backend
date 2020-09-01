using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using quested_backend.Domain.Entities;
using quested_backend.Domain.Mappers.Interfaces;
using quested_backend.Domain.Repositories;
using quested_backend.Domain.Requests_DTOs.Pupil;
using quested_backend.Domain.Requests_DTOs.Teacher;
using quested_backend.Domain.Responses_DTOs;
using quested_backend.Domain.Services.Interfaces;

namespace quested_backend.Domain.Services
{
    public class TeacherService : ITeacherService
    {
        private readonly ITeacherRepository _teacherRepository;
        private readonly IPupilRepository _pupilRepository;
        private readonly IQuestionRepository _questionRepository;
        private readonly ITeacherMapper _teacherMapper;

        public TeacherService(ITeacherRepository teacherRepository, IPupilRepository pupilRepository,
            IQuestionRepository questionRepository, ITeacherMapper teacherMapper)
        {
            _teacherRepository = teacherRepository;
            _pupilRepository = pupilRepository;
            _questionRepository = questionRepository;
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
            
            var result = await _teacherRepository.GetByIdAsync(request.Id);
            return _teacherMapper.Map(result);
        }

        public async Task<TeacherResponse> ReadOnlyGetTeacherAsync(GetTeacherRequest request)
        {
            if (request == null) 
                throw new ArgumentNullException($"Entity is null");

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
            var editedTeacher = await _teacherRepository.ReadOnlyGetByIdAsync(result.Id);
            return _teacherMapper.Map(editedTeacher); 
        }

        public async Task<int> GetPupilScore(GetPupilScoreRequest request)
        {
            if (request == null)  
                throw new ArgumentNullException();
            
            var primaryKey = new[]
            {
                request.CourseId, request.PupilId, request.QuestionId, 
                request.EpisodeId, request.SeasonId
            };

            var score = await _teacherRepository.GetAnswerByPrimaryKey(primaryKey);

            return score.AchievedPoints;
        }
        
        public async Task EditScore(EditScoreRequest request) 
        {
            if (request == null) 
                throw new ArgumentNullException();

            var answers = await _questionRepository
                .GetAnswerByPrimaryKey(request.QuestionId, request.EpisodeId, request.SeasonId);

            var answer = answers.FirstOrDefault(x => 
                        x.PupilInCourseCourseId == request.CourseId &&
                        x.PupilInCoursePupilId == request.PupilId);

            if (answer == null)
            {
                throw new ArgumentException($"Pupil with id {request.PupilId} in course with id " +
                                            $"{request.CourseId} did not answer question with id {request.QuestionId}");
            }

            answer.AchievedPoints = request.NewScore;
            await _questionRepository.UnitOfWork.SaveChangesAsync();
        }

        public async Task<TeacherResponse> DeleteTeacherById(int teacherId)
        {
            var existingRecord = await _teacherRepository.DeleteById(teacherId);
            await _questionRepository.UnitOfWork.SaveChangesAsync();
            return _teacherMapper.Map(existingRecord);
        }
    }
}