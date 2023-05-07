using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizCreator.Model
{
    public class Question
    {
        private string questionText;
        private List<Answer> answerList;
        public string QuestionText
        {
            get { return questionText; }
            set { questionText = value; }
        }
        public Question(string questionText)
        {
            QuestionText = questionText;
            answerList = new List<Answer>();
        }

        public void addAnswer(string answerText, bool isCorrect)
        {
            answerList.Add(new Answer(answerText, isCorrect));
        }
        public bool isCorrect(int id)
        {
            return answerList[id].IsCorrect;
        }
    }
}
