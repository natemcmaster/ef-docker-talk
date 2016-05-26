namespace Contoso.Data.Model
{
    public class ExamBuilder
    {
        private readonly Exam exam;
        public Exam Exam => exam;

        public ExamBuilder() : this(new Exam())
        {
        }

        public ExamBuilder(Exam exam)
        {
            this.exam = exam;
        }

        public ExamBuilder HasName(string name)
        {
            exam.Name = name;
            return this;
        }

        public ExamBuilder WithSimpleAnswerQuestion(string prompt, string answer)
        {
            var q = new SimpleAnswerQuestion()
            {
                Exam = exam,
                Prompt = prompt,
                ExpectedAnswer = answer
            };
            exam.Questions.Add(q);
            return this; 
        }

        public MultipleChoiceQuestionBuilder WithMultipleChoiceQuestion(string prompt)
        {
            var q = new MultipleChoiceQuestion
            {
                Prompt = prompt,
                Exam = exam,
            };
            exam.Questions.Add(q);
            return new MultipleChoiceQuestionBuilder(this, q);
        }
    }

    public class MultipleChoiceQuestionBuilder
    {
        private readonly ExamBuilder parent;
        private readonly MultipleChoiceQuestion question;

        public MultipleChoiceQuestionBuilder(ExamBuilder parent, MultipleChoiceQuestion question)
        {
            this.question = question;
            this.parent = parent;
        }

        public ExamBuilder Up() => parent;

        public MultipleChoiceQuestionBuilder WithOption(string text, bool isCorrect)
        {
            var o = new MultipleChoiceOption
            {
                Question = this.question,
                AnswerText = text,
            };
            if (isCorrect)
            {
                this.question.CorrectAnswer = o;
            }

            this.question.Options.Add(o);
            return this;
        }
    }
}
