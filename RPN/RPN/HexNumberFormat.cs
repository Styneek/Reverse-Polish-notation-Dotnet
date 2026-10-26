using System;

namespace RPN;

public class HexNumberFormat : INumberFormat
{
    public bool CanParse(string token)
    {
        return token.StartsWith("#");
    }

    public int Parse(string token)
    {
        string rest = token.Substring(1);
        if (rest.Equals(""))
        {
            throw new ArgumentException("Token is not a valid hexadecimal number");
        }

        try
        {
            return Convert.ToInt32(rest, 16);
        }
        catch (FormatException)
        {
            throw new ArgumentException("Token is not a valid hexadecimal number");
        }
    }
}
