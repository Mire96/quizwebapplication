using MediatR;
using System.IO;

namespace Mera.Quiz.API.Adapters.TestAdapters.Queries
{
	public class DownloadTestScoreQuery : IRequest<MemoryStream>
	{
		public int Id { get; set; }

		public DownloadTestScoreQuery(int id)
		{
			Id = id;
		}
	}
}
