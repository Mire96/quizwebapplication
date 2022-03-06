using MediatR;
using Mera.Quiz.Domain.Interfaces;
using Mera.Quiz.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Mera.Quiz.API.Adapters.Queries
{
    public class GetAllAnswersQueryHandler : IRequestHandler<GetAllAnswersQuery, List<AnswerModel>>
    {

        private IAnswerService _answerService;

        public GetAllAnswersQueryHandler(IAnswerService answerService)
        {
            _answerService = answerService;
        }

        public async Task<List<AnswerModel>> Handle(GetAllAnswersQuery request, CancellationToken cancellationToken)
        {
            return await _answerService.GetAllAnswersAsync();
        }
    }
}
