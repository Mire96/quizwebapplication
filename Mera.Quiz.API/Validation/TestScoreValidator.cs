using FluentValidation;
using Mera.Quiz.Data.Entities;
using Mera.Quiz.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mera.Quiz.API.Validation
{
    public class TestScoreValidator : AbstractValidator<TestScoreModel>
    {
        public TestScoreValidator()
        {
            //RuleFor(x => x.QuestionList.Count).GreaterThan(1);
            //RuleForEach(question => question.QuestionList).SetValidator(new QuestionValidator());
            //RuleFor(test => test.TestName).NotEmpty().MaximumLength(19);
            //RuleFor(test => test.UserName.ID).NotEmpty();
            //RuleFor(test => test.UserName).SetValidator(new UserValidator());
            RuleFor(x => x.Score).NotNull();
            RuleFor(x => x.User.ID).NotEmpty();
            RuleForEach(x => x.UserAnswers).SetValidator(new UserAnswersValidator());
            RuleFor(x => x.Test).NotEmpty();
            RuleFor(x => x.DateTaken).NotEmpty();
            RuleFor(x => x.DateTaken).GreaterThan(DateTime.MinValue);

        }
    }
}
