using MediatR;
using Mera.Quiz.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mera.Quiz.API.Adapters.Commands
{
    public class UpdateAnswerCommand : IRequest<AnswerModel>
    {
        public int Id { get; set; }
        public string AnswerText { get; set; }

        public UpdateAnswerCommand(int id, string answerText)
        {
            Id = id;
            AnswerText = answerText;
        }
    }
}
