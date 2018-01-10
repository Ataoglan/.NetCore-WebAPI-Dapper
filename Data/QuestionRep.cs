using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using api.Models;
using Dapper;

namespace api.Data
{
    public class QuestionRep
    {

        private readonly string connectionString;
        private IDbConnection _connection { get { return new SqlConnection(connectionString); } }
        public QuestionRep()
        {

            connectionString = "Data Source=.;Initial Catalog=YourDBName;Integrated Security=true";
        }

        public List<dynamic> GetAllQuestions()
        {
            using (IDbConnection _dbConnection = _connection)
            {
                string query = @"select * from dbo.Question";
                var _questionList = _dbConnection.Query(query);
                return _questionList.ToList();
            }
        }
        public Question GetQuestion(int id)
        {
            using (IDbConnection _dbConnection = _connection)
            {
                string query = @"select q.questionText Text, c.choise, c.text, c.correctAnswer Answer  
                               from question q inner join choises c on q.questionID=c.questionID where q.questionID=@id";
                var _questionList = _dbConnection.Query(query, new { id = id });

                if (!_questionList.Any())
                    return null;
                var question = new Question()
                {
                    QuestionText = _questionList.FirstOrDefault().Text,
                    Choises = _questionList.Select(
                        item =>
                        {
                            return new Choises()
                            {
                                questionID = id,
                                Choise = item.choise,
                                Text = item.text,
                                CorrectAnswer = item.Answer
                            };
                        })

                };
                return question;
            }
        }
    }
}
