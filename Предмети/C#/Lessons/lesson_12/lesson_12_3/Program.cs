// See https://aka.ms/new-console-template for more information

using lesson_12_3;

Cafe cafe = new Cafe();

cafe.Arrive("1");
cafe.Arrive("2");
cafe.Arrive("3");
cafe.Arrive("4");
cafe.Arrive("5");
cafe.Arrive("6");
cafe.Arrive("7", true);

cafe.Leave();
cafe.Leave();
    