using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace lesson_7
{
    public class Confrontation
    {
        private List<Team> _teams;
        private CancellationTokenSource cts;
        private uint roundNum = 1;

        public Confrontation(List<Team> teams)
        {
            _teams = teams;
            cts = new CancellationTokenSource();
        }

        public void StartBattle()
        {
            foreach (var team in _teams)
            {
                Task.Run(() =>
                {
                    while (_teams.Count >= 2 && !cts.Token.IsCancellationRequested)
                    {
                        
                            foreach (var otherTeam in _teams)
                            {
                                if (otherTeam != team && otherTeam.Fighters > 0)
                                {
                                    team.Attack(otherTeam);
                                }
                            }
                        lock (_teams)
                        {
                            EliminateTeam(team);
                            team.Reinforce();
                            ShowTeamsInfo();
                            roundNum++;
                        }
                            Thread.Sleep(100);
                    }
                }, cts.Token);
            }
        }
        public void EliminateTeam(Team team)
        {
            if (team.Fighters <= 0)
            {
                WriteLine($"TEAM {team} IS ELIMINATED!!!");
                _teams.Remove(team);
            }
        }
        public void ShowTeamsInfo()
        {
            WriteLine($"Number of round: {roundNum}");

            foreach (var team in _teams)
            {
                WriteLine(team);
            }
            WriteLine();
        }
        public void StopBattle()
        {
            roundNum = 1;
            cts.Cancel();
        }
    }
}