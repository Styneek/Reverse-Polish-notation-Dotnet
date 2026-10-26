using System.Collections.Generic;

namespace RPN;

public static class OperatorRegistry
{
    public static IEnumerable<IOperator> GetAll()
    {
        return new IOperator[]
        {
            new AddOperator(),
            new SubstractOperator(),
            new MultiplyOperator(),
            new DivideOperator(),
            new AbsOperator(),
            new FactorialOperator(),
        };
    }
}
