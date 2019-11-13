using System;

public static class ReverseString
{
    public static string Reverse(string input)
    {
        var reverse = input.ToCharArray();
        Array.Reverse(reverse);
        
        return new string(reverse);
    }
}
