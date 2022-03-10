using FluentValidation.Results;
using MediatR;
using Mera.Quiz.API.Adapters.UserAdapters.Commands;
using Mera.Quiz.API.Adapters.UserAdapters.Queries;
using Mera.Quiz.API.Validation;
using Mera.Quiz.Domain.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Mera.Quiz.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        public readonly IMediator _mediator;

        public UserController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // GET api/<UserController>/5
        [HttpGet("{id}")]
        public void Get(UserModel userModel)
        {
            
        }

        // POST api/<UserController>/login
        [HttpPost("login")]
        public async Task<IActionResult> VerifyUserAsync(UserModel userModel)
        {
            UserValidator validator = new UserValidator();
            ValidationResult result = validator.Validate(userModel);
            if (result.IsValid)
            {
                var query = new GetUserQuery(userModel);
                var user = await _mediator.Send(query);

                return user != null ? (IActionResult)Ok(user) : NotFound();
            }
            return BadRequest();
            
        }
        // POST api/<UserController>/create
        [HttpPost("create")]
        public async Task<IActionResult> PostUser(UserModel userModel)
        {
            UserValidator validator = new UserValidator();
            ValidationResult result = validator.Validate(userModel);
            if (result.IsValid)
            {
                var command = new CreateUserCommand(userModel);
                var user = await _mediator.Send(command);

                return user != null ? (IActionResult)Ok(user) : NotFound();
            }
            return BadRequest();
        }

        
    }
}
