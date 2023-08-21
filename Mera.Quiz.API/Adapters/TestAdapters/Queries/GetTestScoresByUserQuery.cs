using MediatR;
using Mera.Quiz.Domain.Models;
using System.Collections.Generic;

namespace Mera.Quiz.API.Adapters.TestAdapters.Queries
{
	public class GetTestScoresByUserQuery : IRequest<List<TestScoreModel>>
	{
		public int Id { get; set; }

		public GetTestScoresByUserQuery(int id)
		{
			Id = id;
		}
	}
}
