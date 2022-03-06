using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mera.Quiz.Domain.Models
{
    public class TestModel
    {
        public int ID { get; set; }
        public List<QuestionModel> QuestionList { get; set; }
        public PlayerModel CurrentPlayer { get; set; }
        public int Score { get; set; }
    }
}
