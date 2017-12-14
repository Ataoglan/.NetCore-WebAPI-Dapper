using System;

namespace api.Models{
    public class Answer{
        public int ChoiseID { get; set; }
        public int questionID { get; set; }
        public int Choise { get; set; }
        public string Text { get; set; }
        public string CorrectAnswer { get; set; }
    }
}