// See https://aka.ms/new-console-template for more information

using lesson_8._2;
using System.Xml.Serialization;

Animal[] animals =
{
    new Cat("Mario", "Ragdoll", 5, "pet", "Mya ^_^"),
    new Tiger(54, 14, "predator", "R-rooar >o<"),
    new Deer("Podoroznick", 5, "travoyadnoe", "EEEEAAAAAAAA 0o0")
};
int choise = 1;
while (choise != 0)
{
    Console.WriteLine("Enter:\n" +
        "1 - to hear voices\n" +
        "2 - to find out what animals are doing\n" +
        "3 - to show animals\n" +
        "0 - exit");
    choise = int.Parse(Console.ReadLine()?? "0"); 
    switch (choise)
    {
            case 1:
            {
                foreach (Animal animal in animals)
                {
                    animal.MakeVoice();
                }
                break;
            }
            case 2:
            {
                foreach (Animal animal in animals)
                {
                    animal.MakeDeed();
                }
                break;
            }
            case 3:
            {
                foreach (Animal animal in animals)
                {
                    animal.ToString();
                }
                break;
            }
            default:
            {
                return;
            }
    }
    Console.ReadKey();
    Console.Clear();
}