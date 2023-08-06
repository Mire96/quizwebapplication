using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mera.Quiz.Data.Entities
{
	[Table("UserAnswers")]
	public class UserAnswers
	{
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		[Column("id")]
		public int ID { get; set; }


		//[ForeignKey("TestScore")]
		//[Required]
		//public int TestScoreFK { get; set; }
  //      public TestScore TestScore { get; set; }

        [ForeignKey("Question")]
		[Required]
		public int QuestionFK { get; set; }
        public Question Question { get; set; }

        [ForeignKey("ChosenAnswer")]
		[Required]
		public int ChosenAnswerFK { get; set; }
        public Answer ChosenAnswer { get; set; }

    }
}
