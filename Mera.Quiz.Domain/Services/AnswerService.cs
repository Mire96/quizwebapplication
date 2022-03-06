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

        public Task<AnswerModel> CreateAnswerAsync(AnswerModel answer)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteAnswerAsync(AnswerModel answer)
        {
            throw new NotImplementedException();
        }

        public async Task<List<AnswerModel>> GetAllAnswersAsync()
        {
            var answerEntities = await _answerRepository.GetAllAnswersAsync();
            var answerModels = _mapper.Map<List<Answer>,List<AnswerModel>>(answerEntities);
            //var answerModels = _mapper.Map(answerEntities, typeof(List<AnswerModel>));
            return answerModels;
        }

        public Task<AnswerModel> UpdateAnswerAsync(AnswerModel answer)
        {
            throw new NotImplementedException();
        }
    }
}
