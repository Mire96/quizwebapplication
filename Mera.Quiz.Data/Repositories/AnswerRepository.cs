using Mera.Quiz.Data.Database;
using Mera.Quiz.Data.Entities;
using Mera.Quiz.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mera.Quiz.Data.Repositories
{
    public class AnswerRepository : IAnswerRepository
    {
        private readonly AppDbContext _context;

        public AnswerRepository(AppDbContext context)
        {
            _context = context;
        }



        public Task<Answer> CreateAnswerAsync(Answer answer)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteAnswerAsync(Answer answer)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Answer>> GetAllAnswersAsync()
        {
            var entityAnswers = _context.Answers.ToList();
            return entityAnswers;
        }

        public Task<Answer> UpdateAnswerAsync(Answer answer)
        {
            throw new NotImplementedException();
        }
    }
}
