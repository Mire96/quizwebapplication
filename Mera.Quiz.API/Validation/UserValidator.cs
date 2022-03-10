using FluentValidation;
using Mera.Quiz.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mera.Quiz.API.Validation
{
    public class UserValidator : AbstractValidator<UserModel>
    {
        public UserValidator()
        {
            RuleFor(username => username.UserName).NotEmpty();
            RuleFor(password => password.Password).NotEmpty();
        }
    }
}
