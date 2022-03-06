using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mera.Quiz.Domain.Models
{
    public class PlayerModel
    {
        public int ID { get; set; }
        public List<TestModel> PassedTestList { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public RoleModel Role { get; set; }
    }
}
