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

        public async Task<QuestionModel> CreateQuestionAsync(string questionText, List<AnswerModel> answerList, AnswerModel correctAnswer)
        {
            //Mapping QuestionModel -> Question
            QuestionModel newQuestionModel = new QuestionModel(questionText, answerList, correctAnswer);
            var newQuestionEntity = _mapper.Map<QuestionModel, Question>(newQuestionModel);

            //Adding answers to database first to avoid circularity
            var createdAnswerEntities = await _answerRepository.GroupCreateAnswerAsync(newQuestionEntity.AnswerList);
            Answer updatedAnswerEntity = null;

            //Checking if the answer list has the created answer already
            

            //If not then we add it to the database 
            

            //Adding the answers to the question entity to be created
            newQuestionEntity.AnswerList = createdAnswerEntities;
            

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
