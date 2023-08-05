using Mera.Quiz.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mera.Quiz.Domain.Models
{
    public class QuestionModel
    {
        public int ID { get; set; }
        public string QuestionText { get; set; }
        public List<AnswerModel> AnswerList { get; set; }
		public AnswerModel CorrectAnswer { get; set; }


		public QuestionModel()
        {

        }

        public QuestionModel(string questionText, List<AnswerModel> answerList, AnswerModel correctAnswer)
        {
            ID = -1;
            QuestionText = questionText;
            AnswerList = answerList;
            CorrectAnswer = correctAnswer;
        }
    }
}
