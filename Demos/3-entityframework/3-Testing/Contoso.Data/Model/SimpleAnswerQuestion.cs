using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Contoso.Data.Model
{
    public class SimpleAnswerQuestion : Question
    {
        public SimpleAnswerQuestion() : base(QuestionType.SimpleAnswer)
        {
            this.Points = 1;
        }
        public bool IsCaseSensitive { get; set; }
        public string ExpectedAnswer { get; set; }
    }
}
