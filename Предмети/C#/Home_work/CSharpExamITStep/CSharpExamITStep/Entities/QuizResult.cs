using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CSharpExamITStep.Enums;

namespace CSharpExamITStep.Entities
{
    public class QuizResult
    {
        private Subjects _subject = Subjects.Math;
        private int _correct = 0;
        private int _wrong = 0;
        private double _percent = 0;

        public QuizResult() { }
        public QuizResult(Subjects subject, int correct, int wrong)
        {
            _subject = subject;
            _correct = correct;
            _wrong = wrong;
            CountPercent(_correct, _wrong);
        }

        public Subjects Subject
        {
            get { return _subject; }
            set { _subject = value; }
        }
        public int Correct
        {
            get { return _correct; }
            set
            {
                _correct = value;
                CountPercent(_correct, _wrong);
            }
        }
        public int Wrong
        {
            get { return _wrong; }
            set
            {
                _wrong = value;
                CountPercent(_correct, _wrong);
            }
        }
        public double Percent
        {
            get { return _percent; }
            set { _percent = value; }
        }
        private void CountPercent(int c, int w)
        {
            if(c == 0) 
                _percent = 0;
            else
            _percent = 100 * c / (c + w);
        }

        public override string ToString()
        {
            return $"Subject: {_subject} - Correct: {_correct} - Wrong: {_wrong} - Percent of correct: {_percent}";
        }
    }
}
