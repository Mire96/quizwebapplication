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
    public class UpdateAnswerCommandHandler : IRequestHandler<UpdateAnswerCommand, AnswerModel>
    {
        private IAnswerService _answerService;

        public UpdateAnswerCommandHandler(IAnswerService answerService)
        {
            _answerService = answerService;
        }

        public async Task<AnswerModel> Handle(UpdateAnswerCommand request, CancellationToken cancellationToken)
        {
            return await _answerService.UpdateAnswerAsync(request.Id, request.AnswerText);
        }
    }
}
