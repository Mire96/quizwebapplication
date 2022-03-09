using MediatR;
using Mera.Quiz.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mera.Quiz.API.Adapters.UserAdapters.Queries
{
    public class GetUserQuery : IRequest<UserModel>
    {
        public UserModel userModel { get; set; }

        public GetUserQuery(UserModel userModel)
        {
            this.userModel = userModel;
        }
    }
}
