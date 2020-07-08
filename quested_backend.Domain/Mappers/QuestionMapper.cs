using System.Linq;
using quested_backend.Domain.Entities;
using quested_backend.Domain.Mappers.Interfaces;
using quested_backend.Domain.Requests_DTOs.Question;
using quested_backend.Domain.Responses_DTOs;

namespace quested_backend.Domain.Mappers
{
    public class QuestionMapper : IQuestionMapper
    {
        public Question Map(AddQuestionRequest request)
        {
            throw new System.NotImplementedException();
        }

        public Question Map(EditQuestionRequest request)
        {
            throw new System.NotImplementedException();
        }

        public QuestionResponse Map(Question question)
        {
            if (question == null) return null;
            
            var questionResponse = new QuestionResponse
            {
                Id = question.Id,
                MaxPoints = question.MaxPoints,
                Season = question.Episode?.Season?.Name,
                Episode = question.Episode?.Name,
                Answers = question.PupilInCourseAnswersQuestion.Select(HelperMapper.BasicMap)
            };

            return questionResponse;
        }
    }
}