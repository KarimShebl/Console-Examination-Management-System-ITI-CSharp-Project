using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace Examination_Management_System.Models
{
    public class QuestionList : List<Question>
    {
        private string fileName;

        public QuestionList(string fileName)
        {
            this.fileName = fileName;
        }

        public new void Add(Question question)
        {
            base.Add(question);

            using (StreamWriter sw = new StreamWriter(fileName, true))
            {
                sw.WriteLine(question.ToString());
            }
        }
    }

}
