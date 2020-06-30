using quested_backend.Domain.Entities;
using quested_backend.Domain.Repositories;

namespace quested_backend.Infrastructure.Repositories
{
    public class QuestionRepository : EntityFrameworkRepository<Question>, IQuestionRepository
    {
        public QuestionRepository(QuestedContext context) : base(context)
            { }
    }
}