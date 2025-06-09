using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CSharpExamITStep.Enums;
using Newtonsoft.Json;
using Newtonsoft.Json.Schema;
using static System.Console;


namespace CSharpExamITStep.Entities
{
    public class Subject
    {
        private Subjects _subjects = Subjects.Math;
        private Dictionary<string, string> _questions = new();
        private List<string> _answers = new();
        public Subject() { }
        public Subject(Subjects subject, Dictionary<string, string> questions, List<string> answers)
        {
            _subjects = subject;
            _questions = questions;
            _answers = answers;
        }
        public Subject(Subjects subject)
        {
            _subjects = subject;
            string questions, answers;
            switch (_subjects)
            {
                case Subjects.Math:
                    {
                        questions = File.ReadAllText("Subjects/Math/Questions.json");
                        answers = File.ReadAllText("Subjects/Math/Answers.json");
                        break;
                    }
                case Subjects.Environment:
                    {
                        questions = File.ReadAllText("Subjects/Environment/Questions.json");
                        answers = File.ReadAllText("Subjects/Environment/Answers.json");
                        break;
                    }
                case Subjects.Geography:
                    {
                        questions = File.ReadAllText("Subjects/Geography/Questions.json");
                        answers = File.ReadAllText("Subjects/Geography/Answers.json");
                        break;
                    }
                default:
                    {
                        throw new Exception("Undefined subject type.");
                    }
            }
            _questions = JsonConvert.DeserializeObject<Dictionary<string, string>>(questions);
            _answers = JsonConvert.DeserializeObject<List<string>>(answers);
        }
        public Subjects Subjects
        {
            get { return _subjects; }
            set
            {
                _subjects = value;
            }
        }
        public Dictionary<string, string> Questions
        {
            get { return _questions; }
            set { _questions = value; }
        }
        public List<string> Answers
        {
            get { return _answers; }
            set
            {
                _answers = value;
            }
        }

        public (int, int) QuestionAnswer()
        {
            const int NumQ = 3;
            int correct = 0, wrong = 0;
            for (int i = 0; i < NumQ; ++i)
            {
                WriteLine($"Question number {i}:");
                WriteLine(_questions.Keys.ElementAt(i));
                WriteLine(_questions.Values.ElementAt(i));
                Write("Enter your answer: ");
                if (ReadLine() == _answers[i])
                {
                    correct++;
                    WriteLine("Correct!");
                }
                else
                {
                    wrong++;
                    WriteLine("Wrong.");
                }
            }
            return (correct, wrong);
        }

        public override string ToString()
        {
            return $"Subject name: {_subjects} | " +
                $"Questions:\n{string.Join("\n", _questions.Select(q => $"Question: {q.Key}, Options: {q.Value}"))} | " +
                $"Answers:\n{string.Join("\n", _answers.Select((item, index) => $"{index + 1}. {item}"))}";
        }
    }
}
