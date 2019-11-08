using System;
using System.Collections.Generic;

public class HighScores
{
    List<int> scores;
    int latest;
    int max = -1;

    public HighScores(List<int> list)
    {
        this.scores = list;

        for (int i = 0; i < scores.Count; i++)
        {
            if (scores[i] > max)
                max = scores[i];

            if (i == scores.Count - 1)
                latest = scores[i];
        }
    }

    public List<int> Scores() => scores;

    public int Latest() => latest;

    public int PersonalBest() => max;

    public List<int> PersonalTopThree()
    {
        int[] topThree = scores.ToArray();
        int t = this.PersonalBest();

        for (int p = 0; p <= topThree.Length - 2; p++)
        {
            for (int i = 0; i <= topThree.Length - 2; i++)
            {
                if (topThree[i] < topThree[i + 1])
                {
                    t = topThree[i + 1];
                    topThree[i + 1] = topThree[i];
                    topThree[i] = t;
                }
            }
        }

        var res = new List<int>();

        for (var i = 0; i < topThree.Length && i < 3; i++)
        {
            res.Add(topThree[i]);
        }

        return res;
    }
}