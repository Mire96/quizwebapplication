using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mera.Quiz.Domain.Models
{
	public class UserAnswersModel
	{
        public int ID { get; set; }

        public QuestionModel Question { get; set; }

		public AnswerModel ChosenAnswer { get; set; }
	}
}
