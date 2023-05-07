using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace QuizCreator.ViewModel
{

    class MainViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private Model.Quiz quiz;
        public Model.Quiz Quiz
        {
            get { return quiz; }
            private set { quiz = value; PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Quiz))); }
        }
        private Model.Question currentQuestion;
        public Model.Question CurrentQuestion
        {
            get { return currentQuestion; }
            private set { currentQuestion = value; PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(CurrentQuestion))); }
        }
        public MainViewModel()
        {
            Quiz = new Model.Quiz("Test quiz");
            Quiz.addQuestion("Test 123?");
            Quiz.addQuestion("Test 1234?");
            Quiz.Questions[0].addAnswer("Odp 1", true);
            CurrentQuestion = Quiz.Questions[0];
        }
        private ICommand selectQuestion;
        public ICommand SelectQuestion {
            get
            {
                // jesli nie jest określone polecenie to tworzymy je i zwracamy poprozez 
                //pomocniczy typ RelayCommand
                return selectQuestion ?? (selectQuestion = new RelayCommand(
                    //co wykonuje polecenie
                    (p) => { }
                    ,
                    //warunek kiedy może je wykonać
                    p => true)
                    );
            }
        }
    }
}
