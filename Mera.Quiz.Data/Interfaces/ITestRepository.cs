﻿using Mera.Quiz.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mera.Quiz.Data.Interfaces
{
    public interface ITestRepository
    {
        Task<List<Test>> GetAllTestsAsync();
        Task<Test> CreateTestAsync(Test newTestEntity);
        Task<TestScore> CreateTestScoreAsync(TestScore newTestScoreEntity);
        Task<Test> UpdateTestAsync(Test newTestEntity);
        Task<bool> DeleteTestAsync(int testId);
    }
}
