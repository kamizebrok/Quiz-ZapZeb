using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace test_MVVM.Model
{
    public class Question
    {
        public string QuestionID { get; set; }
        public string Quest { get; set; }
        public string AnswerA { get; set; }
        public string AnswerB { get; set; }
        public string AnswerC { get; set; }
        public string AnswerD { get; set; }
        public string CorrectAnswer { get; set; }
        public Question(string QuestionID, string Quest) { this.QuestionID = QuestionID; this.Quest = Quest; }
    }
}
