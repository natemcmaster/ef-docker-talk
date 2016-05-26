using Contoso.Data;
using Contoso.Data.Model;
using Contoso.Services.Grading;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using Xunit;

namespace Contoso.Test
{
    public class GradingTest
    {
        private readonly SchoolContext _context;

        public GradingTest()
        {
            var optionsBuilder = new DbContextOptionsBuilder<SchoolContext>();
            optionsBuilder.UseInMemoryDatabase();

            _context = new SchoolContext(optionsBuilder.Options);
            SeedData();
        }

        [Fact]
        public void ItGradesMultipleChoice()
        {
            var response = _context.Responses
                    .Include(r => r.QuestionResponses).ThenInclude(q => q.Question)
                    .Include(r => r.Exam).ThenInclude(q => q.Questions)
                    .First();

            var result = new ResponseGrader().Grade(response);
            Assert.Equal(2, result.PointAvailable);
            Assert.Equal(1, result.PointsEarned);
        }

        private void SeedData()
        {
            var exam = new ExamBuilder()
                .HasName("Geography Midterm 1")
                .WithMultipleChoiceQuestion("What is capital of the United States?")
                    .WithOption("Washington, D.C.", isCorrect: true)
                    .WithOption("Los Angeles, CA", isCorrect: false)
                    .WithOption("Redmond, WA", isCorrect: false)
                    .WithOption("New York, NY", isCorrect: false)
                .Up()
                .WithSimpleAnswerQuestion("What continent is Italy on?", "Europe")
                .Exam;

            var responseSet = new ExamResponse { Exam = exam,
            };
            responseSet.QuestionResponses.Add(new MultipleChoiceQuestionResponse
            {
                ExamResponse = responseSet,
                Question = exam.Questions.First(),
                SelectedOption = exam.Questions.OfType<MultipleChoiceQuestion>().First().Options.First()
            });
            responseSet.QuestionResponses.Add(new SimpleAnswerQuestionResponse
            {
                ExamResponse = responseSet,
                Question = exam.Questions.Last(),
                Response = "Asia"
            });

            _context.AddRange(responseSet);

            Assert.Equal(10, _context.SaveChanges());
        }
    }
}
