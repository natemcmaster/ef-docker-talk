using System.ComponentModel.DataAnnotations;

namespace Contoso.Data.Model
{
    public abstract class QuestionResponse
    {
        protected QuestionResponse(int type)
        {
            Type = type;
        }

        public int Id { get; set; }
        [Required]
        public int ExamResponseId { get; set; }
        public ExamResponse ExamResponse { get; set; }

        [Required]
        public int QuestionId { get; set; }
        public Question Question { get; set; }

        public int Type { get; set; }
    }
}