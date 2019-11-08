using System;
using System.Collections.Generic;

public class Robot
{
    static Random rand = new Random();
    const string letters = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
    const string numbers = "1234567890";
    static ISet<string> used = new HashSet<string>();
    string name;

    public string Name
    {
        get
        {
            SetName();
            return this.name;
        }
    }
    void SetName()
    {
        if (!string.IsNullOrEmpty(this.name))
            return;

        this.name = "";

        do
        {
            string gen = GenerateName();
            if (used.Add(gen))
                this.name = gen;
        }
        while (this.name == "");
    }

    private string GenerateName()
    {
        string value = "";

        for (var i = 0; i < 2; i++)
            value += letters[rand.Next(0, letters.Length)];

        for (var i = 0; i < 3; i++)
            value += numbers[rand.Next(0, numbers.Length)];

        return value;
    }

    public void Reset() => this.name = null;
}