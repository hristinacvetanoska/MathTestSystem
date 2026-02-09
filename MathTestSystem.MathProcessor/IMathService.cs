namespace MathTestSystem.MathProcessor
{
    public interface IMathService
    {
        bool CheckAnswer(double correctResult , double studentResult);
        double Evaluate(string formula);
    }
}
