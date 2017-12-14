using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using api.Models;
using Dapper;

namespace api.Data{
    public class QuestionRep{

        private readonly string connectionString;
        private IDbConnection _connection{get { return new SqlConnection(connectionString);}}
        public QuestionRep(){
          
            connectionString = "Data Source=.;Initial Catalog=OkulYolu;Integrated Security=true";
        }

        public List<dynamic> GetAllQuestions(){
            using(IDbConnection _dbConnection = _connection){
                string query=@"select * from dbo.Question";
                var _questionList = _dbConnection.Query(query);
                return _questionList.ToList();   
            }
        }
        public List<dynamic> GetQuestion(int id){
            using(IDbConnection _dbConnection = _connection){
                string query=@"select q.questionText Text, c.choise, c.text, c.correctAnswer Answer  
                               from question q inner join choises c on q.questionID=c.questionID where q.questionID=@id";
                var _questionList = _dbConnection.Query(query,new {id=id});
                return _questionList.ToList();   
            }
        }
        
        public void AddQuestion(Question _question){
            using(IDbConnection _dbConnection = _connection){
                string query = @"insert into Question (
                    [questionText],
                    [catID],
                    [solutionID]) values(
                        @QuestionText,
                        @CatID,
                        @SolutionID)";
                var affectedRows = _connection.Execute(query,_question);
            }
        } 

        public List<dynamic> GetSolution(int id){
            using(IDbConnection _dbConnection = _connection){
                string query = "select s.solutionText from Solution s, Question q where q.questionID=@id and q.solutionID=s.solutionID";
                var answer = _dbConnection.Query(query);
                return answer.ToList();
            }
        }
    }
}