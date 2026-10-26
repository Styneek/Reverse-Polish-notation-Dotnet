using System;
using System.Collections.Generic;

namespace RPN;

public class Rpn
{
    private readonly MyStack<int> _stack = new MyStack<int>();
    private readonly Dictionary<string, IOperator> _operationFunction = new Dictionary<string, IOperator>();

    public Rpn() : this(OperatorRegistry.GetAll())
    {
    }

    public Rpn(IEnumerable<IOperator> operators)
    {
        foreach (var op in operators)
        {
            _operationFunction[op.Symbol] = op;
        }
    }

    public int EvalRpn(string input)
    {
        var splitInput = input.Split(' ');
        var numberParser = new NumberParser();
        foreach (var op in splitInput)
        {
            if (_operationFunction.ContainsKey(op))
            {
                _operationFunction[op].Execute(_stack);
            }
            else
            {
                _stack.Push(numberParser.Parse(op));
            }
        }

        var result = _stack.Pop();
        if (_stack.IsEmpty)
        {
            return result;
        }
        throw new InvalidOperationException();
    }
}
