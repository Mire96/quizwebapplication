using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mera.Quiz.API.Adapters.Commands
{
    public class DeleteAnswerCommand : IRequest<bool>
    {
        public int Id { get;}

        public DeleteAnswerCommand(int id)
        {
            Id = id;
        }
    }
}
