using FluentValidation;
using Mera.Quiz.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mera.Quiz.API.Validation
{
    public class UpdateTestValidator : AbstractValidator<TestModel>
    {

        public UpdateTestValidator()
        {
            RuleFor(test => test.ID).NotEmpty();
            RuleFor(x => x.QuestionList.Count).GreaterThan(1);
            RuleForEach(question => question.QuestionList).SetValidator(new QuestionValidator());
            RuleFor(test => test.TestName).NotEmpty().MaximumLength(19);
        }
    }
}
