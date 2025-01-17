using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lesson_18
{
    public class Song
    {
        public string Title { get; set; } = "NoTitle";
        public string Style { get; set; } = "NoStyle";
        public TimeSpan Duration { get; set; }

        public Song(string title, string style, TimeSpan duration)
        {
            Title = title;
            Style = style;
            Duration = duration;
        }
        public Song() { }
        public override string ToString()
        {
            return $"- {Title} ({Style}, {Duration})";
        }
    }

    public class Album
    {
        public string Title { get; set; }
        public string Artist { get; set; }
        public int ReleaseYear { get; set; }
        public TimeSpan Duration { get; set; }
        public string RecordLabel { get; set; }
        public List<Song> Songs { get; set; }

        public Album(string title, string artist, int releaseYear, TimeSpan duration, string recordLabel, List<Song> songs) 
        {
            Title = title;
            Artist = artist;
            ReleaseYear = releaseYear;
            Duration = duration;
            RecordLabel = recordLabel;
            Songs = songs;
        }
        public Album() { }

        public void AddSong(Song song)
        {
            Songs.Add(song);
        }
        public override string ToString()
        {
            string songs = string.Join("\n", Songs);
            return $"Title: {Title} | Artist: {Artist} | Release Year: {ReleaseYear} |" +
                $" Duration: {Duration} | Record Label: {RecordLabel} |\n" +
                $"Songs:\n{songs}";
        }
    }

}
