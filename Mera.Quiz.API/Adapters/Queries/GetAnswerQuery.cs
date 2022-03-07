using MediatR;
using Mera.Quiz.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mera.Quiz.API.Adapters.Queries
{
    public class GetAnswerQuery : IRequest<AnswerModel>
    {

        public int Id { get; }

        public GetAnswerQuery(int id)
        {
            Id = id;
        }

    }
}
