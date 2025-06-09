using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;
namespace lesson_8._2
{
    public abstract class Animal
    {
        protected int _age;
        protected string _type;
        protected string _voice;

        public Animal()
        {
            _age = 0;
            _type = "NoType";
            _voice = "NoVoice";
        }
        public Animal(int age, string type, string voice)
        {
            _age = age;
            _type = type;
            _voice = voice;
        }
        public abstract void MakeVoice();
        public virtual void MakeDeed()
        {
            WriteLine("Some deed");
        }

        public override string ToString()
        {
            return $"Age: {_age} | Type: {_type}";
        }
    }
}
