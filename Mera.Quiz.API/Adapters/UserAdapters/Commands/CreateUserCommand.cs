using MediatR;
using Mera.Quiz.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mera.Quiz.API.Adapters.UserAdapters.Commands
{
    public class CreateUserCommand : IRequest<UserModel>
    {
        public UserModel userModel { get; set; }

        public CreateUserCommand(UserModel userModel)
        {
            this.userModel = userModel;
        }
    }
}

