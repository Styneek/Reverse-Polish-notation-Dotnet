using System;
using System.Collections.Generic;

namespace RPN;

public class NumberParser
{
    private readonly IEnumerable<INumberFormat> _formats;

    public NumberParser() : this(NumberFormatRegistry.GetAll())
    {
    }

    public NumberParser(IEnumerable<INumberFormat> formats)
    {
        _formats = formats;
    }

    public int Parse(string token)
    {
        if (token == null || token == "")
        {
            throw new ArgumentException("Token is null or empty");
        }

        foreach (var format in _formats)
        {
            if (format.CanParse(token))
            {
                return format.Parse(token);
            }
        }

        throw new ArgumentException("Token is not a valid number");
    }
}
