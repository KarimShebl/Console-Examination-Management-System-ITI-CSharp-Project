using Examination_Management_System.Exams;
using Examination_Management_System.Models;
using Examination_Management_System.Students;

namespace Examination_Management_System
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Subject subject = new Subject("Programming");

            Student s1 = new Student(1, "Karim");
            Student s2 = new Student(2, "Sara");

            subject.Enroll(s1);
            subject.Enroll(s2);

            Exam practice = new PracticeExam()
            {
                Time = 60,
                NumberOfQuestions = 10,
                Subject = subject
            };

            Exam final = new FinalExam()
            {
                Time = 60,
                NumberOfQuestions = 10,
                Subject = subject
            };
            practice.ExamStarted += s1.OnExamStarted;
            practice.ExamStarted += s2.OnExamStarted;

            #region Questions
            TrueFalseQuestion q1 = new TrueFalseQuestion("Q1", "C# is a compiled language?", 5);
            q1.Answers.Add(new Answer(1, "True"));
            q1.Answers.Add(new Answer(2, "False"));
            q1.CorrectAnswer.Add(q1.Answers.GetById(1));

            ChooseOneQuestion q2 = new ChooseOneQuestion("Q2", "What is the base class for all classes in C#?", 5);
            q2.Answers.Add(new Answer(1, "Object"));
            q2.Answers.Add(new Answer(2, "System"));
            q2.Answers.Add(new Answer(3, "Base"));
            q2.Answers.Add(new Answer(4, "None"));
            q2.CorrectAnswer.Add(q2.Answers.GetById(1));

            ChooseAllQuestion q3 = new ChooseAllQuestion("Q3", "Which of the following are access modifiers in C#?", 5);
            q3.Answers.Add(new Answer(1, "public"));
            q3.Answers.Add(new Answer(2, "private"));
            q3.Answers.Add(new Answer(3, "protected"));
            q3.Answers.Add(new Answer(4, "internal"));
            q3.Answers.Add(new Answer(5, "friend"));
            q3.CorrectAnswer.Add(q3.Answers.GetById(1));
            q3.CorrectAnswer.Add(q3.Answers.GetById(2));
            q3.CorrectAnswer.Add(q3.Answers.GetById(3));
            q3.CorrectAnswer.Add(q3.Answers.GetById(4));

            TrueFalseQuestion q4 = new TrueFalseQuestion("Q4", "C# supports multiple inheritance for classes?", 5);
            q4.Answers.Add(new Answer(1, "True"));
            q4.Answers.Add(new Answer(2, "False"));
            q4.CorrectAnswer.Add(q4.Answers.GetById(2));

            ChooseOneQuestion q5 = new ChooseOneQuestion("Q5", "What does CLR stand for in .NET?", 5);
            q5.Answers.Add(new Answer(1, "Common Language Runtime"));
            q5.Answers.Add(new Answer(2, "Compiled Language Resource"));
            q5.Answers.Add(new Answer(3, "Core Library Runtime"));
            q5.Answers.Add(new Answer(4, "Common Loop Runtime"));
            q5.CorrectAnswer.Add(q5.Answers.GetById(1));

            ChooseAllQuestion q6 = new ChooseAllQuestion("Q6", "Which of the following are value types in C#?", 5);
            q6.Answers.Add(new Answer(1, "int"));
            q6.Answers.Add(new Answer(2, "string"));
            q6.Answers.Add(new Answer(3, "class"));
            q6.Answers.Add(new Answer(4, "struct"));
            q6.Answers.Add(new Answer(5, "enum"));
            q6.CorrectAnswer.Add(q6.Answers.GetById(1));
            q6.CorrectAnswer.Add(q6.Answers.GetById(4));
            q6.CorrectAnswer.Add(q6.Answers.GetById(5));

            TrueFalseQuestion q7 = new TrueFalseQuestion("Q7", "Interfaces in C# can contain constructors?", 5);
            q7.Answers.Add(new Answer(1, "True"));
            q7.Answers.Add(new Answer(2, "False"));
            q7.CorrectAnswer.Add(q7.Answers.GetById(2));

            ChooseOneQuestion q8 = new ChooseOneQuestion("Q8", "Which keyword is used for inheritance in C#?", 5);
            q8.Answers.Add(new Answer(1, "extends"));
            q8.Answers.Add(new Answer(2, "inherits"));
            q8.Answers.Add(new Answer(3, ":"));
            q8.Answers.Add(new Answer(4, "base"));
            q8.CorrectAnswer.Add(q8.Answers.GetById(3));

            ChooseAllQuestion q9 = new ChooseAllQuestion("Q9", "Which are core pillars of Object-Oriented Programming (OOP) supported in C#?", 5);
            q9.Answers.Add(new Answer(1, "Encapsulation"));
            q9.Answers.Add(new Answer(2, "Inheritance"));
            q9.Answers.Add(new Answer(3, "Polymorphism"));
            q9.Answers.Add(new Answer(4, "Abstraction"));
            q9.Answers.Add(new Answer(5, "Compilation"));
            q9.CorrectAnswer.Add(q9.Answers.GetById(1));
            q9.CorrectAnswer.Add(q9.Answers.GetById(2));
            q9.CorrectAnswer.Add(q9.Answers.GetById(3));
            q9.CorrectAnswer.Add(q9.Answers.GetById(4));

            TrueFalseQuestion q10 = new TrueFalseQuestion("Q10", "C# is a case-sensitive programming language?", 5);
            q10.Answers.Add(new Answer(1, "True"));
            q10.Answers.Add(new Answer(2, "False"));
            q10.CorrectAnswer.Add(q10.Answers.GetById(1));            
            #endregion


            Console.WriteLine("Select Exam Type");
            Console.WriteLine("1 - Practice");
            Console.WriteLine("2 - Final");

            int choice;

            while (true)
            {
                Console.Write("Enter your choice (1-2): ");

                if (int.TryParse(Console.ReadLine(), out choice) && choice >= 1 && choice <= 2)
                    break;

                Console.WriteLine("Invalid choice. Please enter a number between 1 and 2.");
            }

            Exam exam = choice == 1 ? practice : new FinalExam();

            exam.Questions.Add(q1);
            exam.Questions.Add(q2);
            exam.Questions.Add(q3);
            exam.Questions.Add(q4);
            exam.Questions.Add(q5);
            exam.Questions.Add(q6);
            exam.Questions.Add(q7);
            exam.Questions.Add(q8);
            exam.Questions.Add(q9);
            exam.Questions.Add(q10);

            exam.Start();

            exam.ShowExam();

            exam.Finish();
        }
    }
}
