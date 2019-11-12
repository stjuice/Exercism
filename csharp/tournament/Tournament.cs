using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;

public static class Tournament
{
    private class Team
    {
        public readonly string Name;
        public int Matches { get; set; }
        public int Won { get; set; }
        public int Draw { get; set; }
        public int Lost { get; set; }

        public Team(string name)
        {
            Name = name;
            Matches = 0;
            Won = 0;
            Draw = 0;
            Lost = 0;
        }

        public int GetPoints()
        {
            int points = 0;
            points += Won * 3;
            points += Draw;

            return points;
        }
    }

    public static void Tally(Stream inStream, Stream outStream)
    {
        var teams = new List<Team>();

        using (var reader = new StreamReader(inStream))
        {
            while (!reader.EndOfStream)
            {
                var line = reader.ReadLine();
                var values = line.Split(';');

                var challengerName = values[0];
                var challengedName = values[1];
                var result = values[2];

                if (teams.Count(x => x.Name == challengerName) == 0)
                    teams.Add(new Team(challengerName));

                if (teams.Count(x => x.Name == challengedName) == 0)
                    teams.Add(new Team(challengedName));

                var teamChallenger = 
                    teams.Where(x => x.Name == challengerName).FirstOrDefault();

                var teamChallenged = 
                    teams.Where(x => x.Name == challengedName).FirstOrDefault();

                teamChallenger.Matches++;
                teamChallenged.Matches++;

                switch (result)
                {
                    case "win":
                        teamChallenger.Won++;
                        teamChallenged.Lost++;
                        break;
                    case "loss":
                        teamChallenger.Lost++;
                        teamChallenged.Won++;
                        break;
                    case "draw":
                        teamChallenger.Draw++;
                        teamChallenged.Draw++;
                        break;
                }
            }
        }

        using (var writer = new StreamWriter(outStream))
        {
            var sortedTeams = teams.OrderBy(x => x.Name)
                .OrderByDescending(x => x.GetPoints());

            writer.Write("Team                           | MP |  W |  D |  L |  P");

            foreach (var team in sortedTeams)
            {
                writer.Write('\n');
                writer.Write(
                    string.Format("{0}|  {1} |  {2} |  {3} |  {4} |  {5}",
                        team.Name.PadRight(31, ' '),
                        team.Matches,
                        team.Won,
                        team.Draw,
                        team.Lost,
                        team.GetPoints()
                    )
                );
            }
        }
    }
}
