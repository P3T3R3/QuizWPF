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
        private int selectedAnswer;
        public int SelectedAnswer
        {
            get { return selectedAnswer; }
            set { selectedAnswer = value; }
        }
        private List<Answer> answers;
        public List<Answer> Answers
        {
            get { return answers; }
        }
        public string QuestionText
        {
            get { return questionText; }
            set { questionText = value; }
        }
        public Question(string questionText)
        {
            QuestionText = questionText;
            answers = new List<Answer>();
        }
        public string ToString()
        {
            return questionText;
        }

        public void addAnswer(string answerText, bool isCorrect)
        {
            answers.Add(new Answer(answerText, isCorrect));
        }
        public bool isCorrect(int id)
        {
            return answers[id].IsCorrect;
        }
        public void modifyAnswer(int id, string answerText, bool isCorrect)
        {
            answers[id].AnswerText = answerText;
            answers[id].IsCorrect = isCorrect;
        }
        public void deleteAnswer(int id)
        {
            answers.Remove(answers[id]);
        }
    }
}
