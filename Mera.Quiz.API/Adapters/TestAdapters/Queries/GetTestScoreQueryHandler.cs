using MediatR;
using Mera.Quiz.Domain.Interfaces;
using Mera.Quiz.Domain.Models;
using System.Threading;
using System.Threading.Tasks;

namespace Mera.Quiz.API.Adapters.TestAdapters.Queries
{
	public class GetTestScoreQueryHandler : IRequestHandler<GetTestScoreQuery, TestScoreModel>
	{
		private ITestService _testService;

		public GetTestScoreQueryHandler(ITestService testService)
		{
			_testService = testService;
		}

		public async Task<TestScoreModel> Handle(GetTestScoreQuery request, CancellationToken cancellationToken)
		{
			return await _testService.GetTestScoreAsync(request.Id);
		}
	}
}
