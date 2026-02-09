namespace MathTestSystem.Tests
{
    using MathTestSystem.MathProcessor;
    using Xunit;

    public class MathServiceTests
    {
        private readonly IMathService mathService;

        public MathServiceTests()
        {
            this.mathService = new MathService();
        }

        [Theory]
        [InlineData("2+3=", 5)]
        [InlineData("10-4=", 6)]
        public void Evaluate_ValidFormulas_ReturnsCorrectResult(string formula, double expected)
        {
            var result = this.mathService.Evaluate(formula);
            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData(5, 5, true)]
        [InlineData(5, 4.99, false)]
        public void CheckAnswer_CorrectAndIncorrect_ReturnsExpected(double correctResult, double studentResult, bool expected)
        {
            var result = this.mathService.CheckAnswer(correctResult, studentResult);
            Assert.Equal(expected, result);
        }
    }
}
