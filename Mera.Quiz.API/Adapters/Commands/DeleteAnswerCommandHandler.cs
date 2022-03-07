using MediatR;
using Mera.Quiz.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Mera.Quiz.API.Adapters.Commands
{
    public class DeleteAnswerCommandHandler : IRequestHandler<DeleteAnswerCommand, bool>
    {
        private IAnswerService _answerService;

        public DeleteAnswerCommandHandler(IAnswerService answerService)
        {
            _answerService = answerService;
        }

        public async Task<bool> Handle(DeleteAnswerCommand request, CancellationToken cancellationToken)
        {
            return await _answerService.DeleteAnswerAsync(request.Id);
        }
    }
}
