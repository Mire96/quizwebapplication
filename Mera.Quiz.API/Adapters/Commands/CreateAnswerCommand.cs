using MediatR;
using Mera.Quiz.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mera.Quiz.API.Adapters.Commands
{
    public class CreateAnswerCommand : IRequest<AnswerModel>
    {
        public string AnswerText { get; set; }

        public CreateAnswerCommand(string answerText)
        {
            AnswerText = answerText;
        }
    }
}
