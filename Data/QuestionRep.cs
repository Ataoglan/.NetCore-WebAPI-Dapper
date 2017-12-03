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
                string query=@"select q.questionText Text,a.answerText1 Ans1,a.answerText2 Ans2, a.answerText3 Ans3 ,a.trueAnswerNumber Cevap  
                               from question q inner join answer a on q.answerID=a.answerID where q.questionID="+id;
                var _questionList = _dbConnection.Query(query);
                return _questionList.ToList();   
            }
        }

    }
}