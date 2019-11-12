using System;
using System.Collections.Generic;
using System.Linq;

public static class Dominoes
{
    public static bool CanChain(IEnumerable<(int, int)> dominoes)
    {
        if (!dominoes.Any())
            return true;

        var count = dominoes.Count();

        if (count == 1)
        {
            var first = dominoes.First();
            return (first.Item1 == first.Item2);
        }

        var numbers = new Dictionary<int, int>();
        foreach (var item in dominoes)
        {
            if (numbers.ContainsKey(item.Item1))
                numbers[item.Item1]++;
            else
                numbers.Add(item.Item1, 1);

            if (item.Item1 == item.Item2)
                continue;

            if (numbers.ContainsKey(item.Item2))
                numbers[item.Item2]++;
            else
                numbers.Add(item.Item2, 1);
        }

        if (numbers.Max(i => i.Value) == numbers.Count())
            return true;

        if (numbers.Any(i => i.Value == 1))
            return false;

        var c = count;
        for (int i = 4; i < c; i++)
            count--;

       var pairCount = numbers.Count(i => i.Value >= count - 1);

        if (pairCount >= count - 1)
            return true;

        return false;
    }

}