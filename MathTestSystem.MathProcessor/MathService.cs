namespace MathTestSystem.MathProcessor
{
    using System.Data;

    public class MathService : IMathService
    {
        public bool CheckAnswer(double actualResult, double expectedResult)
        {
            return actualResult == expectedResult ? true : false;
        }

        public double Evaluate(string formula)
        {
            var mathOperation = formula.Split("=");
            var dt = new DataTable();
            return Convert.ToDouble(dt.Compute(mathOperation[0], ""));
        }
    }
}
