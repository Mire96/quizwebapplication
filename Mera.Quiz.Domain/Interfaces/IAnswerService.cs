using Mera.Quiz.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mera.Quiz.Domain.Interfaces
{
    public interface IAnswerService
    {
        Task<List<AnswerModel>> GetAllAnswersAsync();
        Task<AnswerModel> GetAnswerAsync(int id);
        Task<AnswerModel> CreateAnswerAsync(string answer);
        Task<AnswerModel> UpdateAnswerAsync(int id, string answerText);
        Task<bool> DeleteAnswerAsync(int id);
    }
}
