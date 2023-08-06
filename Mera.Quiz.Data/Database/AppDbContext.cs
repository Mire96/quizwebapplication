using Mera.Quiz.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mera.Quiz.Data.Database
{
    public class AppDbContext : DbContext
    {
        public DbSet<Answer> Answers { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<Test> Tests { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<TestScore> TestScores { get; set; }
        public DbSet<UserAnswers> UserAnswers { get; set; }



        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<UserAnswers>()
                .HasOne(ua => ua.ChosenAnswer)
				.WithMany() 
				.HasForeignKey(ua => ua.ChosenAnswerFK)
				.OnDelete(DeleteBehavior.NoAction);
			modelBuilder.Entity<UserAnswers>()
				.HasOne(ua => ua.Question)
				.WithMany()
				.HasForeignKey(ua => ua.QuestionFK)
				.OnDelete(DeleteBehavior.NoAction);
		}
		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			//optionsBuilder.UseSqlServer(@"Server=RSM2463\BARBOOKSDATABASE;Database=QuizDatabase;Trusted_Connection=True");
		}
	}
}
