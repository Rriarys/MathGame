namespace MathGame.Tests;

public class MathOperationsTests
{
    [Theory]
    [InlineData(1, 20, 50, 100, 20)] 
    [InlineData(2, 20, 50, 100, 50)] 
    [InlineData(3, 20, 50, 100, 100)] 
    [InlineData(99, 20, 50, 100, 50)] 
    public void GetDifficultyLimit_ShouldReturnCorrectValueBasedOnDifficulty(
        int difficulty, int easy, int medium, int hard, int expected)
    {
        // Act
        int result = MathOperations.GetDifficultyLimit(difficulty, easy, medium, hard);

        // Assert
        Assert.Equal(expected, result);
    }

    [Theory]
    [InlineData(10, 5, 15)]
    [InlineData(-5, -5, -10)]
    public void CreateAddition_ShouldCalculateCorrectSum(int a, int b, int expectedSum)
    {
        // Act
        var result = MathOperations.CreateAddition(a, b);

        // Assert
        Assert.Equal(expectedSum, result.res);
        Assert.Equal("+", result.op);
    }

    [Theory]
    [InlineData(10, 5, 5)]
    [InlineData(5, 10, -5)]
    public void CreateSubtraction_ShouldCalculateCorrectDifference(int a, int b, int expectedRes)
    {
        // Act
        var result = MathOperations.CreateSubtraction(a, b);

        // Assert
        Assert.Equal(expectedRes, result.res);
        Assert.Equal("-", result.op);
    }

    [Theory]
    [InlineData(10, 5, 50)]
    [InlineData(0, 10, 0)]
    public void CreateMultiplication_ShouldCalculateCorrectProduct(int a, int b, int expectedRes)
    {
        // Act
        var result = MathOperations.CreateMultiplication(a, b);

        // Assert
        Assert.Equal(expectedRes, result.res);
        Assert.Equal("*", result.op);
    }

    [Theory]
    [InlineData(10, 2, 5)]
    [InlineData(7, 2, 3)]
    public void CreateDivision_ShouldCalculateCorrectQuotient(int a, int b, int expectedQuotient)
    {
        // Act
        var result = MathOperations.CreateDivision(a, b);

        // Assert
        Assert.Equal(expectedQuotient, result.res);
        Assert.Equal("/", result.op);
    }

    [Fact]
    public void CreateDivision_DivideByZero_ShouldThrowException()
    {
        // Act & Assert
        // We use Assert.Throws to ensure the system handles division by zero correctly
        Assert.Throws<DivideByZeroException>(() => 
            MathOperations.CreateDivision(10, 0));
    }
}