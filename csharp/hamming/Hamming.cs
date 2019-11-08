using System;

public static class Hamming
{
    public static int Distance(string firstStrand, string secondStrand)
    {
        var dif = 0;

        if (firstStrand.Length != secondStrand.Length)
            throw new ArgumentException("First lengths is longer.");

        for (var i = 0; i < firstStrand.Length; i++)
        {
            if (firstStrand[i] != secondStrand[i])
                dif++;
        }

        return dif;
    }
}