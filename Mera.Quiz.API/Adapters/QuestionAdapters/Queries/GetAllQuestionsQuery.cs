using MediatR;
using Mera.Quiz.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mera.Quiz.API.Adapters.QuestionAdapters.Queries
{
    public class GetAllQuestionsQuery : IRequest<List<QuestionModel>>
    {
    }
}
