﻿using Mera.Quiz.Data.Database;
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


        #region Queries
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

        #endregion


        #region Create, Update, Delete
        public async Task<Question> CreateQuestionAsync(Question newQuestionEntity)
        {
            _context.Add(newQuestionEntity);
            await _context.SaveChangesAsync();
            return newQuestionEntity;
        }

        

        public async Task<Question> UpdateQuestionTextAsync(Question newQuestionEntity)
        {
            var updateQuestionEntity = await _context.Questions.FindAsync(newQuestionEntity.ID);

            if(updateQuestionEntity != null)
            {
                updateQuestionEntity.QuestionText = newQuestionEntity.QuestionText;
                await _context.SaveChangesAsync();
                
            }

            return updateQuestionEntity;


        }

        public async Task<Question> UpdateQuestionAnswersAsync(Question newQuestionEntity)
        {
            var updateQuestionEntity = await _context.Questions.FindAsync(newQuestionEntity.ID);
            _context.Entry(updateQuestionEntity).Collection(a => a.AnswerList).Load();


            if (updateQuestionEntity != null)
            {
                foreach (Answer answer in updateQuestionEntity.AnswerList)
                {
                    if (!newQuestionEntity.AnswerList.Contains(answer))
                    {
                        _context.Answers.Remove(answer);
                    }
                }

                updateQuestionEntity.AnswerList = newQuestionEntity.AnswerList;
                await _context.SaveChangesAsync();

            }

            return updateQuestionEntity;
        }


        #endregion
    }
}
