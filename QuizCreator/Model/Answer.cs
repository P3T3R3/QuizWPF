using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizCreator.Model
{
    public class Answer
    {
        public string AnswerText
        {
            get;set;
        }
        public bool IsCorrect
        {
            get;set;
        }
        public Answer(string answerText, bool isCorrect)
        {
            AnswerText = answerText;
            IsCorrect = isCorrect;
        }
        public Answer(Answer answer)
        {
            AnswerText = answer.AnswerText;
            IsCorrect = answer.IsCorrect;
        }
        public string ToString()
        {
            return AnswerText;
        }

    }
}
