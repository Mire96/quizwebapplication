using MediatR;
using Mera.Quiz.Domain.Interfaces;
using Mera.Quiz.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Mera.Quiz.API.Adapters.Commands
{
    public class CreateAnswerCommandHandler : IRequestHandler<CreateAnswerCommand, AnswerModel>
    {
        private IAnswerService _answerService;

        public CreateAnswerCommandHandler(IAnswerService answerService)
        {
            _answerService = answerService;
        }

        public async Task<AnswerModel> Handle(CreateAnswerCommand request, CancellationToken cancellationToken)
        {
            return await _answerService.CreateAnswerAsync(request.AnswerText);
        }
    }
}
