using System;
using quested_backend.Domain.Requests_DTOs.Teacher;
using quested_backend.Domain.Services;
using quested_backend.Domain.Services.Interfaces;
using quested_backend.Fixtures;
using quested_backend.Infrastructure.Repositories;
using Shouldly;
using Xunit;

namespace Domain.Tests.Services.Teacher
{
    public class TeacherServiceRelationshipsTests : IClassFixture<QuestedContextFactory>
    {
        private readonly TestQuestedContext _context;
        private readonly ITeacherService _teacherService;

        public TeacherServiceRelationshipsTests(QuestedContextFactory questedContextFactory)
        {
            _context = questedContextFactory.ContextInstance;
            var teacherRepository = new TeacherRepository(_context);
            var pupilRepository = new PupilRepository(_context);
            var questionRepository = new QuestionRepository(_context);
            _teacherService = new TeacherService(teacherRepository, pupilRepository, questionRepository, 
                questedContextFactory.TeacherMapper);
        }

        [Fact]
        public void editScore_should_correctly_edit_score_of_pupil()
        {
            var editScoreRequest = new EditScoreRequest
            {
                CourseId = 1,
                SeasonId = 1,
                EpisodeId = 1,
                NewScore = 2,
                PupilId = 1,
                QuestionId = 1
            };

            _teacherService.EditScore(editScoreRequest);
            
            var answer = _context.PupilInCourseAnswersQuestion
                .Find(editScoreRequest.CourseId, editScoreRequest.PupilId, 
                    editScoreRequest.QuestionId, editScoreRequest.EpisodeId, editScoreRequest.SeasonId);
            
            answer.AchievedPoints.ShouldBe(editScoreRequest.NewScore);
        }

        [Fact]
        public void editScore_should_throw_argument_null_exception_when_null_request()
        {
            _teacherService.EditScore(null).ShouldThrow<ArgumentNullException>();
        }

        [Fact]
        public void editScore_should_throw_argument_exception_when_invalid_request()
        {
            var editScoreRequest = new EditScoreRequest
            {
                CourseId = 10,
                SeasonId = 1,
                EpisodeId = 1,
                NewScore = 2,
                PupilId = 1,
                QuestionId = 1
            };

            _teacherService.EditScore(editScoreRequest).ShouldThrow<ArgumentException>();
        }
    }
}