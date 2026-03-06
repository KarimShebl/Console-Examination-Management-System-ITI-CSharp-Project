using System;
using System.Collections.Generic;
using System.Text;

namespace Examination_Management_System.Models
{
    public class ChooseOneQuestion : Question
    {
        public ChooseOneQuestion() : base() { }

        public ChooseOneQuestion(string header, string body, int marks) : base(header, body, marks) { }
        public override void Display()
        {
            System.Console.WriteLine(ToString());
        }

        public override bool CheckAnswer(List<Answer> studentAnswer)
        {
            int correct = 0;
            CorrectAnswer.ForEach(ans =>
            {
                if (studentAnswer.Contains(ans))
                    correct++;
            });
            return correct == CorrectAnswer.Count;
        }
    }

}
