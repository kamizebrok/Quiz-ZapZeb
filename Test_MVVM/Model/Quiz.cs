using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace test_MVVM.Model
{
    public class Quiz
    {
        public int QuizID { get; set; }
        public Question Question { get; set; }
        public string QuestName { get; set; }
        public Quiz(Question question, string QuestName)
        {
            this.QuestName = QuestName;
            Question = question;
        }
    }
}
