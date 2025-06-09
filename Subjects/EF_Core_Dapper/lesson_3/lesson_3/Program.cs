// See https://aka.ms/new-console-template for more information
using static System.Console;
using lesson_3;
using lesson_3.DBTables;
using Microsoft.EntityFrameworkCore;
using lesson_3.Model;
using System.Transactions;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;


{
    try
    {
        //    List<GameStudio> gameStudios = new List<GameStudio>
        //{
        //    new GameStudio{ Name = "4A", Rating = 10},
        //    new GameStudio{ Name = "SquareEnix", Rating = 1},
        //    new GameStudio{ Name = "Valve", Rating = 7}
        //};
        //    foreach (GameStudio gameStudio in gameStudios)
        //    {
        //        context.Add(gameStudio);
        //    }
        //    List<Genre> genres = new List<Genre>
        //{
        //    new Genre{ Name = "Moba" },
        //    new Genre{ Name = "RPG" },
        //    new Genre{ Name = "Shooter" }
        //};
        //    foreach (Genre genre in genres)
        //    {
        //        context.Add(genre);
        //    }

        //    List<Game> games = new List<Game>
        //    { 
        //    new Game
        //    { Name = "Metro Exodus",
        //      GameStudio = gameStudios[0],
        //      Genre = genres[2],
        //      ReleaseDate = new DateTime(2018, 3, 5)
        //    },

        //    new Game
        //    { Name = "Nier:Automata",
        //      GameStudio = gameStudios[1],
        //      Genre = genres[1],
        //      ReleaseDate = new DateTime(2017, 12, 17)
        //    },
        //    new Game
        //    { Name = "Dota 2",
        //      GameStudio = gameStudios[2],
        //      Genre = genres[0],
        //      ReleaseDate = new DateTime(2012, 5, 26)
        //    }
        //    };
        //    foreach (Game game in games)
        //    {
        //        context.Add(game);
        //    }
        //    context.SaveChanges();

        //context.Games.FirstOrDefault(x => x.Name == "Metro Exodus").PlayMode = PlayMode.Singleplayer;
        //context.Games.FirstOrDefault(x => x.Name == "Nier:Automata").PlayMode = PlayMode.Singleplayer;
        //context.Games.FirstOrDefault(x => x.Name == "Dota 2").PlayMode = PlayMode.Multiplayer;
        //context.SaveChanges();

        //context.Games.FirstOrDefault(x => x.Name == "Metro Exodus").CopiesSold = 8500000;
        //context.Games.FirstOrDefault(x => x.Name == "Nier:Automata").CopiesSold = 7500000;
        //context.Games.FirstOrDefault(x => x.Name == "Dota 2").CopiesSold = 350000000;
        //context.SaveChanges();

        while (true)
        {
            WriteLine("Press\n" +
                "1 - To task 1;\n" +
                "2 - To task 2;\n" +
                "3 - To task 3;\n" +
                "0 - To exit:");
            switch (ReadKey(true).Key)
            {
                case ConsoleKey.D1:
                    {
                        goto A;
                    }
                case ConsoleKey.D2:
                    {
                        goto B;
                    }
                case ConsoleKey.D3:
                    {
                        goto C;
                    }
                case ConsoleKey.D0:
                    {
                        Environment.Exit(0);
                        break;
                    }
                default:
                    {
                        continue;
                    }
            }

            // task 1
            A:
            WriteLine("Press\n" +
                "1 - To show game information;\n" +
                "2 - To search games by studio;\n" +
                "3 - To search by game and studio names;\n" +
                "4 - To search games by genre;\n" +
                "5 - To search games by the year of release;\n" +
                "0 - Exit:");
            switch (ReadKey(true).Key)
            {
                case ConsoleKey.D1:
                    {
                        Write("Enter name of the game: ");
                        DBManger.ShowGame(ReadLine());
                        break;
                    }
                case ConsoleKey.D2:
                    {
                        Write("Enter studio name: ");
                        DBManger.SearchByStudio(ReadLine());
                        break;
                    }
                case ConsoleKey.D3:
                    {
                        string gName, sName;
                        Write("Enter name of the game: ");
                        gName = ReadLine();
                        Write("Enter studio name: ");
                        sName = ReadLine();

                        DBManger.SearchByGameAndStudio(gName, sName);
                        break;
                    }
                case ConsoleKey.D4:
                    {
                        Write("Enter genre: ");
                        DBManger.SearchByGenre(ReadLine());
                        break;
                    }
                case ConsoleKey.D5:
                    {
                        Write("Enter the year of release: ");
                        DBManger.SearchByYear(ReadLine());
                        break; 
                    }
                case ConsoleKey.D0:
                    {
                        Environment.Exit(0);
                        break;
                    }
                default:
                    {
                        WriteLine("Wrong option!");
                        break;
                    }
            }
            continue;

        // task 2
        B:

            WriteLine("Press\n" +
                "1 - Show singleplayer games\n" +
                "2 - Show multipplayer games\n" +
                "3 - Show bestseller\n" +
                "4 - Show 3 less sold games:");

            switch (ReadKey(true).Key)
            {
                case ConsoleKey.D1:
                    {
                        WriteLine("\nSingleplayer games:");
                        DBManger.ShowSingleplayerGames();

                        break;
                    }
                case ConsoleKey.D2:
                    {
                        WriteLine("\nMultiplayer games:");
                        DBManger.ShowMultiplayerGames();

                        break;
                    }
                case ConsoleKey.D3:
                    {
                        WriteLine("\nBestseller:");
                        DBManger.ShowBestSeller();

                        break;
                    }
                case ConsoleKey.D4:
                    {
                        WriteLine("\nTop 3 less sold games:");
                        DBManger.ShowLessSoldGames();

                        break;
                    }
                default:
                    {
                        WriteLine("Wrong option!");
                        continue;
                    }
            }
            continue;

        // task 3
        C:
            WriteLine("Press\n" +
                            "1 - Add game;\n" +
                            "2 - Delete game:");

            switch (ReadKey(true).Key)
            {
                case ConsoleKey.D1:
                    {
                        DBManger.AddGame();

                        break;
                    }
                case ConsoleKey.D2:
                    {
                        DBManger.DeleteGame();

                       break;
                    }
                default:
                    {
                        WriteLine("Wrong option!");
                        continue;
                    }
            }
            continue;
        }
    }
    catch (Exception ex)
    {
        WriteLine(ex.Message);
    }
}