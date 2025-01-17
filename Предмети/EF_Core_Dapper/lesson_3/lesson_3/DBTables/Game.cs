using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using lesson_3;
using static System.Console;

namespace lesson_3.DBTables
{
    public class Game
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public GameStudio GameStudio { get; set; }
        public Genre Genre { get; set; }
        public PlayMode? PlayMode { get; set; }
        public decimal? CopiesSold { get; set; }
        public DateTime ReleaseDate { get; set; }

        public bool Initialize(SampleContext context)
        {
            string buffer = string.Empty;
            // NAME
            Write("Type name of the game: ");
            buffer = ReadLine();
            Name = buffer;
            // GAME STUDIO
            A:
            Write("Enter name of the game studio: ");
            buffer = ReadLine();
            if(!context.GameStudios.Any(x => x.Name == buffer))
            {
                WriteLine($"Error: {buffer} does not exist");
                goto A;
            }
            if(context.Games.Any(x => x.Name == Name && x.GameStudio == GameStudio))
            {
                WriteLine("Error: The game already exist");
                return false;
            }
            GameStudio = context.GameStudios.FirstOrDefault(x => x.Name == buffer);
            // GENRE
            B:
            Write("Enter genre: ");
            buffer = ReadLine();
            if (!context.Genres.Any(x => x.Name == buffer))
            {
                WriteLine($"Error: {buffer} does not exist");
                goto B;
            }
            Genre = context.Genres.FirstOrDefault(x => x.Name == buffer);
            // PLAY MODE
            C:
            WriteLine("Enter 0 - singleplayer, 1 - multiplayer");
            buffer = ReadLine();
            if (buffer == "0")
                PlayMode = lesson_3.PlayMode.Singleplayer;
            else if (buffer == "1")
                PlayMode = lesson_3.PlayMode.Multiplayer;
            else
            {
                WriteLine("Wrong option");
                goto C;
            }
            // COPIES SOLD
            D:
            Write("Enter number of sold copies: ");
            buffer = ReadLine();
            decimal copies;
            if (!decimal.TryParse(buffer, out copies))
            {
                if (copies >= 0) {
                    WriteLine("Wrong value!");
                    goto D;
                }
            }
            CopiesSold = copies;
            // RELEASE DATE
            E:
            Write("Enter date of release (like yyyy/MM/dd)");
            buffer = ReadLine();
            DateTime release;
            if(!DateTime.TryParse(buffer, out release))
            {
                WriteLine("Wrong date format!");
                goto E;
            }
            ReleaseDate = release;

            return true;
        } 
        public override string ToString()
        {
            return $"Game:\n" +
                $"Name: {Name};\n" +
                $"Game studio: {GameStudio.Name}\n" +
                $"Genre: {Genre.Name}\n" +
                $"Play mode: {PlayMode.ToString()}\n" +
                $"Copies sold: {CopiesSold}\n" +
                $"Release date: {ReleaseDate.ToString("dd.MM.yyyy")}";
        }
    }
}
