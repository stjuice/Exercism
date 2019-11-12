using System;
using System.Collections.Generic;

public class GradeSchool
{
    List<KeyValuePair<string, int>> students =
        new List<KeyValuePair<string, int>>();

    public void Add(string student, int grade)
    {
        students.Add(new KeyValuePair<string, int>(student, grade));
    }

    public IEnumerable<string> Roster()
    {
        var names = new List<string>();

        students.Sort((a, z) => a.Key.CompareTo(z.Key));
        students.Sort((x, y) => x.Value.CompareTo(y.Value));

        foreach (var item in students)
        {
            names.Add(item.Key);
        }

        return names;
    }

    public IEnumerable<string> Grade(int grade)
    {
        var names = new List<string>();

        students.Sort((a, z) => a.Key.CompareTo(z.Key));

        foreach (var item in students)
        {
            if (item.Value == grade)
            {
                names.Add(item.Key);
            }
        }

        return names;
    }
}