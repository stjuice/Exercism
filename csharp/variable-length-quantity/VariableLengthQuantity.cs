using System;
using System.Collections.Generic;
using System.Linq;

public static class VariableLengthQuantity
{
    public static uint[] Encode(uint[] numbers) => numbers.SelectMany(n => AsVlq(n)).ToArray();

    public static uint[] Decode(uint[] bytes) => FromVlq(bytes).ToArray();

    private static IEnumerable<uint> AsVlq(uint source, bool isFirst = true)
    {
        if (source > 127)
            foreach (var next in AsVlq(source >> 7, false))
                yield return next;

        var result = source & 127;
        yield return isFirst ? result : result + 128;
    }

    private static IEnumerable<uint> FromVlq(uint[] bytes)
    {
        if (bytes.Last() > 127)
            throw new InvalidOperationException();

        uint sum = 0;

        foreach (var val in bytes)
        {
            if (val > 127)
            {
                sum = sum << 7;
                sum += val - 128;
            }
            else
            {
                sum = sum << 7;
                yield return sum + val;
                sum = 0;
            }
        }
    }
}