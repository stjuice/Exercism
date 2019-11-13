using System;
using System.Collections;
using System.Collections.Generic;
public static class Series
{
    public static string[] Slices(string numbers, int sliceLength)
    {
        var length = numbers.Length;
        if (length < sliceLength || sliceLength < 0 || sliceLength == 0)
            throw new ArgumentException();

        var output = new List<string>();
        for (int i = 0; i < length && i + sliceLength - 1 < length; i++)
        {
            var sub = numbers.Substring(i, sliceLength);
            output.Add(sub);
        }

        return output.ToArray();
    }
}