using System;
using System.Collections;
using System.Collections.Generic;

public static class MatchingBrackets
{
    static string openers = "{[(";
    static string closers = "}])";

    public static bool IsPaired(string input)
    {
        var stack = new Stack<char>();

        foreach (var symbol in input)
        {
            if (openers.Contains(symbol))
            {
                stack.Push(symbol);
                continue;
            }

            if (closers.Contains(symbol))
            {
                if (stack.Count == 0)
                    return false;
                    
                if (stack.Pop() != openers[closers.IndexOf(symbol)])
                    return false;
            }
        }

        return stack.Count == 0;
    }
}
