using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Contoso.Data.Model
{
    public class MultipleChoiceQuestion : Question
    {
        public MultipleChoiceQuestion()
            : base(QuestionType.MultipleChoice)
        {
            this.Points = 1;
        }

        public int CorrectAnswerId { get; set; }
        public MultipleChoiceOption CorrectAnswer { get; set; }

        public ICollection<MultipleChoiceOption> Options { get; set; }
            = new HashSet<MultipleChoiceOption>();
    }
}
