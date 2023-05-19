using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
        private ObservableCollection<Answer> answers;
        public ObservableCollection<Answer> Answers
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
            answers = new ObservableCollection<Answer>();
            for(int i = 1; i < 5; i++)
            {
                answers.Add(new Answer("Odp "+i,false));
            }
        }

        public Question(Question question)
        {
            QuestionText = question.QuestionText;
            answers = new ObservableCollection<Answer>(question.Answers.ToList());
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
        public void modifyAnswer(int id, Answer answer)
        {
            answers[id] = answer;
        }
        public void deleteAnswer(int id)
        {
            answers.Remove(answers[id]);
        }
    }
}
