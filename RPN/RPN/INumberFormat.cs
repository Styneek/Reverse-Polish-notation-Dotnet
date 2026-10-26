namespace RPN;

public interface INumberFormat
{
    bool CanParse(string token);
    int Parse(string token);
}
