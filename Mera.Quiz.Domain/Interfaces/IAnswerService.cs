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

        Task<AnswerModel> CreateAnswerAsync(AnswerModel answer);

        Task<AnswerModel> UpdateAnswerAsync(AnswerModel answer);

        Task<bool> DeleteAnswerAsync(AnswerModel answer);
    }
}
