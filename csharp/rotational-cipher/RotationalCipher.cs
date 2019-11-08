using System;

public static class RotationalCipher
{
    const string letters = "AaBbCcDdEeFfGgHhIiJjKkLlMmNnOoPpQqRrSsTtUuVvWwXxYyZz";

    public static string Rotate(string text, int shiftKey)
    {
        var res = "";
        shiftKey *= 2;

        for (var i = 0; i < text.Length; i++)
        {
            var tmp = text[i];
            for (var j = 0; j < letters.Length; j++)
            {
                if (text[i] != letters[j])
                    continue;

                var index = j + shiftKey;
                if (index < letters.Length)
                    tmp = letters[index];
                else
                    tmp = letters[index - letters.Length];
            }
            res += tmp;
        }
        return res;
    }
}