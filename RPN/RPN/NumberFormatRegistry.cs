using System.Collections.Generic;

namespace RPN;

public static class NumberFormatRegistry
{
    public static IEnumerable<INumberFormat> GetAll()
    {
        return new INumberFormat[]
        {
            new BinaryNumberFormat(),
            new HexNumberFormat(),
            new DecimalNumberFormat(),
            new PlainDecimalNumberFormat(),
        };
    }
}
