using Examination_Management_System.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Examination_Management_System.Students
{
    public class Subject
    {
        public string Name { get; set; }
        private int count = 0;
        public Subject(string name)
        {
            this.Name = name;
        }
        public Student[] EnrolledStudents { get; set; } = new Student[10];

        public void Enroll(Student student)
        {
            if (EnrolledStudents.Length >= count)
            {
                Student[] newEnrolledStudents = new Student[EnrolledStudents.Length * 2];
                for (int i = 0; i < EnrolledStudents.Length; i++)
                {
                    newEnrolledStudents[i] = EnrolledStudents[i];
                }
                EnrolledStudents = newEnrolledStudents;
            }
            EnrolledStudents[count] = student;
            count++;
        }


        public override string ToString()
        {
            return Name;
        }

        public override bool Equals(object obj)
        {
            Subject? subject = obj as Subject;
            if (subject is null) return false;
            if (this.GetType() != subject.GetType()) return false;
            if (Object.ReferenceEquals(this, subject)) return true;
            return this.Name == subject.Name;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Name);
        }

    }
}
