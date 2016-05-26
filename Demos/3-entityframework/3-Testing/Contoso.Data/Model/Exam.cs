using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Contoso.Data.Model
{
    public class Exam
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Question> Questions { get; set; }
            = new HashSet<Question>();

        public ICollection<ExamResponse> Responses { get; set; }
            = new HashSet<ExamResponse>();
    }
}
