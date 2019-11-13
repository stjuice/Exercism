using System;
using System.Collections;
using System.Collections.Generic;

public class GradeSchool
{
    HashSet<Grades> grades = new HashSet<Grades>(new GradeSchoolComperer());

    public void Add(string student, int grade)
    {
        var tmp = grades;
        tmp.Add(new Grades(grade, student));

        var set = new SortedSet<Grades>(grades);
        grades = new HashSet<Grades>(set, new GradeSchoolComperer());
    }

    public IEnumerable<string> Roster()
    {
        var names = new List<string>();
        foreach (var item in grades)
            names.AddRange(item.Name);

        return names;
    }

    public IEnumerable<string> Grade(int grade)
    {
        var names = new List<string>();
        foreach (var item in grades)
        {
            if (item.Grade == grade)
                names.AddRange(item.Name);
        }
        return names;
    }
}

class Grades : IComparable<Grades>
{
    public int Grade { get; set; }
    public List<string> Name { get; set; }

    public Grades(int grade, string name)
    {
        this.Grade = grade;
        this.Name = new List<string>();
        this.Name.Add(name);
    }

    public override int GetHashCode() => Grade;

    public int CompareTo(Grades other) => Grade.CompareTo(other.Grade);
}

class GradeSchoolComperer : IEqualityComparer<Grades>
{
    public bool Equals(Grades x, Grades y)
    {
        if (x.GetHashCode() == y.GetHashCode())
        {
            x.Name.Add(y.Name[0]);
            x.Name.Sort();
        }

        return x.GetHashCode() == y.GetHashCode();
    }

    public int GetHashCode(Grades obj) => obj.Grade.GetHashCode();
}