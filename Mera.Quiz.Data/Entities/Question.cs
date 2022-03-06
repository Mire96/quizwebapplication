using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mera.Quiz.Data.Entities
{
    [Table("Question")]
    public class Question
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id")]
        public int ID { get; set; }

        [Column("questiontext", TypeName = "varchar(1000)")]
        [Required]
        public string QuestionText { get; set; }


        public List<Answer> AnswerList { get; set; }


        [Required]
        [ForeignKey("correctanswer")]
        public Answer CorrectAnswer { get; set; }
    }
}
