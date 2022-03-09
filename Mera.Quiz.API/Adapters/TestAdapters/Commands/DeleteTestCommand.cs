using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mera.Quiz.API.Adapters.TestAdapters.Commands
{
    public class DeleteTestCommand : IRequest<bool>
    {
        public int testId { get; set; }

        public DeleteTestCommand(int testId)
        {
            this.testId = testId;
        }
    }
}
