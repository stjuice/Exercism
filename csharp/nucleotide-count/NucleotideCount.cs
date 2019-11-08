using System;
using System.Collections.Generic;

public static class NucleotideCount
{
    public static IDictionary<char, int> Count(string sequence)
    {        
        var dna = new Dictionary<char, int>
        {
            ['A'] = 0,
            ['C'] = 0,
            ['G'] = 0,
            ['T'] = 0
        };

        foreach (char item in sequence)
        {   
            if (!dna.ContainsKey(item))
                throw new ArgumentException("There is not DNA.");

            dna[item]++;
        }

        return dna;
    }
}