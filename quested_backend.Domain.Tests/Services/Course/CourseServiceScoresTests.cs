using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using quested_backend.Domain.Services;
using quested_backend.Domain.Services.Interfaces;
using quested_backend.Fixtures;
using quested_backend.Infrastructure.Repositories;
using Shouldly;
using Xunit;
using Xunit.Abstractions;

namespace Domain.Tests.Services.Course
{
    public class CourseServiceScoresTests : IClassFixture<QuestedContextFactory>
    {
        private readonly TestQuestedContext _context;
        private readonly ICourseService _courseService;
        private readonly ITestOutputHelper _testOutputHelper;

        public CourseServiceScoresTests(QuestedContextFactory questedContextFactory, ITestOutputHelper testOutputHelper)
        {
            _context = questedContextFactory.ContextInstance;
            var courseRepository = new CourseRepository(_context);
            _courseService = new CourseService(courseRepository, questedContextFactory.CourseMapper);
            _testOutputHelper = testOutputHelper;
        }

        [Fact]
        public async Task getScoresOfAllPupils_should_return_correct_data()
        {
            var scores = await _courseService.GetScoresOfAllPupils(1);

            foreach (var scs in scores
                .Select(pupil => pupil.Value
                .Aggregate( pupil.Key + ": ", (current, score) => current + (score + "|"))))
            {
                _testOutputHelper.WriteLine(scs);
            }
            
            var correctScores = new Dictionary<int, List<int>>
            {
                { 1, new List<int> {5, 10}},
                { 2, new List<int> {2, 0} },
                { 3, new List<int> {5, 10}}
            };
            
            scores.ShouldNotBeNull();
            scores.Keys.ShouldBe(correctScores.Keys);
            scores[1].ShouldBe(correctScores[1]);
            scores[2].ShouldBe(correctScores[2]);
            scores[3].ShouldBe(correctScores[3]);
        }

        [Fact]
        public async Task getAvgScoresOfAllPupils_should_return_correct_data()
        {
            var scores = await _courseService.GetAvgScoreOfPupils(1);

            foreach (var scs in scores)
            {
                _testOutputHelper.WriteLine($"{scs.Key}: {scs.Value}");
            }
            
            var correctScores = new Dictionary<int, double>
            {
                { 1, 7.5 },
                { 2, 1 },
                { 3, 7.5 }
            };
            
            scores.ShouldNotBeNull();
            scores.Keys.ShouldBe(correctScores.Keys);
            scores[1].ShouldBe(correctScores[1]);
            scores[2].ShouldBe(correctScores[2]);
            scores[3].ShouldBe(correctScores[3]);
        }
    }
}