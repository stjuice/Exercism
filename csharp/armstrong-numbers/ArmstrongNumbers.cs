using System;
using System.Collections;

public static class ArmstrongNumbers
{
    public static bool IsArmstrongNumber(int number)
    {
        int digit = (int)Math.Floor(Math.Log10(number) + 1);
        int n = (int)Math.Pow(10, digit - 1);
        var tmp = number;
        int res = 0;

        for (int i = digit; i > 0; i--)
        {
            var t = tmp / n;
            res += (int)Math.Pow(t, digit);
            tmp = number % n;
            n /= 10;

        }

        return (int)res == number;
    }
}