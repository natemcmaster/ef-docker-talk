using Contoso.Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Contoso.Services.Grading
{
    public class ResponseGrader
    {
        public GradingResult Grade(ExamResponse response)
        {
            var result = new GradingResult();

            if (response.Exam.Questions.Count != response.QuestionResponses.Count)
            {
                throw new InvalidOperationException("Exam is incomplete. Question count and responses do not match.");
            }

            foreach (var r in response.QuestionResponses)
            {
                result.PointAvailable += r.Question.Points;
                result.PointsEarned += AssessPoints((dynamic)r);
            }

            return result;
        }

        private double AssessPoints(MultipleChoiceQuestionResponse response)
        {
            return response.SelectedOptionId == (response.Question as MultipleChoiceQuestion).CorrectAnswerId
                ? response.Question.Points
                : 0;
        }

        private double AssessPoints(SimpleAnswerQuestionResponse response)
        {
            var q = response.Question as SimpleAnswerQuestion;
            var comparison = q.IsCaseSensitive
                ? StringComparison.OrdinalIgnoreCase
                : StringComparison.Ordinal;
            return response.Response.Equals(q.ExpectedAnswer, comparison)
                ? q.Points
                : 0;
        }
    }
}
