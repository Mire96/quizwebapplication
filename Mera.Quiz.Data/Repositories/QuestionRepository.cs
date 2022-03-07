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
    public class QuestionRepository : IQuestionRepository
    {
        private readonly AppDbContext _context;

        public QuestionRepository(AppDbContext context)
        {
            _context = context;
        }

        

        public async Task<Question> CreateQuestionAsync(Question newQuestionEntity)
        {
            _context.Add(newQuestionEntity);
            await _context.SaveChangesAsync();
            return newQuestionEntity;
        }

        public async Task<List<Question>> GetAllQuestionsAsync()
        {
            //Include - includes foreign key objects
            var entityQuestions = await _context.Questions
                                                .Include(a => a.AnswerList)
                                                .ToListAsync();
            return entityQuestions;
        }

        public async Task<Question> GetQuestionAsync(int id)
        {
            var entityQuestion = await _context.Questions.FindAsync(id);
            _context.Entry(entityQuestion).Collection(a => a.AnswerList).Load();
            return entityQuestion;
        }
    }
}
