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
    public class UpdateQuestionAnswersCommandHandler : IRequestHandler<UpdateQuestionAnswersCommand, QuestionModel>
    {
        public IQuestionService _questionService { get; set; }

        public UpdateQuestionAnswersCommandHandler(IQuestionService questionService)
        {
            _questionService = questionService;
        }

        public async Task<QuestionModel> Handle(UpdateQuestionAnswersCommand request, CancellationToken cancellationToken)
        {
            return await _questionService.UpdateQuestionAnswersAsync(request.questionModel);
        }
    }
}
