using System;

public class SpiralMatrix
{
    public static int[,] GetMatrix(int size)
    {
        var matrix = new int[size, size];
        var x = 0;
        var y = 0;
        var max = size - 1;
        var min = 0;
        var count = size * size;

        for (int i = 1; i <= count; i++)
        {
            matrix[y, x] = i;

            if (y == max && x > min)
                x--;
            else if (x == max)
                y++;
            else if (y == min)
                x++;
            else if (x == min && y > min + 1)
                y--;
            else
            {
                max -= 1;
                min += 1;
                x++;
            }
        }

        return matrix;
    }
}
