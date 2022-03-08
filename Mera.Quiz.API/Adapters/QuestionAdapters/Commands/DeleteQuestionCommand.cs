using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mera.Quiz.API.Adapters.QuestionAdapters.Commands
{
    public class DeleteQuestionCommand : IRequest<bool>
    {
        public int Id { get; set; }

        public DeleteQuestionCommand(int id)
        {
            Id = id;
        }
    }
}
