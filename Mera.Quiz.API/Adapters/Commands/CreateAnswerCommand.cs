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
        public AnswerModel answerModel { get; set; }

        public CreateAnswerCommand(AnswerModel answerModel)
        {
            this.answerModel = answerModel;
        }
    }
}
