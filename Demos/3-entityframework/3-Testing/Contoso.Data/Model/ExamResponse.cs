using System.Collections.Generic;

namespace Contoso.Data.Model
{
    public class ExamResponse
    {
        public int Id { get; set; }
        public int ExamId { get; set; }
        public Exam Exam { get; set; }
        public ICollection<QuestionResponse> QuestionResponses { get; set; }
            = new HashSet<QuestionResponse>();
    }
}