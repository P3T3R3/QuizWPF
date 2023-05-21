using System.Data.SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace QuizCreator.Model
{
    public class DbCreator
    {
        public static void create(Quiz quiz) {
            // this creates a zero-byte file
            File.Delete(quiz.Name + ".db");
            SQLiteConnection.CreateFile(quiz.Name+".db");

            string connectionString = string.Format("Data Source={0}.db;Version=3;", quiz.Name);
            SQLiteConnection m_dbConnection = new SQLiteConnection(connectionString);
            m_dbConnection.Open();

            string sql = "Create Table Questions (id int PRIMARY KEY, question text)";
            SQLiteCommand command = new SQLiteCommand(sql, m_dbConnection);
            command.ExecuteNonQuery();

            sql = "Create Table Answers (id INTEGER PRIMARY KEY, answer text, isCorrect int, questionId int NOT NULL, FOREIGN KEY (questionId) REFERENCES Questions (id))";
            command = new SQLiteCommand(sql, m_dbConnection);
            command.ExecuteNonQuery();

            for (int i = 0; i < quiz.Questions.Count; i++)
            {
                string questionText = CaesarCipher.Encrypt(quiz.Questions[i].QuestionText,23);
                sql = string.Format("Insert into Questions (id, question) values ({0}, '{1}')", i+1, questionText);
                command = new SQLiteCommand(sql, m_dbConnection);
                command.ExecuteNonQuery();
                for(int j = 0; j < quiz.Questions[i].Answers.Count;j++) 
                {
                    string answerText = CaesarCipher.Encrypt(quiz.Questions[i].Answers[j].AnswerText, 23);
                    sql = string.Format("Insert into Answers (answer, isCorrect, questionId) values ('{0}', {1}, {2})",
                        answerText, quiz.Questions[i].Answers[j].IsCorrect, i+1);
                    command = new SQLiteCommand(sql, m_dbConnection);
                    command.ExecuteNonQuery();
                }
            }


            m_dbConnection.Close();
        }
    }
}
