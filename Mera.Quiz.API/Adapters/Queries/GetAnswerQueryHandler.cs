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
    public class GetAnswerQueryHandler : IRequestHandler<GetAnswerQuery, AnswerModel>
    {
        private IAnswerService _answerService;

        public GetAnswerQueryHandler(IAnswerService answerService)
        {
            _answerService = answerService;
        }

        public async Task<AnswerModel> Handle(GetAnswerQuery request, CancellationToken cancellationToken)
        {
            return await _answerService.GetAnswerAsync(request.Id);
        }
    }
}
