using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace lesson_8._2
{
    public class Cat : Animal
    {
        private string _name;
        private string _breed;

        public Cat(string name, string breed,
            int age, string type, string voice):
            base(age, type, voice)
        {
            _name = name;
            _breed = breed;
        }
        public Cat() : base()
        {
            _name = "NoName";
            _breed = "NoBreed";
        }
        public override void MakeVoice()
        {
            Console.WriteLine(_voice);
        }
        public override void MakeDeed()
        {
            Console.WriteLine("Sleeping...");
        }
        public override string ToString()
        {
            return $"name: {_name} | Breed: {_breed} |\n" +
                base.ToString();
        }
    }
}
