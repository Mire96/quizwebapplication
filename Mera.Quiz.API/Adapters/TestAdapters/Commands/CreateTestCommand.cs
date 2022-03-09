using MediatR;
using Mera.Quiz.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mera.Quiz.API.Adapters.TestAdapters.Commands
{
    public class CreateTestCommand : IRequest<TestModel>
    {
        public TestModel testModel { get; set; }

        public CreateTestCommand(TestModel testModel)
        {
            this.testModel = testModel;
        }
    }
}
