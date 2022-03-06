﻿// <auto-generated />
using System;
using Mera.Quiz.Data.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Mera.Quiz.Data.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
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

                    b.Property<string>("QuestionText")
                        .IsRequired()
                        .HasColumnType("varchar(1000)")
                        .HasColumnName("questiontext");

                    b.Property<int?>("TestID")
                        .HasColumnType("int");

                    b.Property<int>("correctanswer")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("TestID");

                    b.HasIndex("correctanswer");

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

            modelBuilder.Entity("Mera.Quiz.Data.Entities.Answer", b =>
                {
                    b.HasOne("Mera.Quiz.Data.Entities.Question", null)
                        .WithMany("AnswerList")
                        .HasForeignKey("QuestionID");
                });

            modelBuilder.Entity("Mera.Quiz.Data.Entities.Question", b =>
                {
                    b.HasOne("Mera.Quiz.Data.Entities.Test", null)
                        .WithMany("QuestionList")
                        .HasForeignKey("TestID");

                    b.HasOne("Mera.Quiz.Data.Entities.Answer", "CorrectAnswer")
                        .WithMany()
                        .HasForeignKey("correctanswer")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CorrectAnswer");
                });

            modelBuilder.Entity("Mera.Quiz.Data.Entities.Question", b =>
                {
                    b.Navigation("AnswerList");
                });

            modelBuilder.Entity("Mera.Quiz.Data.Entities.Test", b =>
                {
                    b.Navigation("QuestionList");
                });
#pragma warning restore 612, 618
        }
    }
}
