using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace Examination_Management_System.Models
{
    public class AnswerList
    {
        private Answer?[] answers = new Answer[4];

        public int Count { get; set; }

        public void Add(Answer answer)
        {
            if(answers.Length >= Count)
            {
                Answer[] newAnswers = new Answer[answers.Length * 2];
                for (int i = 0; i < answers.Length; i++)
                {
                    newAnswers[i] = answers[i];
                }
                answers = newAnswers;
            }
            answers[Count] = answer;
            Count++;
        }

        public Answer? GetById(int id)
        {
            Answer? answer = null;
            for (int i = 0; i < Count; i++)
            {
                if (answers?[i]?.Id == id)
                {
                    answer = answers[i];
                    break;
                }
            }
            return answer;
        }

        public Answer? this[int index]
        {
            get { return index < Count ? answers?[index] : null; }
            set { }
        }
    }

}
