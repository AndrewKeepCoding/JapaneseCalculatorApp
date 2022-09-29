using FluentAssertions;
using static JapaneseCalculatorApp.Core.Calculator;

namespace JapaneseCalculatorApp.Core.Tests;

public class CalculatorTests
{
    [Theory]
    [InlineData(Numerics.One, Numerics.Two, 3)]
    [InlineData(Numerics.Two, Numerics.One, 3)]
    [InlineData(Numerics.One, Numerics.One, 2)]
    public void AddShouldAdd(Numerics firstOperand, Numerics secondOperand, double expected)
    {
        // Arrange
        Calculator calculator = new();
        // Act
        calculator.AppendNumeric(firstOperand);
        calculator.AppendOperator(Operators.Add);
        calculator.AppendNumeric(secondOperand);
        calculator.ProcessCommand(Commands.Calculate);
        _ = double.TryParse(calculator.GetOutput().Result, out double result);
        // Assert
        _ = result.Should().Be(expected);
    }

    [Theory]
    [InlineData(Numerics.One, Numerics.Two, -1)]
    [InlineData(Numerics.Two, Numerics.One, 1)]
    [InlineData(Numerics.One, Numerics.One, 0)]
    public void SubtractShouldSubtract(Numerics firstOperand, Numerics secondOperand, double expected)
    {
        // Arrange
        Calculator calculator = new();
        // Act
        calculator.AppendNumeric(firstOperand);
        calculator.AppendOperator(Operators.Subtract);
        calculator.AppendNumeric(secondOperand);
        calculator.ProcessCommand(Commands.Calculate);
        _ = double.TryParse(calculator.GetOutput().Result, out double result);
        // Assert
        _ = result.Should().Be(expected);
    }

    [Theory]
    [InlineData(Numerics.One, Numerics.Two, 2)]
    [InlineData(Numerics.Two, Numerics.One, 2)]
    [InlineData(Numerics.One, Numerics.One, 1)]
    public void MultiplyShouldMultiply(Numerics firstOperand, Numerics secondOperand, double expected)
    {
        // Arrange
        Calculator calculator = new();
        // Act
        calculator.AppendNumeric(firstOperand);
        calculator.AppendOperator(Operators.Multiply);
        calculator.AppendNumeric(secondOperand);
        calculator.ProcessCommand(Commands.Calculate);
        _ = double.TryParse(calculator.GetOutput().Result, out double result);
        // Assert
        _ = result.Should().Be(expected);
    }

    [Theory]
    [InlineData(Numerics.One, Numerics.Two, 0.5)]
    [InlineData(Numerics.Two, Numerics.One, 2)]
    [InlineData(Numerics.One, Numerics.One, 1)]
    public void DivideShouldDivide(Numerics firstOperand, Numerics secondOperand, double expected)
    {
        // Arrange
        Calculator calculator = new();
        // Act
        calculator.AppendNumeric(firstOperand);
        calculator.AppendOperator(Operators.Divide);
        calculator.AppendNumeric(secondOperand);
        calculator.ProcessCommand(Commands.Calculate);
        _ = double.TryParse(calculator.GetOutput().Result, out double result);
        // Assert
        _ = result.Should().Be(expected);
    }

    [Fact]
    public void DividingByZeroShouldThrowException()
    {
        // Arrange
        Calculator calculator = new();
        // Act
        calculator.AppendNumeric(Numerics.One);
        calculator.AppendOperator(Operators.Divide);
        calculator.AppendNumeric(Numerics.Zero);
        Action action = () => calculator.ProcessCommand(Commands.Calculate);
        // Assert
        _ = action.Should().Throw<DivideByZeroException>();
    }
}