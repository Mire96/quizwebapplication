using MediatR;
using Mera.Quiz.API.Adapters.Commands;
using Mera.Quiz.API.Adapters.Queries;
using Mera.Quiz.Domain.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Mera.Quiz.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AnswerController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AnswerController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // GET: api/<AnswerController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var query = new GetAllAnswersQuery();
            var answers = await _mediator.Send(query);
            return answers != null ? (IActionResult)Ok(answers) : NotFound();
        }

        // GET api/<AnswerController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var query = new GetAnswerQuery(id);
            var answer = await _mediator.Send(query);
            return answer != null ? (IActionResult) Ok(answer) : NotFound();
        }

        // POST api/<AnswerController>
        [HttpPost]
        public async Task<IActionResult> Post(AnswerModel answerModel)
        {
            var command = new CreateAnswerCommand(answerModel);
            var answer = await _mediator.Send(command);
            return answer.ID != -1 ? (IActionResult)Ok(answer) : NotFound();
        }

        // PUT api/<AnswerController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(AnswerModel answerModel)
        {
            var command = new UpdateAnswerCommand(answerModel);
            var answer = await _mediator.Send(command);
            return answerModel.Equals(answer) ? (IActionResult)Ok(answer) : NotFound();
        }

        // DELETE api/<AnswerController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var command = new DeleteAnswerCommand(id);
            bool deleteAnswerSuccesful = await _mediator.Send(command);
            return deleteAnswerSuccesful ? (IActionResult)Ok() : NotFound();
        }
    }
}
