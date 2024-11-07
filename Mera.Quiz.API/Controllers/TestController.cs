using FluentValidation.Results;
using MediatR;
using Mera.Quiz.API.Adapters.TestAdapters.Commands;
using Mera.Quiz.API.Adapters.TestAdapters.Queries;
using Mera.Quiz.API.Validation;
using Mera.Quiz.Domain.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Mera.Quiz.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestController : ControllerBase
    {
        public readonly IMediator _mediator;

        public TestController(IMediator mediator)
        {
            _mediator = mediator;
        }


		[HttpGet("score/user/{id}")]
		public async Task<IActionResult> GetTestScoreByUser(int id)
		{
			var query = new GetTestScoresByUserQuery(id);
			var testScores = await _mediator.Send(query);

			return testScores != null ? (IActionResult)Ok(testScores) : NotFound();
		}

		[HttpGet("score/{id}")]
		public async Task<IActionResult> GetTestScore(int id)
		{
			var query = new GetTestScoreQuery(id);
			var testScore = await _mediator.Send(query);

			return testScore != null ? (IActionResult)Ok(testScore) : NotFound();
		}
		[HttpGet("score/download/{id}")]
		public async Task<IActionResult> DownloadTestScore(int id)
		{
			var query = new DownloadTestScoreQuery(id);
			var testScoreMs = await _mediator.Send(query);

			return testScoreMs != null ? Ok(testScoreMs.ToArray()): NotFound();
		}



		#region CRUD for Tests
		// GET: api/<TestController>
		[HttpGet]
        public async Task<IActionResult> Get()
        {
            var query = new GetAllTestsQuery();
            var tests = await _mediator.Send(query);

            return tests != null ? (IActionResult)Ok(tests) : NotFound();
        }

        // GET api/<TestController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<TestController>
        [HttpPost]
        public async Task<IActionResult> Post(TestModel testModel)
        {
            TestValidator validator = new TestValidator();
            ValidationResult result = validator.Validate(testModel);

            if (result.IsValid)
            {
                var command = new CreateTestCommand(testModel);
                var test = await _mediator.Send(command);

                return test.ID != 0 ? Ok(test) : NotFound(); 
            }
            string errorMessage = "Test creation failed //";
            foreach (var error in result.Errors)
            {
                errorMessage += $"  {error.ErrorMessage}";
            }
            return BadRequest(errorMessage);
        }

        // POST api/<TestController>/Score
        [HttpPost("Score")]
        public async Task<IActionResult> PostTestScore(TestScoreModel testScoreModel)
        {
            TestScoreValidator validator = new TestScoreValidator();
            ValidationResult result = validator.Validate(testScoreModel);

            if (result.IsValid)
            {
                var command = new CreateTestScoreCommand(testScoreModel);
                var test = await _mediator.Send(command);

                //This returns the ID of the test score in the database
                return test != 0 ? Ok(test) : NotFound();
            }

            return BadRequest();
            
        }

        // PUT api/<TestController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(TestModel testModel)
        {
            UpdateTestValidator validator = new UpdateTestValidator();
            ValidationResult result = validator.Validate(testModel);

            if (result.IsValid)
            {
                var command = new UpdateTestCommand(testModel);
                var test = await _mediator.Send(command);

                return test != null ? Ok(test) : NotFound();
            }
			string errorMessage = "Updating test failed //";
			foreach (var error in result.Errors)
			{
				errorMessage += $"  {error.ErrorMessage}";
			}
			return BadRequest(errorMessage);

		}

        // DELETE api/<TestController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var command = new DeleteTestCommand(id);
            bool deleteTestSuccesful = await _mediator.Send(command);

            return deleteTestSuccesful ? Ok() : NotFound("Failed to delete test");

        }

        #endregion
    }
}
