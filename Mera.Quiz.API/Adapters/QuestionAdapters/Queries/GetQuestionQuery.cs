using MediatR;
using Mera.Quiz.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mera.Quiz.API.Adapters.QuestionAdapters.Queries
{
    public class GetQuestionQuery : IRequest<QuestionModel>
    {
        public int Id { get; }

        public GetQuestionQuery(int id)
        {
            Id = id;
        }
    }
}
