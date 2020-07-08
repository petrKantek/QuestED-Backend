using quested_backend.Domain.Entities;
using quested_backend.Domain.Requests_DTOs.Question;
using quested_backend.Domain.Responses_DTOs;

namespace quested_backend.Domain.Mappers.Interfaces
{
    public interface IQuestionMapper
    {
        /// <summary>
        /// Maps add question request to question entity
        /// </summary>
        /// <param name="request"></param>
        /// <returns>pupil entity</returns>
        Question Map(AddQuestionRequest request);
        /// <summary>
        /// Maps edit question request to question entity
        /// </summary>
        /// <param name="request"></param>
        /// <returns>pupil entity</returns>
        Question Map(EditQuestionRequest request);
        /// <summary>
        /// Maps question entity to question response
        /// </summary>
        /// <param name="item"></param>
        /// <returns>pupil response</returns>
        QuestionResponse Map(Question item); 
    }
}