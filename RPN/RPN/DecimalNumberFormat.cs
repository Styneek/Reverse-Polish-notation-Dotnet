using System;

namespace RPN;

public class DecimalNumberFormat : INumberFormat
{
    public bool CanParse(string token)
    {
        return token.StartsWith("D");
    }

    public int Parse(string token)
    {
        string rest = token.Substring(1);
        if (rest.Equals(""))
        {
            throw new ArgumentException("Token is not a valid decimal number");
        }

        try
        {
            return Convert.ToInt32(rest, 10);
        }
        catch (FormatException)
        {
            throw new ArgumentException("Token is not a valid decimal number");
        }
    }
}
