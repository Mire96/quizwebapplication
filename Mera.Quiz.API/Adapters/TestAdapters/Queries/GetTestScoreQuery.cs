using MediatR;
using Mera.Quiz.Domain.Models;

namespace Mera.Quiz.API.Adapters.TestAdapters.Queries
{
	public class GetTestScoreQuery : IRequest<TestScoreModel>
	{
        public int Id { get; set; }

		public GetTestScoreQuery(int id)
		{
			this.Id = id;
		}
	}
}
