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

        public async Task<QuestionModel> CreateQuestionAsync(QuestionModel questionModel)
        {
            
            QuestionModel newQuestionModel = questionModel;
            var newQuestionEntity = _mapper.Map<QuestionModel, Question>(newQuestionModel);
              
            var createdQuestionEntity = await _questionRepository.CreateQuestionAsync(newQuestionEntity);
            var createdQuestionModel = _mapper.Map<Question, QuestionModel>(createdQuestionEntity);

            return createdQuestionModel;
        }

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
    }
}
