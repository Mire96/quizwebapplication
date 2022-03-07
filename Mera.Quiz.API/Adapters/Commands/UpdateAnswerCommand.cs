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
        public AnswerModel answerModel { get; set; }

        public UpdateAnswerCommand(AnswerModel answerModel)
        {
            this.answerModel = answerModel;
        }
    }
}
