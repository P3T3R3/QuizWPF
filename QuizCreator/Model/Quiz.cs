using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizCreator.Model
{
    public class Quiz
    {
        private List<Question> questions;
        public List<Question> Questions
        {
            get { return questions; }
        }
        private string Name { get; set; }
        public Quiz(string name)
        {
            Name = name;
            questions = new List<Question>();
        }
        public void addQuestion(string questionText)
        {
            questions.Add(new Question(questionText));
        }

    }
}
