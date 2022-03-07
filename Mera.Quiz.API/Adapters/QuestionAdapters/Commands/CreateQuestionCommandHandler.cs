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
    public class CreateQuestionCommandHandler : IRequestHandler<CreateQuestionCommand, QuestionModel>
    {
        private IQuestionService _questionService;

        public CreateQuestionCommandHandler(IQuestionService questionService)
        {
            _questionService = questionService;
        }

        public async Task<QuestionModel> Handle(CreateQuestionCommand request, CancellationToken cancellationToken)
        {
            return await _questionService.CreateQuestionAsync(request.QuestionText, request.AnswerList, request.CorrectAnswer);

        }
    }
}
