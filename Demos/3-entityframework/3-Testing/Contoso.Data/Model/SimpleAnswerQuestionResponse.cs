using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Contoso.Data.Model
{
    public class SimpleAnswerQuestionResponse : QuestionResponse
    {
        public SimpleAnswerQuestionResponse() : base(QuestionType.SimpleAnswer)
        { }

        public string Response { get; set; }
    }
}
