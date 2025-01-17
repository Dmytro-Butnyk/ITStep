using Microsoft.EntityFrameworkCore;
using static System.Console;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using lesson_3.DBTables;

namespace lesson_3.Model
{
    public static class DBManger
    {
        private static SampleContext context = new();

        // task 1
        #region
        public static void ShowGame(string name)
        {
                var res = context.Games
                    .Include("GameStudio")
                    .Include("Genre")
                    .FirstOrDefault(x => x.Name == name);

                WriteLine(res);
        }
        public static void SearchByStudio(string s)
        {
                context.Games
                .Include("GameStudio")
                .Include("Genre")
                .Where(x => x.GameStudio == context.GameStudios
                .FirstOrDefault(x => x.Name == s))
                .ToList()
                .ForEach(x => WriteLine(x + "\n"));
        }
        public static void SearchByGameAndStudio(string gName, string sName)
        {
                var res = context.Games
                    .Include("GameStudio")
                    .Include("Genre")
                    .FirstOrDefault(x => x.Name == gName &&
                    x.GameStudio == context.GameStudios
                    .FirstOrDefault(x => x.Name == sName));

                WriteLine(res);
        }
        public static void SearchByGenre(string gName)
        {
            context.Games
                .Include("GameStudio")
                .Include("Genre")
                .Where(x => x.Genre == context.Genres
                .FirstOrDefault(x => x.Name == gName))
                .ToList()
                .ForEach(x => WriteLine(x + "\n"));
        }
        public static void SearchByYear(string year)
        {
            int y;
            int.TryParse(year, out y);
            context.Games
                .Include("GameStudio")
                .Include("Genre")
                .Where(x => x.ReleaseDate.Year == y)
                .ToList()
                .ForEach(x => WriteLine(x + "\n"));
        }
        #endregion

        // task 2 
        #region
        public static void ShowSingleplayerGames()
        {
            context.Games.Include("GameStudio").Include("Genre")
                .Where(x => x.PlayMode == PlayMode.Singleplayer)
                .ToList()
                .ForEach(x => WriteLine(x + "\n"));
        }
        public static void ShowMultiplayerGames()
        {
            context.Games.Include("GameStudio").Include("Genre")
                .Where(x => x.PlayMode == PlayMode.Multiplayer)
                .ToList()
                .ForEach(x => WriteLine(x + "\n"));
        }
        public static void ShowBestSeller()
        {
            var res = context.Games.Include("GameStudio").Include("Genre")
                .FirstOrDefault(x => x.CopiesSold == context.Games.Max(x => x.CopiesSold));
            WriteLine(res + "\n");
        }
        public static void ShowLessSoldGames()
        {
            context.Games.Include("GameStudio").Include("Genre")
                .OrderBy(x => x.CopiesSold)
                .Take(3)
                .ToList()
                .ForEach(x => WriteLine(x + "\n"));
        }
        #endregion

        // task 3

        public static void AddGame()
        {
            Game game = new Game();
            if (game.Initialize(context))
            {
                context.Add(game);
                context.SaveChanges();
                WriteLine($"Game \"{game.Name}\" sucsessfully added!");
            }
        }
        public static void DeleteGame()
        {
            string game, gameStudio;
            Write("Enter game name: ");
            game = ReadLine();
            Write("Enter game studo name: ");
            gameStudio = ReadLine();

            if(!context.Games.Any(x => x.Name == game)
            || !context.Games.Any(x => x.GameStudio.Name == gameStudio))
            {
                WriteLine("Wrong game or studio name!");
                return;
            }

            WriteLine("Are you sure?\n" +
                "1 - Yes | 2 - No");
            while (true)
            {
                switch (ReadLine())
                {
                    case "1":
                        {
                            context.Remove(context.Games.FirstOrDefault(x => x.Name == game
                            && x.GameStudio.Name == gameStudio));
                            context.SaveChanges();
                            WriteLine("Deleted sucsessfully!");
                            return;
                        }
                    case "2": 
                        {
                            WriteLine("Ok");
                            return;
                        }
                    default:
                        {
                            WriteLine("Wrong option!");
                            break;
                        }
                }
            }
            
        }
    }
}
