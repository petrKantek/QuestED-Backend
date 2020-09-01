using System.Collections.Generic;
using quested_backend.Domain.Responses_DTOs.AdditionalInfoResponses;

namespace quested_backend.Domain.Responses_DTOs
{
    public class QuestionResponse
    {
        public int? Id { get; set; }

        public int? MaxPoints { get; set; }
        
        public string Season { get; set; }
        
        public string Episode { get; set; }
        
        public IEnumerable<AnswerBasicInfo> Answers { get; set; }
    }
}