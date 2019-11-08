using System;

public static class ResistorColor
{
    static string[] colors =
    {
        "black",
        "brown",
        "red",
        "orange",
        "yellow",
        "green",
        "blue",
        "violet",
        "grey",
        "white"
    };

    public static int ColorCode(string color)
    {
        for (var i = 0; i < colors.Length; i++)
        {
            if (colors[i] == color)
                return i;
        }
        
        return -1;
    }

    public static string[] Colors() => colors;
}