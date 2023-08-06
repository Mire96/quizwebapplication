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
        public string TestName { get; set; }
        public List<QuestionModel> QuestionList { get; set; }
        public UserModel UserName { get; set; }
        public TestScoreModel TestScore { get; set; }
    }
}
