// See https://aka.ms/new-console-template for more information
using static System.Console;
using lesson_8;

Product toy =  new Toy("Pistol", "Toy market", 345, "12-16",
    "China");
toy.Input();
((Toy)toy).AgeCategory = "1-18";
WriteLine("Toy: " + toy.ToString());
