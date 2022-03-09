using AutoMapper;
using Mera.Quiz.Data.Entities;
using Mera.Quiz.Data.Interfaces;
using Mera.Quiz.Domain.Interfaces;
using Mera.Quiz.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mera.Quiz.Domain.Services
{
    public class TestService : ITestService
    {
        private readonly ITestRepository _testRepository;
        private readonly IMapper _mapper;

        public TestService(ITestRepository testRepository, IMapper mapper)
        {
            _testRepository = testRepository;
            _mapper = mapper;
        }

        public async Task<TestModel> CreateTestAsync(TestModel testModel)
        {
            var newTestEntity = _mapper.Map<TestModel, Test>(testModel);
            var createdTestEntity = await _testRepository.CreateTestAsync(newTestEntity);

            var createdTestModel = _mapper.Map<Test, TestModel>(createdTestEntity);
            return createdTestModel;
        }

        public async Task<int> CreateTestScoreAsync(TestModel testModel)
        {
            var newTestScoreEntity = _mapper.Map<TestModel, TestScore>(testModel);
            var createdTestScoreEntity = await _testRepository.CreateTestScoreAsync(newTestScoreEntity);

            return createdTestScoreEntity.ID;
        }

        public async Task<bool> DeleteTestAsync(int testId)
        {
            bool isDeleted = await _testRepository.DeleteTestAsync(testId);
            return isDeleted;
        }

        public async Task<List<TestModel>> GetAllTestsAsync()
        {
            var testEntities = await _testRepository.GetAllTestsAsync();
            var testModels = _mapper.Map<List<Test>, List<TestModel>>(testEntities);

            return testModels;

        }

        public async Task<TestModel> UpdateTestAsync(TestModel testModel)
        {
            var newTestEntity = _mapper.Map<TestModel, Test>(testModel);
            var updatedTestEntity = await _testRepository.UpdateTestAsync(newTestEntity);

            var updatedTestModel = _mapper.Map<Test, TestModel>(updatedTestEntity);
            return updatedTestModel;
        }
    }
}
