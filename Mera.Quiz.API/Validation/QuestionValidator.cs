using FluentValidation;
using Mera.Quiz.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mera.Quiz.API.Validation
{
    public class QuestionValidator : AbstractValidator<QuestionModel>
    {
        public QuestionValidator()
        {
            RuleFor(question => question.QuestionText).NotEmpty();
            RuleForEach(answers => answers.AnswerList).SetValidator(new AnswerValidator());
            RuleFor(question => question.AnswerList.Count > 1);
            //Ensures at least 1 answer is correct
            RuleFor(question => question.AnswerList)
                .Must(answers => answers.Any(answer => answer.isCorrect));
        }
    }
}
