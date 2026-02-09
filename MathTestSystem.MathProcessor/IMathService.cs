namespace MathTestSystem.MathProcessor
{
    public interface IMathService
    {
        bool CheckAnswer(double actualResult, double expectedResult);
        double Evaluate(string formula);
    }
}
