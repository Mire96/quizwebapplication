using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mera.Quiz.Data.Entities
{
    [Table("TestScore")]
    public class TestScore
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id")]
        public int ID { get; set; }

        public Test Test { get; set; }

        [ForeignKey("Test")]
        [Required]
        public int TestNameFK { get; set; }

        public User User { get; set; }

        [ForeignKey("User")]
        [Required]
        public int UserNameFK { get; set; }

        
        [Column("Score", TypeName = "int")]
        [Required]
        public int Score { get; set; }

    }
}
