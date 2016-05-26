using System.ComponentModel.DataAnnotations;

namespace Contoso.Data.Model
{
    public abstract class Question
    {
        protected Question(int type)
        {
            Type = type;
        }

        public int Id { get; set; }
        public double Points { get; set; }

        public string Prompt { get; set; }

        [Required]
        public int ExamId { get; set; }
        public Exam Exam { get; set; }

        public int Type { get; set; }
    }
}