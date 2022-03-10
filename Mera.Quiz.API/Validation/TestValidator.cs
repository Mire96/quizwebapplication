using FluentValidation;
using Mera.Quiz.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mera.Quiz.API.Validation
{
    public class TestValidator : AbstractValidator<TestModel>
    {
        public TestValidator()
        {
            RuleFor(x => x.QuestionList.Count > 1);
            RuleForEach(question => question.QuestionList).SetValidator(new QuestionValidator());
            RuleFor(test => test.TestName).NotEmpty();

        }
    }
}
