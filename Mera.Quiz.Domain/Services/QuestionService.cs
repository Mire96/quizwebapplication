using AutoMapper;
using Mera.Quiz.Data.Entities;
using Mera.Quiz.Data.Interfaces;
using Mera.Quiz.Domain.Interfaces;
using Mera.Quiz.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mera.Quiz.Domain.Services
{
    public class QuestionService : IQuestionService
    {
        private readonly IQuestionRepository _questionRepository;
        private readonly IAnswerRepository _answerRepository;
        private readonly IMapper _mapper;

        public QuestionService(IQuestionRepository questionRepository, IMapper mapper, IAnswerRepository answerRepository)
        {
            _questionRepository = questionRepository;
            _mapper = mapper;
            _answerRepository = answerRepository;
        }

        #region Queries

        public async Task<List<QuestionModel>> GetAllQuestionsAsync()
        {
            var questionEntities = await _questionRepository.GetAllQuestionsAsync();
            var questionModels = _mapper.Map<List<Question>, List<QuestionModel>>(questionEntities);

            return questionModels;
        }

        public async Task<QuestionModel> GetQuestionAsync(int id)
        {
            var questionEntity = await _questionRepository.GetQuestionAsync(id);
            var questionModel = _mapper.Map<Question, QuestionModel>(questionEntity);

            return questionModel;
        }

        #endregion

        public async Task<QuestionModel> CreateQuestionAsync(QuestionModel questionModel)
        {

            QuestionModel newQuestionModel = questionModel;
            var newQuestionEntity = _mapper.Map<QuestionModel, Question>(newQuestionModel);

            var createdQuestionEntity = await _questionRepository.CreateQuestionAsync(newQuestionEntity);
            var createdQuestionModel = _mapper.Map<Question, QuestionModel>(createdQuestionEntity);

            return createdQuestionModel;
        }

        public async Task<QuestionModel> UpdateQuestionAnswersAsync(QuestionModel questionModel)
        {
            if(NoCorrectAnswers(questionModel.AnswerList))
            {
                return null;
            }

            var newQuestionEntity = _mapper.Map<QuestionModel, Question>(questionModel);

            var updatedQuestionEntity = await _questionRepository.UpdateQuestionAnswersAsync(newQuestionEntity);
            var updatedQuestionModel = _mapper.Map<Question, QuestionModel>(updatedQuestionEntity);

            return updatedQuestionModel;
        }

        private bool NoCorrectAnswers(List<AnswerModel> answerList)
        {
            foreach (AnswerModel answer in answerList)
            {
                if (answer.isCorrect)
                {
                    return false;
                }
            }
            return true;
        }

        public async Task<QuestionModel> UpdateQuestionTextAsync(QuestionModel questionModel)
        {
            
            var newQuestionEntity = _mapper.Map<QuestionModel, Question>(questionModel);

            var updatedQuestionEntity = await _questionRepository.UpdateQuestionTextAsync(newQuestionEntity);
            var updatedQuestionModel = _mapper.Map<Question, QuestionModel>(updatedQuestionEntity);

            return updatedQuestionModel;
        }

        public async Task<bool> DeleteQuestionAsync(int id)
        {

            bool deleteQuestionSuccessful = await _questionRepository.DeleteQuestionAsync(id);
            return deleteQuestionSuccessful;
        }
    }
}
