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
    public class UpdateTestCommandHandler : IRequestHandler<UpdateTestCommand, TestModel>
    {
        private readonly ITestService _testService;

        public UpdateTestCommandHandler(ITestService testService)
        {
            _testService = testService;
        }

        public async Task<TestModel> Handle(UpdateTestCommand request, CancellationToken cancellationToken)
        {
            return await _testService.UpdateTestAsync(request.testModel);
        }
    }
}
