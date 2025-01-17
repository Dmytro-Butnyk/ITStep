
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lesson_7
{
    public class Team
    {
        public string Name { get; set; }
        public int Fighters { get; set; }

        public Team(string name, int initialFighters)
        {
            Name = name;
            Fighters = initialFighters;
        }

        public void Reinforce()
        {
            Fighters += new Random().Next(1, 10);
        }

        public void Attack(Team otherTeam)
        {
            otherTeam.Fighters -= new Random().Next(1, 7);
        }
        public override string ToString()
        {
            return $"Team name: {Name} | Count of fighters: {Fighters}";
        }
    }
}
