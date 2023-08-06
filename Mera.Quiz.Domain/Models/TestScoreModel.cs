using Mera.Quiz.Data.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mera.Quiz.Domain.Models
{
	public class TestScoreModel
	{
		public int ID { get; set; }

        public TestModel Test { get; set; }
        public UserModel User { get; set; }

		public int Score { get; set; }

		public DateTime DateTaken { get; set; }

		public List<UserAnswersModel> UserAnswers { get; set; }
	}
}
