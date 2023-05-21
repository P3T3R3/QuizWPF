using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizCreator.Model
{
    public class DbReader
    {
        public static Quiz load(string name)
        {

            SQLiteConnection conn = new SQLiteConnection(string.Format("Data Source={0}.db;Version=3;", name));
            conn.Open();
            Quiz quiz = new Quiz(name);

            SQLiteDataReader reader;
            SQLiteCommand command;

            command = conn.CreateCommand();
            command.CommandText = "SELECT * FROM Questions";
            reader = command.ExecuteReader();

            while (reader.Read())
            {
                string que = (string)reader["question"];
                quiz.addQuestion(CaesarCipher.Decrypt(que, 23));
            }

            command = conn.CreateCommand();
            command.CommandText = "SELECT * FROM Answers";
            reader = command.ExecuteReader();
            int i = 0;
            while (reader.Read())
            {
                string answer = (string)reader["answer"];
                bool correct = Convert.ToBoolean((int)reader["isCorrect"]);
                int questionId = (int)reader["questionId"]-1;

                quiz.Questions[questionId].modifyAnswer(i, CaesarCipher.Decrypt(answer,23),correct);
                i++;
                i %= 4;
            }
            conn.Close();
            return quiz;
        }
    }
}
