namespace RPN;

public class DivideOperator : IOperator
{
    public string Symbol => "/";
    
    public void Execute(MyStack<int> stack)
    {
        var right = stack.Pop();
        var left = stack.Pop();
        if (right == 0) {
            throw new DivideByZeroException();
        }
        stack.Push(left / right);
    }
}