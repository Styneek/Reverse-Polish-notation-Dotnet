namespace RPN;

public class AddOperator : IOperator
{
    public string Symbol => "+";

    public void Execute(MyStack<int> stack)
    {
        var right = stack.Pop();
        var left = stack.Pop();
        stack.Push(left + right);
    }
}