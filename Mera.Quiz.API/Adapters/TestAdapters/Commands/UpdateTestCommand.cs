using MediatR;
using Mera.Quiz.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mera.Quiz.API.Adapters.TestAdapters.Commands
{
    public class UpdateTestCommand : IRequest<TestModel>
    {
        public TestModel testModel { get; set; }

        public UpdateTestCommand(TestModel testModel)
        {
            this.testModel = testModel;
        }
    }
}
