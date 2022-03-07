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
    public class GetQuestionQueryHandler : IRequestHandler<GetQuestionQuery, QuestionModel>
    {
        private IQuestionService _questionService;

        public GetQuestionQueryHandler(IQuestionService questionService)
        {
            _questionService = questionService;
        }

        public async Task<QuestionModel> Handle(GetQuestionQuery request, CancellationToken cancellationToken)
        {
            return await _questionService.GetQuestionAsync(request.Id);
        }
    }
}
