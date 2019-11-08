using System;

public class CircularBuffer<T> 
{
    T[] buffer;

    int last;
    
    int first;
    
    int count;
    
    private static readonly T empty = default(T);
    
    public CircularBuffer(int capacity) 
    {
        buffer = new T[capacity];
        last = capacity == 1 ? 0 : capacity / 2;
        first = last;
    }

    public T Read() 
    {
        if (count == 0 || empty.Equals(buffer[last])) 
            throw new InvalidOperationException();

        var index = last;
        last = FindLast();

        T res = buffer[index];
        buffer[index] = empty;

        count--;

        return res;
    }

    public void Write(T value) 
    {
        if (count == buffer.Length)
            throw new InvalidOperationException();

        var nextIndex = FindFirst();
        buffer[nextIndex] = value;
        count++;
    }

    public int FindFirst() 
    {
        var index = first + 1 >= buffer.Length ? 0 : first + 1;

        if (empty.Equals(buffer[index])) 
        {
            first = index;

            if (count == 0) 
                last = first;

            return index;
        }

        first = index;
        return index;
    }
    
    public int FindLast() 
    {
        var index = last + 1 >= buffer.Length ? 0 : last + 1;

        while (empty.Equals(buffer[index])) 
        {
            index++;
            if (index >= buffer.Length) 
                index = 0;
        }

        return index;
    }

    public void Overwrite(T value) 
    {
        if (count == buffer.Length)
        {
            buffer[last] = value;
            last = FindLast();
        }
        else
        {
            Write(value);
        }
    }

    public void Clear() 
    {
        for (int i = 0; i < buffer.Length; i++) 
            buffer[i] = empty;

        count = 0;
    }
}