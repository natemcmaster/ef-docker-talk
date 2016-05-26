namespace Contoso.Data.Model
{
    public class MultipleChoiceOption
    {
        public int Id { get; set; }
        public int QuestionId { get; set; }
        public Question Question { get; set; }

        public string AnswerText { get; set; }
    }
}