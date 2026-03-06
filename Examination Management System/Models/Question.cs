using System;
using System.Collections.Generic;
using System.Text;

namespace Examination_Management_System.Models
{
    public abstract class Question
    {
        public string Header { get; set; }
        public string Body { get; set; }
        public int Marks { get; set; }
        public AnswerList Answers { get; set; } = new AnswerList();
        public List<Answer> CorrectAnswer { get; set; } = new List<Answer>();

        protected Question()
        {
            Header = string.Empty;
            Body = string.Empty;
            Marks = 0;
        }

        protected Question(string header, string body, int marks)
        {
            Header = header;
            Body = body;
            Marks = marks;
        }

        public abstract void Display();

        public abstract bool CheckAnswer(List<Answer> studentAnswer);

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < Answers?.Count; i++)
            {
                if(Answers[i] is null) break;
                sb.AppendLine((i + 1).ToString() + ") " + Answers[i]);
            }
            return $"Header: {Header}        Marks: {Marks}\nBody: {Body}\nChoices: \n{sb}\nEnter the answer ID. If multiple choices are correct, separate them with spaces (e.g., 1 2 3).";
        }

        public override bool Equals(object obj)
        {
            Question? question = obj as Question;
            if (question is null) return false;
            if(this.GetType() != question.GetType()) return false;

            if(Object.ReferenceEquals(this, question)) return true;
            return this.Header == question.Header && this.Body == question.Body;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }

}
