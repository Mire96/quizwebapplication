using MediatR;
using Mera.Quiz.Domain.Interfaces;
using Mera.Quiz.Domain.Models;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace Mera.Quiz.API.Adapters.TestAdapters.Queries
{
	public class DownloadTestScoreQueryHandler : IRequestHandler<DownloadTestScoreQuery, MemoryStream>
	{
		private ITestService _testService;
		public DownloadTestScoreQueryHandler(ITestService testService)
		{
			_testService = testService;
		}
		public async Task<MemoryStream> Handle(DownloadTestScoreQuery request, CancellationToken cancellationToken)
		{
			return await _testService.DownloadTestScore(request.Id);
		}
	}
}
