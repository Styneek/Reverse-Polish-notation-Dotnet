using System;

namespace RPN;

public class PlainDecimalNumberFormat : INumberFormat
{
    public bool CanParse(string token)
    {
        return true;
    }

    public int Parse(string token)
    {
        try
        {
            return Convert.ToInt32(token, 10);
        }
        catch (FormatException)
        {
            throw new ArgumentException("Token is not a valid number");
        }
    }
}
