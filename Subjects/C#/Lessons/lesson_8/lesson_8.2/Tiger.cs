using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lesson_8._2
{
    public class Tiger : Animal
    {
        private int _countLines;

        public Tiger() : base()
        {
            _countLines = 0;
        }
        public Tiger(int countLines,
            int age, string type, string voice):
            base(age, type, voice)
        {
            _countLines = countLines;
        }
        public override void MakeVoice()
        {
            Console.WriteLine(_voice);
        }
        public override void MakeDeed()
        {
            Console.WriteLine("Hunting...");
        }
        public override string ToString()
        {
            return base.ToString() +
                $"|\n Number of lines: {_countLines}";
        }
    }
}
