using MediatR;
using Mera.Quiz.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Mera.Quiz.API.Adapters.TestAdapters.Commands
{
    public class DeleteTestCommandHandler : IRequestHandler<DeleteTestCommand, bool>
    {
        private readonly ITestService _testService;

        public DeleteTestCommandHandler(ITestService testService)
        {
            _testService = testService;
        }

        public async Task<bool> Handle(DeleteTestCommand request, CancellationToken cancellationToken)
        {
            return await _testService.DeleteTestAsync(request.testId);
        }
    }
}
