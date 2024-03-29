﻿using Mera.Quiz.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mera.Quiz.Data.Interfaces
{
    public interface IAnswerRepository
    {
        Task<List<Answer>> GetAllAnswersAsync();
        Task<Answer> CreateAnswerAsync(Answer answer);
        Task<Answer> UpdateAnswerAsync(Answer answer);
        Task<Answer> GetAnswerAsync(int id);
        Task<bool> DeleteAnswerAsync(int id);
        Task<List<Answer>>GroupCreateAnswerAsync(List<Answer> answerList);
    }
}
