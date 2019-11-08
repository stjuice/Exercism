using System;

public class Clock : IEquatable<Clock>
{
    int hours;
    int minutes;

    public Clock(int hours, int minutes)
    {
        SetMinutes(minutes);
        SetHours(hours);
    }

    public void SetMinutes(int value)
    {
        this.hours += (value / 60);
        int min = value % 60;

        if (min < 0)
        {
            min += 60;
            this.hours -= 1;
        }

        this.minutes = min;
    }

    public void SetHours(int value)
    {
        int tmptHours = value + this.hours;
        int hr = tmptHours % 24;

        if (hr < 0)
            hr += 24;

        this.hours = hr;
    }

    public Clock Add(int minutesToAdd) => new Clock(this.hours, this.minutes + minutesToAdd);

    public Clock Subtract(int minutesToSubtract)
    {
        return new Clock(this.hours, this.minutes - minutesToSubtract);
    }

    public override string ToString() => $"{this.hours:00}:{this.minutes:00}";

    public bool Equals(Clock other)
    {
        if (other == null)
            return false;

        if (this.hours == other.hours && this.minutes == other.minutes)
            return true;

        return false;
    }

    public override bool Equals(Object obj)
    {
        if (obj is Clock clockObj)
            return (this.hours == clockObj.hours &&
                    this.minutes == clockObj.minutes); ;
        return false;
    }

    public override int GetHashCode() => hours * 60 + minutes;
}