using System;

public static class Bob
{
    public static string Response(string statement)
    {
        string symbol = FindSymbol(statement);

        switch (symbol)
        {
            case "A":
                {
                    return "Whoa, chill out!";
                }
                break;

            case "?":
                {
                    return "Sure.";
                }
                break;

            case "A?":
                {
                    return "Calm down, I know what I'm doing!";
                }
                break;

            case "":
                {
                    return "Fine. Be that way!";
                }
                break;

            case ".":
                {
                    return "Whatever.";
                }
                break;

            default:
                {
                    return "Whatever.";
                }
                break;
        }
    }

    static string FindSymbol(string statement)
    {
        if (IsEmpty(statement))
            return "";

        if (IsQuestion(statement))
        {
            if (IsAllUpper(statement))
                return "A?";
            return "?";
        }

        if (IsAllUpper(statement))
            return "A";

        return ".";
    }

    static bool IsQuestion(string input)
    {
        if (input.LastIndexOf('?') == input.Length - 1)
            return true;

        for (int i = input.Length - 1; i >= 0; i--)
        {
            if (
                input[i] != ' ' && 
                input[i] != '?' &&
                input[i] != '\t' &&
                input[i] != '\n' && 
                input[i] != '\r'
                )
                return false;

            if (input[i] == '?')
                return true;
        }

        return true;
    }

    static bool IsAllUpper(string input)
    {
        var letters = 0;
        for (int i = 0; i < input.Length; i++)
        {
            if (Char.IsLetter(input[i]))
            {
                letters++;

                if (!Char.IsUpper(input[i]))
                    return false;
            }
        }

        return letters == 0 ? false : true;
    }

    static bool IsEmpty(string input)
    {
        if (String.IsNullOrEmpty(input))
            return true;

        var letters = 0;
        for (int i = 0; i < input.Length; i++)
        {
            if (
                input[i] == ' ' || 
                input[i] == '\t' || 
                input[i] == '\n' || 
                input[i] == '\r'
                )
                letters++;
        }
        return letters == input.Length ? true : false;
    }
}