using MediatR;
using Mera.Quiz.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Mera.Quiz.API.Adapters.QuestionAdapters.Commands
{
    public class DeleteQuestionCommandHandler : IRequestHandler<DeleteQuestionCommand, bool>
    {
        public IQuestionService _questionService { get; set; }

        public DeleteQuestionCommandHandler(IQuestionService questionService)
        {
            _questionService = questionService;
        }

        public async Task<bool> Handle(DeleteQuestionCommand request, CancellationToken cancellationToken)
        {
            return await _questionService.DeleteQuestionAsync(request.Id);
        }
    }
}
