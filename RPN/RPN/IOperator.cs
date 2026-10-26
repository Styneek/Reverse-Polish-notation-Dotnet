namespace RPN;

public interface IOperator
{
    string Symbol { get; }
    void Execute(MyStack<int> stack);
}