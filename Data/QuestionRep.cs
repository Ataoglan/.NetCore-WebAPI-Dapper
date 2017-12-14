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

            connectionString = "Data Source=.;Initial Catalog=OkulYolu;Integrated Security=true";
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
                               from question q inner join choises c on q.questionID=c.questionID where q.questionID=@xyz";
                var _questionList = _dbConnection.Query(query, new { xyz = id });

                if (!_questionList.Any())
                    return null;
                var question = new Question()
                {
                    QuestionText = _questionList.FirstOrDefault().Text,
                    Choises = _questionList.Select(
                        xxx =>
                        {
                            return new Choises()
                            {
                                questionID = id,
                                Choise = xxx.choise,
                                Text = xxx.text,
                                CorrectAnswer = xxx.Answer
                            };
                        })

                };
                //linq


                return question;
            }
        }

        public void AddQuestion(Question _question)
        {
            using (IDbConnection _dbConnection = _connection)
            {
                string query = @"insert into Question (
                    [questionText],
                    [catID],
                    [solutionID]) values(
                        @QuestionText,
                        @CatID,
                        @SolutionID)";
                var affectedRows = _connection.Execute(query, _question);
            }
        }

        public Solution GetSolution(int id)
        {
            using (IDbConnection _dbConnection = _connection)
            {
                string query = "select s.solutionText from Solution s, Question q where q.questionID=@xyz and q.solutionID=s.solutionID";
                var solution = _dbConnection.QueryFirstOrDefault<Solution>(query, new { xyz = id });
                solution.SolutionID = id;
                return solution;
            }
        }
    }
}