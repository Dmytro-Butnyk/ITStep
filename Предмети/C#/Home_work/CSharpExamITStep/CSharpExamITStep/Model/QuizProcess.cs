using CSharpExamITStep.Entities;
using CSharpExamITStep.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace CSharpExamITStep.Model
{
    public class QuizProcess
    {
        private Player _player = new();
        private Subject _subject = new();

        public QuizProcess() { }
        public QuizProcess(Player player, Subject subject) 
        {
            _player = player;
            _subject = subject;
        }
        public QuizProcess(Player player)
        {
            _player = player;
        }
        public Subject Subject
        {
            get { return _subject; }
            set { _subject = value; }
        }

        public void StartQuiz()
        {
            int correct, wrong;
            (correct, wrong) = _subject.QuestionAnswer();

            _player.QuizResults.Add(new QuizResult(_subject.Subjects, correct, wrong));
            
        }
        public void ShowResults()
        {
            _player.ShowResults();
        }
        public void ShowTop(UserManager userManager)
        {
            Subjects subject;

        //
        D:
            WriteLine("Enter" +
                "\n1 - Math;" +
                "\n2 - Environment;" +
                "\n3 - Geography:");
            switch (ReadKey(true).Key)
            {
                case ConsoleKey.D1:
                    {
                        subject = Subjects.Math;
                        break;
                    }
                case ConsoleKey.D2:
                    {
                        subject = Subjects.Environment;
                        break;
                    }
                case ConsoleKey.D3:
                    {
                        subject = Subjects.Geography;
                        break;
                    }
                default:
                    {
                        WriteLine("Wrong choice!");
                        goto D;
                    }
            }
            List<QuizResult> allResults = userManager.Players
                .SelectMany(p => p.QuizResults
                .Where(x => x.Subject == subject))
                .ToList();

            List<QuizResult> top20Results = allResults
                .OrderByDescending(r => r.Percent)
                .Take(20)
                .ToList();
            WriteLine($"Top 20 of best results in {subject}");
            WriteLine(string.Join("\n", top20Results));
        }
    }
}