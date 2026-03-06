using Examination_Management_System.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Examination_Management_System.Exams
{
    public class FinalExam : Exam
    {
        public override object Clone()
        {
            return new FinalExam()
            {
                Time = this.Time,
                NumberOfQuestions = this.NumberOfQuestions,
                Questions = new List<Question>(this.Questions),
                Subject = this.Subject,
            };
        }

        public override bool Equals(object obj)
        {
            FinalExam? exam = obj as FinalExam;
            if (exam is null) return false;
            if (this.GetType() != exam.GetType()) return false;

            if (Object.ReferenceEquals(this, exam)) return true;
            return this.Time == exam.Time && this.Subject == exam.Subject;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Time, Subject);
        }

        public override void ShowExam()
        {
            foreach (var q in Questions)
            {
                q.Display();

                int[] numbers;

                while (true)
                {
                    Console.WriteLine("Enter numbers separated by spaces:");

                    string input = Console.ReadLine();
                    string[] parts = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                    bool valid = true;
                    List<int> temp = new List<int>();

                    foreach (var p in parts)
                    {
                        if (int.TryParse(p, out int num) && num >= 1 && num <= q.Answers.Count)
                        {
                            temp.Add(num);
                        }
                        else
                        {
                            valid = false;
                            break;
                        }
                    }

                    if (valid)
                    {
                        numbers = temp.ToArray();
                        break;
                    }

                    Console.WriteLine($"Invalid input. Please enter only integers between 1 and {q.Answers.Count} separated by spaces.");
                }

                List<Answer> ans = new List<Answer>();
                foreach (int id in numbers)
                {
                    ans.Add(q.Answers.GetById(id));
                }
                QuestionAnswerDictionary[q] = ans;
            }
        }
    }
}
