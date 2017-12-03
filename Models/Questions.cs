using System;

namespace api.Models{
    public class Question{
        public int QuestionID { get; set; }
        public string QuestionText { get; set; }
        public int CategoryID { get; set; }
        public int AnswerID { get; set; }
        public int SolutionID { get; set; }
    }
}