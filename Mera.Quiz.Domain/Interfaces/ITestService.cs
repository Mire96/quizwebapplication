using Mera.Quiz.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mera.Quiz.Domain.Interfaces
{
    public interface ITestService
    {
        public Task<List<TestModel>> GetAllTestsAsync();
        Task<TestModel> CreateTestAsync(TestModel testModel);
        Task<int> CreateTestScoreAsync(TestModel testModel);
        Task<TestModel> UpdateTestAsync(TestModel testModel);
        Task<bool> DeleteTestAsync(int testId);
    }
}
