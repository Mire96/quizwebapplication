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
        Task<AnswerModel> CreateAnswerAsync(AnswerModel answerModel);
        Task<AnswerModel> UpdateAnswerAsync(AnswerModel answerModel);
        Task<bool> DeleteAnswerAsync(int id);
    }
}
