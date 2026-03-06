using System;
using System.Collections.Generic;
using System.Text;
using Examination_Management_System.Exams;
using Examination_Management_System.Students;

namespace Examination_Management_System.Events
{
    public class ExamEventArgs : EventArgs
    {
        public Subject Subject { get; }
        public Exam Exam { get; }

        public ExamEventArgs(Subject subject, Exam exam)
        {
            Subject = subject;
            Exam = exam;
        }
    }

}
