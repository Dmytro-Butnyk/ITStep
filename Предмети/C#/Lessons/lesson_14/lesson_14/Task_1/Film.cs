using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace lesson_14.Task_1
{
    public class Film : IDisposable
    {
        string _name;
        string _studioName;
        string _genre;
        TimeOnly _duration;
        int _year;

        private bool _disposed = false;

        public Film()
        {
            _name = "NoName";
            _studioName = "NoStudioName";
            _genre = "NoGenre";
            _duration = new();
            _year = 0;
        }
        public Film(string name, string studioName, string genre, TimeOnly duration, int year)
        {
            Name = name;
            StudioName = studioName;
            Genre = genre;
            Duration = duration;
            Year = year;
        }
        ~Film()
        {
            Dispose(_disposed);
        }
        // properties
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
        public string StudioName
        {
            get { return _studioName; }
            set
            {
                ArgumentException.ThrowIfNullOrEmpty(value);
                _studioName = value;
            }
        }
        public string Genre
        {
            get { return _genre; }
            set
            {
                ArgumentException.ThrowIfNullOrEmpty(value);
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
        public int Year
        {
            get { return _year; }
            set
            {
                _year = value;
            }
        }
        #endregion
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
                    WriteLine("Disposed uncontrolled memory");
                }
                WriteLine("Disposed memory");
                _disposed = true;
            }
        }
        public override string ToString()
        {
            return $"Name: {_name} | Studio: {_studioName}" +
                $" | Genre: {_genre}";
        }
    }
}
