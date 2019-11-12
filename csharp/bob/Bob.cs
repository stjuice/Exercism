using System;

public static class Bob
{
    enum Reaction
    {
        Yell, Question, YelQuestion, Weird, Common
    }
    public static string Response(string statement)
    {
        var reaction = FindSymbol(statement);

        switch (reaction)
        {
            case Reaction.Yell:
                return "Whoa, chill out!";
            case Reaction.Question:
                return "Sure.";
            case Reaction.YelQuestion:
                return "Calm down, I know what I'm doing!";
            case Reaction.Weird:
                return "Fine. Be that way!";
            default:
                return "Whatever.";
        }
    }

    static Reaction FindSymbol(string statement)
    {
        if (string.IsNullOrWhiteSpace(statement))
            return Reaction.Weird;

        if (IsQuestion(statement))
        {
            if (IsAllUpper(statement))
                return Reaction.YelQuestion;
            return Reaction.Question;
        }

        if (IsAllUpper(statement))
            return Reaction.Yell;

        return Reaction.Common;
    }

    static bool IsQuestion(string input)
    {
        input = input.TrimEnd(' ', '\t', '\r', '\n');
        return (input[input.Length - 1] == '?');
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
}