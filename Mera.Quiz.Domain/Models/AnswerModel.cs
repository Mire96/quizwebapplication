using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mera.Quiz.Domain.Models
{
    public class AnswerModel
    {
        public int ID { get; set; }
        public string AnswerText { get; set; }

        public AnswerModel()
        {

        }

        public AnswerModel(string answerText)
        {
            ID = -1;
            AnswerText = answerText;
        }

        public AnswerModel(int iD, string answerText)
        {
            ID = iD;
            AnswerText = answerText;
        }
    }
}
