using FluentValidation;
using Mera.Quiz.Domain.Models;

namespace Mera.Quiz.API.Validation
{
	public class UserAnswersValidator : AbstractValidator<UserAnswersModel>
	{
		public UserAnswersValidator()
		{
			RuleFor(x => x.Question).NotEmpty();
			RuleFor(x => x.ChosenAnswer).NotEmpty();
		}
	}
}
