﻿// <auto-generated />
using System;
using Mera.Quiz.Data.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Mera.Quiz.Data.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20230806111821_UserAnswersAdded")]
    partial class UserAnswersAdded
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.14")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Mera.Quiz.Data.Entities.Answer", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("AnswerText")
                        .IsRequired()
                        .HasColumnType("varchar(1000)")
                        .HasColumnName("answertext");

                    b.Property<int?>("QuestionID")
                        .HasColumnType("int");

                    b.Property<bool>("isChosen")
                        .HasColumnType("bit")
                        .HasColumnName("isChosen");

                    b.HasKey("ID");

                    b.HasIndex("QuestionID");

                    b.ToTable("Answer");
                });

            modelBuilder.Entity("Mera.Quiz.Data.Entities.Question", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CorrectAnswerID")
                        .HasColumnType("int")
                        .HasColumnName("correctanswer_id");

                    b.Property<string>("QuestionText")
                        .IsRequired()
                        .HasColumnType("varchar(1000)")
                        .HasColumnName("questiontext");

                    b.Property<int?>("TestID")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("CorrectAnswerID");

                    b.HasIndex("TestID");

                    b.ToTable("Question");
                });

            modelBuilder.Entity("Mera.Quiz.Data.Entities.Test", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("TestName")
                        .IsRequired()
                        .HasColumnType("varchar(20)")
                        .HasColumnName("testname");

                    b.HasKey("ID");

                    b.ToTable("Test");
                });

            modelBuilder.Entity("Mera.Quiz.Data.Entities.TestScore", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DateTaken")
                        .HasColumnType("datetime2")
                        .HasColumnName("DateTaken");

                    b.Property<int>("Score")
                        .HasColumnType("int")
                        .HasColumnName("Score");

                    b.Property<int>("TestNameFK")
                        .HasColumnType("int");

                    b.Property<int>("UserNameFK")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("TestNameFK");

                    b.HasIndex("UserNameFK");

                    b.ToTable("TestScore");
                });

            modelBuilder.Entity("Mera.Quiz.Data.Entities.User", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("varchar(20)")
                        .HasColumnName("Password");

                    b.Property<string>("Role")
                        .IsRequired()
                        .HasColumnType("varchar(20)")
                        .HasColumnName("Role");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnType("varchar(20)")
                        .HasColumnName("UserName");

                    b.HasKey("ID");

                    b.ToTable("User");
                });

            modelBuilder.Entity("Mera.Quiz.Data.Entities.UserAnswers", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ChosenAnswerFK")
                        .HasColumnType("int");

                    b.Property<int>("QuestionFK")
                        .HasColumnType("int");

                    b.Property<int?>("TestScoreID")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("ChosenAnswerFK");

                    b.HasIndex("QuestionFK");

                    b.HasIndex("TestScoreID");

                    b.ToTable("UserAnswers");
                });

            modelBuilder.Entity("Mera.Quiz.Data.Entities.Answer", b =>
                {
                    b.HasOne("Mera.Quiz.Data.Entities.Question", null)
                        .WithMany("AnswerList")
                        .HasForeignKey("QuestionID");
                });

            modelBuilder.Entity("Mera.Quiz.Data.Entities.Question", b =>
                {
                    b.HasOne("Mera.Quiz.Data.Entities.Answer", "CorrectAnswer")
                        .WithMany()
                        .HasForeignKey("CorrectAnswerID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Mera.Quiz.Data.Entities.Test", null)
                        .WithMany("QuestionList")
                        .HasForeignKey("TestID");

                    b.Navigation("CorrectAnswer");
                });

            modelBuilder.Entity("Mera.Quiz.Data.Entities.TestScore", b =>
                {
                    b.HasOne("Mera.Quiz.Data.Entities.Test", "Test")
                        .WithMany()
                        .HasForeignKey("TestNameFK")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Mera.Quiz.Data.Entities.User", "User")
                        .WithMany()
                        .HasForeignKey("UserNameFK")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Test");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Mera.Quiz.Data.Entities.UserAnswers", b =>
                {
                    b.HasOne("Mera.Quiz.Data.Entities.Answer", "ChosenAnswer")
                        .WithMany()
                        .HasForeignKey("ChosenAnswerFK")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("Mera.Quiz.Data.Entities.Question", "Question")
                        .WithMany()
                        .HasForeignKey("QuestionFK")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("Mera.Quiz.Data.Entities.TestScore", null)
                        .WithMany("UserAnswers")
                        .HasForeignKey("TestScoreID");

                    b.Navigation("ChosenAnswer");

                    b.Navigation("Question");
                });

            modelBuilder.Entity("Mera.Quiz.Data.Entities.Question", b =>
                {
                    b.Navigation("AnswerList");
                });

            modelBuilder.Entity("Mera.Quiz.Data.Entities.Test", b =>
                {
                    b.Navigation("QuestionList");
                });

            modelBuilder.Entity("Mera.Quiz.Data.Entities.TestScore", b =>
                {
                    b.Navigation("UserAnswers");
                });
#pragma warning restore 612, 618
        }
    }
}
