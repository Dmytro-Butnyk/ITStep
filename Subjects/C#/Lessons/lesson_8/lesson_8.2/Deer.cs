using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lesson_8._2
{
    public class Deer : Animal
    {
        private string _lovelyLeafs;

        public Deer(string lovelyLeafs,
            int age, string type, string voice):
            base(age, type, voice)
        {
            _lovelyLeafs = lovelyLeafs;
        }
        public override void MakeDeed()
        {
            Console.WriteLine("Running out of predator...");
        }
        public override void MakeVoice()
        {
            Console.WriteLine(_voice);
        }
        public override string ToString()
        {
            return base.ToString() + 
                $"|\nLovely leafs: {_lovelyLeafs}";
        }
    }
}
