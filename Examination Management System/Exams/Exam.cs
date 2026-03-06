using Examination_Management_System.Events;
using Examination_Management_System.Models;
using Examination_Management_System.Students;
using System;
using System.Collections.Generic;
using System.Text;

namespace Examination_Management_System.Exams
{

    public abstract class Exam : ICloneable
    {
        public int Time { get; set; }
        public int NumberOfQuestions { get; set; }
        public List<Question> Questions { get; set; } = new List<Question>();
        public Dictionary<Question, List<Answer>> QuestionAnswerDictionary { get; set; } = new Dictionary<Question, List<Answer>>();
        public Subject Subject { get; set; }
        public int Grade { get; set; }
        public ExamMode Mode { get; set; }

        public event ExamStartedHandler ExamStarted;

        public abstract void ShowExam();

        public virtual void Start()
        {
            Mode = ExamMode.Starting;
            ExamStarted?.Invoke(this, new ExamEventArgs(Subject, this));
        }

        public virtual void Finish()
        {
            Mode = ExamMode.Finished;
            CorrectExam();
            Console.WriteLine($"Final Grade = {Grade}");
        }

        public void CorrectExam()
        {
            int ind = 1;
            foreach (var pair in QuestionAnswerDictionary)
            {
                if (pair.Key.CheckAnswer(pair.Value)){
                    Grade += pair.Key.Marks;
                }
                StringBuilder stAns = new StringBuilder();
                foreach (var answer in pair.Value)
                    stAns.Append(answer?.Id.ToString() + " ");

                StringBuilder correctAns = new StringBuilder();
                foreach (var answer in pair.Key.CorrectAnswer)
                    correctAns.Append(answer?.Id.ToString() + " ");

                Console.WriteLine($"Question{ind++}:\nStudent Answered: {stAns}\nCorrect Answer: {correctAns}\n\n");
            }
        }

        public abstract object Clone();

        public override string ToString()
        {
            return $"Time: {Time} - Questions: {NumberOfQuestions}";
        }
        public abstract override bool Equals(object obj);


        public abstract override int GetHashCode();
    }

}
