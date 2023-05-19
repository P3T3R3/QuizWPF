using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizCreator.Model
{
    public class Quiz
    {
        private ObservableCollection<Question> questions;
        public ObservableCollection<Question> Questions
        {
            get { return questions; }
        }
        private string Name { get; set; }
        public Quiz(string name)
        {
            questions = new ObservableCollection<Model.Question>();
            Name = name;
        }
        public void addQuestion(string questionText)
        {
            questions.Add(new Question(questionText));
        }
        public void addQuestion(Question question)
        {
            questions.Add(new Question(question.QuestionText));
        }
        public void modifyQuestion(int id, Question question)
        {
            questions[id] = question;
        }
        public void deleteQuestion(int id)
        {
            if (questions.ElementAt(id) == null)
                return;
            questions.RemoveAt(id);
        }

    }
}
