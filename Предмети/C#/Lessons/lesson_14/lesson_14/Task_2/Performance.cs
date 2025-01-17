using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using static System.Console;

namespace lesson_14.Task_2
{
    public class Performance
    {
        string _name;
        string _nameOfTheatre;
        Genre _genre;
        TimeOnly _duration;
        List<Actor> _actors;

        private bool _disposed = false;

        public Performance()
        {
            _name = "NoName";
            _nameOfTheatre = "NoTheatre";
            _genre = new Genre();
            _duration = new TimeOnly();
            _actors = new List<Actor>();
        }
        public Performance(string name, string nameOfTheatre, Genre genre, TimeOnly duration, List<Actor> actors)
        {
            _name = name;
            _nameOfTheatre = nameOfTheatre;
            _genre = genre;
            _duration = duration;
            _actors = actors;
        }
        #region
        public string Name
        {
            get { return _name; }
            set
            {
                ArgumentException.ThrowIfNullOrEmpty(value);
                _name = value;
            }
        }
        public string NameOfTheatre
        {
            get { return _nameOfTheatre; }
            set
            {
                ArgumentException.ThrowIfNullOrEmpty(value);
                _nameOfTheatre = value;
            }
        }
        public Genre Genre
        {
            get { return _genre; }
            set
            {
                _genre = value;
            }
        }
        public TimeOnly Duration
        {
            get { return _duration; }
            set
            {
                _duration = value;
            }
        }
        public List<Actor> Actors
        {
            get { return _actors; }
            set
            {
                _actors = value;
            }
        }
        #endregion
        public void Init()
        {
            WriteLine("Type name of performance:");
            Name = ReadLine();
            WriteLine("Type name of theatre:");
            NameOfTheatre = ReadLine();
            WriteLine("Type genre:");
            if(Genre.TryParse(ReadLine(), out _genre))
            {
                WriteLine("Genre added");
            }
            WriteLine("Type duration of performance (hh/MM/ss):");
            if (TimeOnly.TryParse(ReadLine(), out _duration))
            {
                WriteLine("Duration added");
            }
            WriteLine("Enter list of actors (0 to stop):");
            string input = "";
            while(input != "0")
            {
                Actor actor = new();
                actor.Init();
                _actors.Add(actor);
                WriteLine("Enter 0 to stop or else to continue:");
                input = ReadLine();
            }
        }
        public void Dispose()
        {
            Dispose(true);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    if (_actors != null)
                    {
                        foreach (var actor in _actors)
                        {
                            actor.Dispose();
                        }
                        _actors.Clear();
                        _actors = null;
                    }
                    WriteLine("Disposed uncontrolled memory");
                }
                _disposed = true;
            }
                WriteLine("Disposed memory");
        }
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            if (_actors != null)
            {
                foreach (var actor in _actors)
                {
                    sb.Append(actor.ToString());
                    sb.Append("\n");
                }
            }
            else
            {
                sb.Append("No actors");
            }
            return $"Name: {_name} | Studio: {_nameOfTheatre}" +
                $" | Genre: {_genre} | Actors:\n {sb}";
        }
    }
}
