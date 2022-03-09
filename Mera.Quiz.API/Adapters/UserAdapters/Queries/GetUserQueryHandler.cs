using MediatR;
using Mera.Quiz.Domain.Interfaces;
using Mera.Quiz.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Mera.Quiz.API.Adapters.UserAdapters.Queries
{
    public class GetUserQueryHandler : IRequestHandler<GetUserQuery, UserModel>
    {
        public IUserService _userService { get; set; }

        public GetUserQueryHandler(IUserService userService)
        {
            _userService = userService;
        }

        public async Task<UserModel> Handle(GetUserQuery request, CancellationToken cancellationToken)
        {
            return await _userService.GetUserAsync(request.userModel);
        }
    }
}
