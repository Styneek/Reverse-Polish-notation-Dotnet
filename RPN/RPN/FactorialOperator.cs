namespace RPN;

public class FactorialOperator : IOperator
{
    public string Symbol => "!";
    
    public void Execute(MyStack<int> stack)
    {
        var value = stack.Pop();
        if (value < 0) {
            throw new ArgumentException("Factorial is not defined for negative numbers");
        }
        int result = 1;
        for (int i = 1; i <= value; i++) {
            result *= i;
        }
        stack.Push(result);
    }
}