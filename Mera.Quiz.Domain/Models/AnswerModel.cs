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
        public bool isCorrect { get; set; }

        public AnswerModel()
        {

        }

        public AnswerModel(string answerText, bool isCorrect)
        {
            ID = -1;
            AnswerText = answerText;
            this.isCorrect = isCorrect;
        }


        public override bool Equals(object obj)
        {
            return obj is AnswerModel model &&
                   ID == model.ID &&
                   AnswerText == model.AnswerText &&
                   isCorrect == model.isCorrect;
        }
    }
}
