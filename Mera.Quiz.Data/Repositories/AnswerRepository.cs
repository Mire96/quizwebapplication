using Mera.Quiz.Data.Database;
using Mera.Quiz.Data.Entities;
using Mera.Quiz.Data.Interfaces;
using Microsoft.EntityFrameworkCore;
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

        public async Task<List<Answer>> GetAllAnswersAsync()
        {
            var testanswers = await _context.Answers.ToListAsync();
            var entityAnswers = _context.Answers.ToList();
            return entityAnswers;
        }

        public async Task<Answer> GetAnswerAsync(int id)
        {
            var entityAnswer = await _context.Answers.FindAsync(id);
            return entityAnswer;
        }

        public async Task<Answer> CreateAnswerAsync(Answer answer)
        {
            _context.Add(answer);
            await _context.SaveChangesAsync();
            return answer;

        }

        public async Task<Answer> UpdateAnswerAsync(Answer answer)
        {
            var entityAnswer = _context.Answers.Find(answer.ID);
            entityAnswer.AnswerText = answer.AnswerText;
            entityAnswer.isCorrect = answer.isCorrect;
            await _context.SaveChangesAsync();
            return entityAnswer;
        }

        public async Task<bool> DeleteAnswerAsync(int id)
        {
            //var entityAnswer = _context.Answers.Find(id);
            //_context.Answers.Remove(entityAnswer);
            var entityAnswer = new Answer() { ID = id };
            _context.Entry(entityAnswer).State = Microsoft.EntityFrameworkCore.EntityState.Deleted;

            int isDeleted = await _context.SaveChangesAsync();
            return isDeleted != 0 ? true : false;
        }


        public async Task<List<Answer>> GroupCreateAnswerAsync(List<Answer> answerList)
        {
            await _context.AddRangeAsync(answerList);
            //_context.SaveChanges();
            return answerList;
        }
    }
}
