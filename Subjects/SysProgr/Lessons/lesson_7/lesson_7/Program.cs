using lesson_7;

Team team1 = new Team("Team_1", 50);
Team team2 = new Team("Team_2", 50);
Team team3 = new Team("Team_3", 50);

Confrontation confrontation = new Confrontation(new List<Team>{team1, team2, team3});
confrontation.StartBattle();

Console.WriteLine("Press any key to stop the battle...");
Console.ReadKey();
confrontation.StopBattle();

Console.WriteLine("Battle is stoped.");
Console.ReadKey();