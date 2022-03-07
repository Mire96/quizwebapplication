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
    public class AnswerService : IAnswerService
    {

        private readonly IAnswerRepository _answerRepository;
        private readonly IMapper _mapper;

        public AnswerService(IAnswerRepository answerRepository, IMapper mapper)
        {
            _answerRepository = answerRepository;
            _mapper = mapper;
        }

        


        public async Task<List<AnswerModel>> GetAllAnswersAsync()
        {
            var answerEntities = await _answerRepository.GetAllAnswersAsync();
            var answerModels = _mapper.Map<List<Answer>,List<AnswerModel>>(answerEntities);
            //var answerModels = _mapper.Map(answerEntities, typeof(List<AnswerModel>));
            return answerModels;
        }

        public async Task<AnswerModel> GetAnswerAsync(int id)
        {
            var answerEntity = await _answerRepository.GetAnswerAsync(id);
            var answerModel = _mapper.Map<Answer,AnswerModel> (answerEntity);
            return answerModel;
        }

        public async Task<AnswerModel> CreateAnswerAsync(string answer)
        {
            AnswerModel newAnswerModel = new AnswerModel(answer);
            Answer newAnswerEntity = _mapper.Map<AnswerModel, Answer>(newAnswerModel);

            var createdAnswerEntity = await _answerRepository.CreateAnswerAsync(newAnswerEntity);
            var createdAnswerModel = _mapper.Map<Answer, AnswerModel>(createdAnswerEntity);

            return createdAnswerModel;
        }

        public async Task<AnswerModel> UpdateAnswerAsync(int id, string answerText)
        {
            AnswerModel newAnswerModel = new AnswerModel(id, answerText);
            Answer newAnswerEntity = _mapper.Map<AnswerModel, Answer>(newAnswerModel);

            var updatedAnswerEntity = await _answerRepository.UpdateAnswerAsync(newAnswerEntity);
            var updatedAnswerModel = _mapper.Map<Answer, AnswerModel>(updatedAnswerEntity);

            return updatedAnswerModel;
        }

        public async Task<bool> DeleteAnswerAsync(int id)
        {
            bool deleteAnswerSuccessful = await _answerRepository.DeleteAnswerAsync(id);
            return deleteAnswerSuccessful;
        }
    }
}
