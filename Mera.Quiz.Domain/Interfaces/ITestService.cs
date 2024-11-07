using Mera.Quiz.Domain.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mera.Quiz.Domain.Interfaces
{
    public interface ITestService
    {
        public Task<List<TestModel>> GetAllTestsAsync();
        Task<TestModel> CreateTestAsync(TestModel testModel);
        Task<int> CreateTestScoreAsync(TestScoreModel testModel);
        Task<TestScoreModel> GetTestScoreAsync(int testScoreId);
		Task<List<TestScoreModel>> GetAllTestScoresByUserAsync(int userId);
		Task<TestModel> UpdateTestAsync(TestModel testModel);
        Task<bool> DeleteTestAsync(int testId);
        Task<MemoryStream> DownloadTestScore(int testScoreId);

	}
}
