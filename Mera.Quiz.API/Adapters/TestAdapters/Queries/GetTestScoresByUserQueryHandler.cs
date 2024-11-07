using MediatR;
using Mera.Quiz.Domain.Interfaces;
using Mera.Quiz.Domain.Models;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Mera.Quiz.API.Adapters.TestAdapters.Queries
{
	public class GetTestScoresByUserQueryHandler : IRequestHandler<GetTestScoresByUserQuery, List<TestScoreModel>>
	{
		private ITestService _testService;
		public GetTestScoresByUserQueryHandler(ITestService testService)
		{
			_testService = testService;
		}

		public async Task<List<TestScoreModel>> Handle(GetTestScoresByUserQuery request, CancellationToken cancellationToken)
		{
			return await _testService.GetAllTestScoresByUserAsync(request.Id);
		}
	}
}
