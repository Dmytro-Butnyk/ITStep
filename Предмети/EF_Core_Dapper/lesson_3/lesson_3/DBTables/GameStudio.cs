using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lesson_3.DBTables
{
    public class GameStudio
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Rating { get; set; }
        public virtual List<Game>? Games { get; set; }

        public override string ToString()
        {
            return $"Name: {Name} | Rating: {Rating}";
        }
    }
}
