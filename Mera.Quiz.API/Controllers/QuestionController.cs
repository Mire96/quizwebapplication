using MediatR;
using Mera.Quiz.API.Adapters.QuestionAdapters.Commands;
using Mera.Quiz.API.Adapters.QuestionAdapters.Queries;
using Mera.Quiz.Domain.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Mera.Quiz.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuestionController : ControllerBase
    {
        public readonly IMediator _mediator;

        public QuestionController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // GET: api/<QuestionController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var query = new GetAllQuestionsQuery();
            var questions = await _mediator.Send(query);

            return questions != null ? (IActionResult)Ok(questions) : NotFound();
        }

        // GET api/<QuestionController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var query = new GetQuestionQuery(id);
            var question = await _mediator.Send(query);

            return question != null ? (IActionResult)Ok(question) : NotFound();
        }

        // POST api/<QuestionController>
        [HttpPost]
        [Route("insert")]
        //Napravi svoj QuestionModel u QuizUI koji ce biti isti kao domain model i prosledi potrebne parametre u Insert Question
        public async Task<IActionResult> InsertQuestion(QuestionModel questionModel)
        {

            var command = new CreateQuestionCommand(questionModel);
            var question = await _mediator.Send(command);

            return question.ID != -1 ? (IActionResult)Ok(question) : NotFound();
        }

        // PUT api/<QuestionController>/5/text
        // Used to edit the question text
        [HttpPut("{id}/text")]
        public async Task<IActionResult> PutText(QuestionModel questionModel)
        {
            var command = new UpdateQuestionTextCommand(questionModel);
            var question = await _mediator.Send(command);

            return question != null ? (IActionResult)Ok(question) : NotFound();
        }

        // PUT api/<QuestionController>/5/answers
        // Used to edit the question answers
        [HttpPut("{id}/answers")]
        public async Task<IActionResult> PutAnswers(QuestionModel questionModel)
        {
            //Check if we have any answers in the list
            if(questionModel.AnswerList != null && questionModel.AnswerList.Count > 1)
            {
                var command = new UpdateQuestionAnswersCommand(questionModel);
                var question = await _mediator.Send(command);

                return question != null ? (IActionResult)Ok(question) : NotFound();
            }
            return NotFound("Can't pass a list with less than 2 answers");


        }

        // DELETE api/<QuestionController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {

            var command = new DeleteQuestionCommand(id);
            bool deleteAnswerSuccesful = await _mediator.Send(command);
            return deleteAnswerSuccesful ? (IActionResult)Ok() : NotFound();
        }
    }
}
