namespace RPN;

public class AbsOperator : IOperator
{
    public string Symbol => "ABS";

    public void Execute(MyStack<int> stack)
    {
        var value = stack.Pop();
        stack.Push(Math.Abs(value));
    }
}