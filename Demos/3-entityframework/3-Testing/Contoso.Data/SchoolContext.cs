using Contoso.Data.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Contoso.Data
{
    public class SchoolContext : DbContext
    {
        public SchoolContext(DbContextOptions<SchoolContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Question>()
                .HasDiscriminator(e => e.Type)
                .HasValue<MultipleChoiceQuestion>(QuestionType.MultipleChoice)
                .HasValue<SimpleAnswerQuestion>(QuestionType.SimpleAnswer);

            modelBuilder.Entity<QuestionResponse>()
                .HasDiscriminator(e => e.Type)
                .HasValue<MultipleChoiceQuestionResponse>(QuestionType.MultipleChoice)
                .HasValue<SimpleAnswerQuestionResponse>(QuestionType.SimpleAnswer);
        }

        public DbSet<Exam> Exams { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<MultipleChoiceOption> MultipleChoiceOptions { get; set; }
        public DbSet<ExamResponse> Responses { get; set; }
        public DbSet<QuestionResponse> QuestionResponses { get; set; }
    }
}
