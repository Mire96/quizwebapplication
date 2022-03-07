using MediatR;
using Mera.Quiz.Domain.Interfaces;
using Mera.Quiz.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Mera.Quiz.API.Adapters.QuestionAdapters.Commands
{
    public class UpdateQuestionTextCommandHandler : IRequestHandler<UpdateQuestionTextCommand, QuestionModel>
    {
        private IQuestionService _questionService;

        public UpdateQuestionTextCommandHandler(IQuestionService questionService)
        {
            _questionService = questionService;
        }

        public async Task<QuestionModel> Handle(UpdateQuestionTextCommand request, CancellationToken cancellationToken)
        {
            return await _questionService.UpdateQuestionTextAsync(request.questionModel);
        }
    }
}
