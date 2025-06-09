// See https://aka.ms/new-console-template for more information
using Dapper;
using FootballChampionshipDB;
using Microsoft.Data.SqlClient;
using System.Transactions;
using static System.Console; 


string connString = @"Data Source=(localdb)\MSSQLLocalDB;
Initial Catalog=FootballChampionship;
Integrated Security=True;";


using (SqlConnection connection = new(connString))
{
    var teams = connection.Query<Team>("Select * from Team").ToList();
    teams.ForEach(WriteLine);
    #region Task 1
    /*
        // 1
        Write("Enter team name: ");
        var teamName = ReadLine();
        WriteLine(connection.QueryFirst<Team>($"Select * from Team" +
            $" Where Name = '{teamName}'"));
        // 2
        Write("Enter city name: ");
        var cityName = ReadLine();
        WriteLine(connection.QueryFirst<string>("Select Team.Name" +
            " from Team" +
            $" inner join City on Team.CityId = City.Id" +
            $" Where City.Name = '{cityName}'"));
        // 3
        Write("Enter team name: ");
        var tName = ReadLine();
        Write("Enter city name: ");
        var cName = ReadLine();
        WriteLine(connection.QueryFirst<string>(
        $"SELECT Team.Name " +
        $"FROM Team " +
        $"INNER JOIN City ON Team.CityId = City.Id " +
        $"WHERE Team.Name = '{tName}' AND City.Name = '{cName}'"));
    */
    #endregion

    #region Task 2
    /*
    // 1
    WriteLine("Max number of wins:");
    WriteLine(connection.QueryFirst<Team>(
        $"select * from Team " +
        $"where Wins = (Select max(wins) from Team)"));
    // 2
    WriteLine("Max number of draws:");
    WriteLine(connection.QueryFirst<Team>(
        $"Select * from Team " +
        $"where Draws = (Select max(draws) from Team)"));
    // 3
    WriteLine("Max number of goals");
    WriteLine(connection.QueryFirst<Team>(
        $"select * from Team " +
        $"where Goals = (Select max(goals) from Team)"));
    // 4
    WriteLine("Max number of missed goals:");
    WriteLine(connection.QueryFirst<Team>(
        $"select * from Team " +
        $"where MissedGoals = (Select max(MissedGoals) from Team)"));
    */
    #endregion

    #region Task 3
    // 1
    Write("Enter team name: ");
    var tName = ReadLine();
    Write("Enter city id: ");
    int.TryParse(ReadLine(), out var tCityId);
    Write("Enter wins: ");
    int.TryParse(ReadLine(), out var tWins);
    Write("Enter draws: ");
    int.TryParse(ReadLine(), out var tDraws);
    Write("Enter goals: ");
    int.TryParse(ReadLine(), out var tGoals);
    Write("Enter missed goals: ");
    int.TryParse(ReadLine(), out var tMissedGoals);
    Team nTeam = new Team(tName, tCityId, tWins, tDraws, tGoals, tMissedGoals);

    if ( !teams.Any(x => x.Name == tName && x.CityId == tCityId))
    {
        int rowsAffected = connection.Execute($"insrt into Team " +
            $"(Name, CityId, Wins, Draws, Goals, MissedGoals)" +
            $"values (@Name, @CityId, @Wins, @Draws, @Goals, @MissedGoals)", nTeam);

        if (rowsAffected > 0)
        {
            WriteLine("New team added successfully.");
        }
        else
        {
            WriteLine("Failed to add new team.");
        }
    }
    #endregion 

}