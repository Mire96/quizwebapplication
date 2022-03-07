using Mera.Quiz.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mera.Quiz.Domain.Interfaces
{
    public interface IQuestionService
    {
        Task<List<QuestionModel>> GetAllQuestionsAsync();
        Task<QuestionModel> GetQuestionAsync(int id);
        Task<QuestionModel> CreateQuestionAsync(QuestionModel questionModel);
    }
}
