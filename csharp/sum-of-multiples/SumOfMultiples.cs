using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

public static class SumOfMultiples
{
    public static int Sum(IEnumerable<int> multiples, int max) => 
        Enumerable.Range(0, max).Where(i => multiples.Any(j => j != 0 && i % j == 0)).Sum();
}