using MediatR;
using Mera.Quiz.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mera.Quiz.API.Adapters.Queries
{
    public class GetAllAnswersQuery : IRequest<List<AnswerModel>>
    {
    }
}
