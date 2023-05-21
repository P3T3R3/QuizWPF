using QuizCreator.Model;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.IO;
namespace QuizCreator.ViewModel
{

    class MainViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private Model.Quiz quiz;
        public Model.Quiz Quiz
        {
            get { return quiz; }
            private set { quiz = value; OnPropertyChanged(nameof(Quiz)); }
        }
        private Model.Question currentQuestion;
        public Model.Question CurrentQuestion
        {
            get { return currentQuestion; }
            private set { currentQuestion = value; OnPropertyChanged(nameof(CurrentQuestion)); }
        }
        private Model.Answer currentAnswer;
        public Model.Answer CurrentAnswer
        {
            get { return currentAnswer; }
            private set { currentAnswer = value; OnPropertyChanged(nameof(CurrentAnswer)); }
        }
        private int selectedQuestionId;
        public int SelectedQuestionId { get { return selectedQuestionId; }
            set 
            {
                if (value == -1)
                    return;
                if (value == selectedQuestionId)
                    return;
                selectedQuestionId = value;
                CurrentQuestion = Quiz.Questions[selectedQuestionId];
                CurrentAnswer = Quiz.Questions[selectedQuestionId].Answers[0];
                OnPropertyChanged(nameof(SelectedQuestionId));
            } 
        }

        private int selectedAnswerId;
        public int SelectedAnswerId
        {
            get { return selectedAnswerId; }
            set
            {
                if (value == -1)
                    return;
                if (value == selectedAnswerId)
                    return;
                selectedAnswerId = value;
                CurrentAnswer = new Model.Answer(Quiz.Questions[selectedQuestionId].Answers[selectedAnswerId]);
                OnPropertyChanged(nameof(SelectedAnswerId));
            }
        }

        private ICommand addQuestion;
        private ICommand modifyQuestion;
        private ICommand deleteQuestion;
        private ICommand modifyAnswer;
        private ICommand saveDatabase;
        private ICommand loadDatabase;
        public ICommand AddQuestion
        {
            get
            {
                return addQuestion ?? (addQuestion = new RelayCommand(
                    (p) => { Quiz.addQuestion(CurrentQuestion);
                        CurrentQuestion = new Model.Question("");
                        OnPropertyChanged("Quiz");
                    }
                    ,
                    p => true)
                    );
            }
        }
        public ICommand ModifyQuestion
        {
            get
            {
                return modifyQuestion ?? (modifyQuestion = new RelayCommand(
                    (p) => {
                        Quiz.modifyQuestion(selectedQuestionId, CurrentQuestion);
                        CurrentQuestion = new Model.Question("");
                        OnPropertyChanged("Quiz");
                    }
                    ,
                    p => true)
                    );
            }
        }
        public ICommand DeleteQuestion
        {
            get
            {
                return deleteQuestion ?? (deleteQuestion = new RelayCommand(
                    (p) => {
                        Quiz.deleteQuestion(selectedQuestionId);
                        OnPropertyChanged("Quiz");
                    }
                    ,
                    p => true)
                    );
            }
        }
        public ICommand ModifyAnswer
        {
            get
            {
                return modifyAnswer ?? (modifyAnswer = new RelayCommand(
                    (p) => {
                        Quiz.Questions[SelectedQuestionId].modifyAnswer(SelectedAnswerId, CurrentAnswer);
                        CurrentQuestion = Quiz.Questions[SelectedQuestionId];
                        OnPropertyChanged("Quiz");
                    }
                    ,
                    p => true)
                    );
            }
        }
        public ICommand SaveDatabase
        {
            get
            {
                return saveDatabase ?? (saveDatabase = new RelayCommand(
                    (p) => {
                        Model.DbCreator.create(quiz);
                    }
                    ,
                    p => true)
                    );
            }
        }
        public ICommand LoadDatabase
        {
            get
            {
                return loadDatabase ?? (loadDatabase = new RelayCommand(
                    (p) => {
                        if(File.Exists(Quiz.Name+".db"))
                            Quiz = Model.DbReader.load(Quiz.Name);
                    }
                    ,
                    p => true)
                    );
            }
        }
        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        public MainViewModel()
        {
            Quiz = new Model.Quiz("Test quiz");
            CurrentQuestion = new Model.Question("");
            Quiz.addQuestion(new Model.Question("Test 123?"));
            Quiz.addQuestion(new Model.Question("Test 12325625?"));
            
        }

    }
}
