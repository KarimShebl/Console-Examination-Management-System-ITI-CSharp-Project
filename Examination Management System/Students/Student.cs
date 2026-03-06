using Examination_Management_System.Events;
using System;
using System.Collections.Generic;
using System.Text;

namespace Examination_Management_System.Students
{
    public class Student
    {
        public string Name { get; set; }
        public int Id { get; set; }
        public Student(int id, string name)
        {
            Name = name;
            Id = id;
        }
        public void OnExamStarted(object sender, ExamEventArgs e)
        {
            Console.WriteLine($"Student {Name} notified: Exam for {e.Subject.Name} started.\n\n");
        }

        public override string ToString()
        {
            return $"Id: {Id} - Name: {Name}";
        }

        public override int GetHashCode()
        {
            return HashCode.Combine( Name, Id );
        }

        public override bool Equals(object obj)
        {
            Student? student = obj as Student;
            if (student is null) return false;
            if (this.GetType() != student.GetType()) return false;
            if (Object.ReferenceEquals(this, student)) return true;
            return this.Name == student.Name && this.Id == student.Id;
        }
    }

}
