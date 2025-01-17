namespace FootballChampionshipDB
{
    public class Team
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int CityId { get; set; }
        public int Wins { get; set; }
        public int Draws {  get; set; }
        public int Goals { get; set; }
        public int MissedGoals { get; set; }

        public Team() {}

        public Team(string name, int cityId, int wins, int draws, int goals, int missedGoals)
        {
            Name = name;
            CityId = cityId;
            Wins = wins;
            Draws = draws;
            Goals = goals;
            MissedGoals = missedGoals;
        }

        public override string ToString() =>
            $"Team name: {Name} | City: {CityId} | Wins: {Wins} | Draws: {Draws} | Goals: {Goals} | MissedGoals: {MissedGoals}";
    }
}
