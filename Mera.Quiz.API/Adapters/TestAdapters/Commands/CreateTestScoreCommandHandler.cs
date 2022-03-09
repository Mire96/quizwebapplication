using MediatR;
using Mera.Quiz.Domain.Interfaces;
using Mera.Quiz.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Mera.Quiz.API.Adapters.TestAdapters.Commands
{
    public class CreateTestScoreCommandHandler : IRequestHandler<CreateTestScoreCommand, int>
    {
        private ITestService _testService { get; set; }

        public CreateTestScoreCommandHandler(ITestService testService)
        {
            _testService = testService;
        }

        

        public async Task<int> Handle(CreateTestScoreCommand request, CancellationToken cancellationToken)
        {
            return await _testService.CreateTestScoreAsync(request.testModel);
        }
    }
}
