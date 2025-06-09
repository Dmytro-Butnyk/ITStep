using hw_13;
using static System.Console;

// task 1

Aquarium aquarium = new Aquarium();
aquarium.AddInhabitant(new Fish());
aquarium.AddInhabitant(new Turtle());
aquarium.AddInhabitant(new Shark());

foreach (SeaCreature creature in aquarium)
{
    WriteLine(creature.Type);
}

// task 2

FootballTeam team = new FootballTeam();
team.AddPlayer(new FootballPlayer { Name = "Player 1" });
team.AddPlayer(new FootballPlayer { Name = "Player 2" });

foreach (FootballPlayer player in team)
{
    WriteLine(player.Name);
}

