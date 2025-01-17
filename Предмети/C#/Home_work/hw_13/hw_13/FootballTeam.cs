using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hw_13
{
    public class FootballPlayer
    {
        public string Name { get; set; }
    }

    public class FootballTeam
    {
        private List<FootballPlayer> players = new List<FootballPlayer>();

        public void AddPlayer(FootballPlayer player)
        {
            players.Add(player);
        }

        public IEnumerator GetEnumerator()
        {
            foreach (FootballPlayer player in players)
            {
                yield return player;
            }
        }
    }

}
