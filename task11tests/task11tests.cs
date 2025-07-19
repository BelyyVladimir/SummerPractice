using Xunit;
using task11;

public class CalculatorTests
{
    private ICalculator _calculator;

    public CalculatorTests()
    {
        _calculator = DynamicCalculatorCreator.CreateCalculator();
    }

    [Fact]
    public void Add_ShouldReturnCorrectSum()
    {
        int a = 14;
        int b = 86;
        int expected = 100;

        int result = _calculator.Add(a, b);

        Assert.Equal(expected, result);
    }

    [Fact]
    public void Minus_ShouldReturnCorrectDifference()
    {
        int a = 14;
        int b = 8;
        int expected = 6;

        int result = _calculator.Minus(a, b);

        Assert.Equal(expected, result);
    }

    [Fact]
    public void Mul_ShouldReturnCorrectMul()
    {
        int a = 14;
        int b = 8;
        int expected = 112;


        int result = _calculator.Mul(a, b);

        Assert.Equal(expected, result);
    }

    [Fact]
    public void Div_ShouldReturnCorrectQuotient()
    {
        int a = 84;
        int b = 14;
        int expected = 6;

        int result = _calculator.Div(a, b);

        Assert.Equal(expected, result);
    }

    [Fact]
    public void Div_ByZero_ShouldThrowDivideByZeroException()
    {
        int a = 1;
        int b = 0;

        var exception = Assert.Throws<DivideByZeroException>(() => _calculator.Div(a, b));
        Assert.Contains("divide", exception.Message.ToLower());
    }
}