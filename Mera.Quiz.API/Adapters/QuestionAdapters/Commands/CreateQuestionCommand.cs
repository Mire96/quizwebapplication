using MediatR;
using Mera.Quiz.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mera.Quiz.API.Adapters.QuestionAdapters.Commands
{
    public class CreateQuestionCommand : IRequest<QuestionModel>
    {
        public string QuestionText { get; set; }
        public List<AnswerModel> AnswerList { get; set; }
        public AnswerModel CorrectAnswer { get; set; }

        public CreateQuestionCommand(string questionText, IEnumerable<AnswerModel> answerList, AnswerModel correctAnswer)
        {
            QuestionText = questionText;
            AnswerList = answerList.ToList();
            CorrectAnswer = correctAnswer;
        }
    }
}
