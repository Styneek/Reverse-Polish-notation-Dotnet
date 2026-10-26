using System;

namespace RPN;

public class BinaryNumberFormat : INumberFormat
{
    public bool CanParse(string token)
    {
        return token.StartsWith("B");
    }

    public int Parse(string token)
    {
        string rest = token.Substring(1);
        if (rest.Equals(""))
        {
            throw new ArgumentException("Token is not a valid binary number");
        }

        try
        {
            return Convert.ToInt32(rest, 2);
        }
        catch (FormatException)
        {
            throw new ArgumentException("Token is not a valid binary number");
        }
    }
}
