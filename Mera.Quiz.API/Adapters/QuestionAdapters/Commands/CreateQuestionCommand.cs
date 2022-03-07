﻿using MediatR;
using Mera.Quiz.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mera.Quiz.API.Adapters.QuestionAdapters.Commands
{
    public class CreateQuestionCommand : IRequest<QuestionModel>
    {
        public QuestionModel questionModel { get; set; }

        public CreateQuestionCommand(QuestionModel questionModel)
        {
            this.questionModel = questionModel;
        }
    }
}
