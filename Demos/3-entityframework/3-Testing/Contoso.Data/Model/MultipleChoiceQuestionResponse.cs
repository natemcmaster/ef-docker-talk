using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Contoso.Data.Model
{
    public class MultipleChoiceQuestionResponse : QuestionResponse
    {
        public MultipleChoiceQuestionResponse() : base(QuestionType.MultipleChoice)
        { }

        public int SelectedOptionId { get; set; }
        public MultipleChoiceOption SelectedOption { get; set; }
    }
}
