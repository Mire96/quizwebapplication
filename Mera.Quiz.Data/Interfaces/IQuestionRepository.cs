using Mera.Quiz.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mera.Quiz.Data.Interfaces
{
    public interface IQuestionRepository
    {
        Task<List<Question>> GetAllQuestionsAsync();
        Task<Question> GetQuestionAsync(int id);
        Task<Question> CreateQuestionAsync(Question newQuestionEntity);
        Task<Question> UpdateQuestionTextAsync(Question newQuestionEntity);
        Task<Question> UpdateQuestionAnswersAsync(Question newQuestionEntity);
        Task<bool> DeleteQuestionAsync(int id);
    }
}
