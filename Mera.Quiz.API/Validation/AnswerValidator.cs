using FluentValidation;
using Mera.Quiz.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mera.Quiz.API.Validation
{
    public class AnswerValidator : AbstractValidator<AnswerModel>
    {
        public AnswerValidator()
        {
            RuleFor(answer => answer.AnswerText).NotEmpty();
        }
    }
}
