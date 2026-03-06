using System;
using System.Collections.Generic;
using System.Text;

namespace Examination_Management_System.Models
{
    public class Answer
    {
        public int Id { get; set; }
        public string Text { get; set; }

        public Answer() 
        {
            Id = 0;
            Text = string.Empty;
        }
        public Answer(int id, string txt) 
        {
            Id = id;
            Text = txt;
        }

        public override string ToString()
        {
            return Text;
        }

        public override bool Equals(object obj)
        {
            Answer? answer = obj as Answer;
            if (answer is null) return false;
            if (this.GetType() != answer.GetType()) return false;

            if (Object.ReferenceEquals(this, answer)) return true;
            return this.Text == answer.Text;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Id, Text);
        }
    }

}
