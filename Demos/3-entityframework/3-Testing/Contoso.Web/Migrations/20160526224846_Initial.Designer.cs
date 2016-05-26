using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Contoso.Data;

namespace Contoso.Web.Migrations
{
    [DbContext(typeof(SchoolContext))]
    [Migration("20160526224846_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.0.0-rc2-20896");

            modelBuilder.Entity("Contoso.Data.Model.Exam", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("Exam");
                });

            modelBuilder.Entity("Contoso.Data.Model.ExamResponse", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("ExamId");

                    b.HasKey("Id");

                    b.HasIndex("ExamId");

                    b.ToTable("ExamResponse");
                });

            modelBuilder.Entity("Contoso.Data.Model.MultipleChoiceOption", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("AnswerText");

                    b.Property<int?>("MultipleChoiceQuestionId");

                    b.Property<int>("QuestionId");

                    b.HasKey("Id");

                    b.HasIndex("MultipleChoiceQuestionId");

                    b.HasIndex("QuestionId");

                    b.ToTable("MultipleChoiceOption");
                });

            modelBuilder.Entity("Contoso.Data.Model.Question", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("ExamId");

                    b.Property<double>("Points");

                    b.Property<string>("Prompt");

                    b.Property<int>("Type");

                    b.HasKey("Id");

                    b.HasIndex("ExamId");

                    b.ToTable("Question");

                    b.HasDiscriminator<int>("Type");
                });

            modelBuilder.Entity("Contoso.Data.Model.QuestionResponse", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("ExamResponseId");

                    b.Property<int>("QuestionId");

                    b.Property<int>("Type");

                    b.HasKey("Id");

                    b.HasIndex("ExamResponseId");

                    b.HasIndex("QuestionId");

                    b.ToTable("QuestionResponse");

                    b.HasDiscriminator<int>("Type");
                });

            modelBuilder.Entity("Contoso.Data.Model.MultipleChoiceQuestion", b =>
                {
                    b.HasBaseType("Contoso.Data.Model.Question");

                    b.Property<int>("CorrectAnswerId");

                    b.HasIndex("CorrectAnswerId");

                    b.ToTable("MultipleChoiceQuestion");

                    b.HasDiscriminator().HasValue(1);
                });

            modelBuilder.Entity("Contoso.Data.Model.SimpleAnswerQuestion", b =>
                {
                    b.HasBaseType("Contoso.Data.Model.Question");

                    b.Property<string>("ExpectedAnswer");

                    b.Property<bool>("IsCaseSensitive");

                    b.ToTable("SimpleAnswerQuestion");

                    b.HasDiscriminator().HasValue(2);
                });

            modelBuilder.Entity("Contoso.Data.Model.MultipleChoiceQuestionResponse", b =>
                {
                    b.HasBaseType("Contoso.Data.Model.QuestionResponse");

                    b.Property<int>("SelectedOptionId");

                    b.HasIndex("SelectedOptionId");

                    b.ToTable("MultipleChoiceQuestionResponse");

                    b.HasDiscriminator().HasValue(1);
                });

            modelBuilder.Entity("Contoso.Data.Model.SimpleAnswerQuestionResponse", b =>
                {
                    b.HasBaseType("Contoso.Data.Model.QuestionResponse");

                    b.Property<string>("Response");

                    b.ToTable("SimpleAnswerQuestionResponse");

                    b.HasDiscriminator().HasValue(2);
                });

            modelBuilder.Entity("Contoso.Data.Model.ExamResponse", b =>
                {
                    b.HasOne("Contoso.Data.Model.Exam")
                        .WithMany()
                        .HasForeignKey("ExamId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Contoso.Data.Model.MultipleChoiceOption", b =>
                {
                    b.HasOne("Contoso.Data.Model.MultipleChoiceQuestion")
                        .WithMany()
                        .HasForeignKey("MultipleChoiceQuestionId");

                    b.HasOne("Contoso.Data.Model.Question")
                        .WithMany()
                        .HasForeignKey("QuestionId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Contoso.Data.Model.Question", b =>
                {
                    b.HasOne("Contoso.Data.Model.Exam")
                        .WithMany()
                        .HasForeignKey("ExamId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Contoso.Data.Model.QuestionResponse", b =>
                {
                    b.HasOne("Contoso.Data.Model.ExamResponse")
                        .WithMany()
                        .HasForeignKey("ExamResponseId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Contoso.Data.Model.Question")
                        .WithMany()
                        .HasForeignKey("QuestionId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Contoso.Data.Model.MultipleChoiceQuestion", b =>
                {
                    b.HasOne("Contoso.Data.Model.MultipleChoiceOption")
                        .WithMany()
                        .HasForeignKey("CorrectAnswerId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Contoso.Data.Model.MultipleChoiceQuestionResponse", b =>
                {
                    b.HasOne("Contoso.Data.Model.MultipleChoiceOption")
                        .WithMany()
                        .HasForeignKey("SelectedOptionId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
        }
    }
}
