using MediatR;
using Mera.Quiz.Domain.Interfaces;
using Mera.Quiz.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Mera.Quiz.API.Adapters.TestAdapters.Queries
{
    public class GetAllTestsQueryHandler : IRequestHandler<GetAllTestsQuery, List<TestModel>>
    {
        private ITestService _testService;

        public GetAllTestsQueryHandler(ITestService testService)
        {
            _testService = testService;
        }

        public async Task<List<TestModel>> Handle(GetAllTestsQuery request, CancellationToken cancellationToken)
        {
            return await _testService.GetAllTestsAsync();
        }
    }
}
