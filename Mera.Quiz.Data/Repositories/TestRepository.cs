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
    public class TestRepository : ITestRepository
    {
        private readonly AppDbContext _context;

        public TestRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Test> CreateTestAsync(Test newTestEntity)
        {
            _context.Add(newTestEntity);
            await _context.SaveChangesAsync();
            return newTestEntity;
        }

        public async Task<TestScore> CreateTestScoreAsync(TestScore newTestScoreEntity)
        {
            var partialTestScoreEntity = new TestScore()
            {
                Score = newTestScoreEntity.Score,
                UserNameFK = newTestScoreEntity.User.ID,
                DateTaken = newTestScoreEntity.DateTaken,
                TestNameFK = newTestScoreEntity.Test.ID,
                UserAnswers = new List<UserAnswers> ()
            };
            foreach (var userAnswer in newTestScoreEntity.UserAnswers)
            {
                var newUserAnswer = new UserAnswers()
                {
                    QuestionFK = userAnswer.Question.ID,
                    ChosenAnswerFK = userAnswer.ChosenAnswer.ID,
                };
                partialTestScoreEntity.UserAnswers.Add(newUserAnswer);
            }
            
            _context.TestScores.Add(partialTestScoreEntity);
            await _context.SaveChangesAsync();
            return partialTestScoreEntity;
        }

        public async Task<bool> DeleteTestAsync(int testId)
        {
            var entityTest = await _context.Tests
                .Include(questions => questions.QuestionList)
                .ThenInclude(answers => answers.AnswerList)
                .FirstOrDefaultAsync(x => x.ID == testId);

            if(entityTest != null)
            {
                foreach(Question question in entityTest.QuestionList)
                {
                    _context.Answers.RemoveRange(question.AnswerList);
                    _context.Questions.Remove(question);
                }

                _context.Tests.Remove(entityTest);
            }

            var isDeleted = 0;

            try
            {
                isDeleted = await _context.SaveChangesAsync();
            }
            catch (Exception)
            {

                isDeleted = 0;
            }
            return isDeleted != 0;
        }

        public async Task<List<Test>> GetAllTestsAsync()
        {
            //Loads all tests, .Include loads all tests questions, .ThenInclude loads all questions answers
            var entityTests = await _context.Tests
                .Include(t => t.QuestionList)
                    .ThenInclude(q => q.AnswerList)
				.Include(t => t.QuestionList)
			        .ThenInclude(q => q.CorrectAnswer)
				.ToListAsync();
            return entityTests;
        }

		public async Task<List<TestScore>> GetAllTestScoresByUserAsync(int userId)
		{
            List<TestScore> testScoreEntities = await _context.TestScores
                .Include(testScore => testScore.Test)
                .Include(testScore => testScore.User)
                .Include(testScore => testScore.UserAnswers)
                    .ThenInclude(userAnswers => userAnswers.ChosenAnswer)
                .Include(testScore => testScore.UserAnswers)
                    .ThenInclude(userAnswers => userAnswers.Question)
					.ThenInclude(question => question.CorrectAnswer)
				.Where(testScore => testScore.UserNameFK.Equals(userId))
                .ToListAsync();
            return testScoreEntities;
		}

		public async Task<TestScore> GetTestScoreAsync(int testScoreId)
		{
            var testScoreEntity = await _context.TestScores
                .Include(testScore => testScore.UserAnswers)
                    .ThenInclude(userAnswers => userAnswers.ChosenAnswer)
                .Include(testScore => testScore.UserAnswers)
                    .ThenInclude(userAnswers => userAnswers.Question)
                    .ThenInclude(question => question.CorrectAnswer)
				.FirstOrDefaultAsync(x => x.ID == testScoreId);
            return testScoreEntity;

		}

        public async Task<TestScore> GetFullTestScoreAsync(int testScoreId)
        {
			var testScoreEntity = await _context.TestScores
                .Include(testScore => testScore.Test)
                .Include(testScore => testScore.User)
				.Include(testScore => testScore.UserAnswers)
					.ThenInclude(userAnswers => userAnswers.ChosenAnswer)
				.Include(testScore => testScore.UserAnswers)
					.ThenInclude(userAnswers => userAnswers.Question)
					.ThenInclude(question => question.CorrectAnswer)
				.FirstOrDefaultAsync(x => x.ID == testScoreId);
			return testScoreEntity;
		}

		public async Task<Test> UpdateTestAsync(Test newTestEntity)
        {
            var entityTest = await _context.Tests
                .Include(questions => questions.QuestionList)
                .ThenInclude(answers => answers.AnswerList)
                .FirstOrDefaultAsync(x => x.ID == newTestEntity.ID);

            //Finds and deletes all answers and questions that are not in the new test
            if(entityTest != null)
            {
                foreach( Question question in entityTest.QuestionList)
                {
                    if (!newTestEntity.QuestionList.Contains(question))
                    {
                        _context.Answers.RemoveRange(question.AnswerList);
                        _context.Questions.Remove(question);
                    }
                }

                entityTest.TestName = newTestEntity.TestName;
                entityTest.QuestionList = newTestEntity.QuestionList;
                await _context.SaveChangesAsync();
            }

            return entityTest;


        }
    }
}
