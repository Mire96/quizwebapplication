using MediatR;
using Mera.Quiz.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mera.Quiz.API.Adapters.TestAdapters.Commands
{
    public class CreateTestScoreCommand : IRequest<int>
    {
        public TestScoreModel testScoreModel { get; set; }

        public CreateTestScoreCommand(TestScoreModel testScoreModel)
        {
            this.testScoreModel = testScoreModel;
        }
    }
}
