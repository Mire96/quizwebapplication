using MediatR;
using Mera.Quiz.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mera.Quiz.API.Adapters.QuestionAdapters.Commands
{
    public class UpdateQuestionTextCommand : IRequest<QuestionModel>
    {
        public QuestionModel questionModel { get; set; }

        public UpdateQuestionTextCommand(QuestionModel questionModel)
        {
            this.questionModel = questionModel;
        }
    }
}
