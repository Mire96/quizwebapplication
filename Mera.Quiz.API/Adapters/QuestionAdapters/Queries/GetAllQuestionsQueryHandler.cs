using MediatR;
using Mera.Quiz.Domain.Interfaces;
using Mera.Quiz.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Mera.Quiz.API.Adapters.QuestionAdapters.Queries
{
    public class GetAllQuestionsQueryHandler : IRequestHandler<GetAllQuestionsQuery, List<QuestionModel>>
    {
        private IQuestionService _questionService;

        public GetAllQuestionsQueryHandler(IQuestionService questionService)
        {
            _questionService = questionService;
        }

        public async Task<List<QuestionModel>> Handle(GetAllQuestionsQuery request, CancellationToken cancellationToken)
        {
            return await _questionService.GetAllQuestionsAsync();
        }
    }
}
