namespace MathGame.Tests;

public class MathOperationsTests
{
    [Theory]
    [InlineData(1, 20, 50, 100, 20)] // Case 1: Easy
    [InlineData(2, 20, 50, 100, 50)] // Case 2: Medium
    [InlineData(3, 20, 50, 100, 100)] // Case 3: Hard
    [InlineData(99, 20, 50, 100, 50)] // Case _: Default (Medium)
    public void GetDifficultyLimit_ShouldReturnCorrectValueBasedOnDifficulty(
        int difficulty, int easy, int medium, int hard, int expected)
    {
        // Act
        int result = MathOperations.GetDifficultyLimit(difficulty, easy, medium, hard);

        // Assert
        Assert.Equal(expected, result);
    }

    [Theory] // Marks this method as a test that can take parameters
    [InlineData(10, 5, 15)]   // Test case 1: Positive numbers
    [InlineData(-5, -5, -10)] // Test case 2: Negative numbers
    [InlineData(0, 0, 0)]      // Test case 3: Zeros
    [InlineData(-10, 5, -5)]  // Test case 4: Mixed signs
    public void CreateAddition_ShouldCalculateCorrectSum(int a, int b, int expectedSum)
    {
        // Act
        var result = MathOperations.CreateAddition(a, b);

        // Assert
        Assert.Equal(expectedSum, result.res);
        Assert.Equal("+", result.op);
    }

    [Theory]
    [InlineData(10, 2, 5)]   // 10 / 2 = 5
    [InlineData(100, 10, 10)] // 100 / 10 = 10
    [InlineData(7, 2, 3)]    // Integer division: 7 / 2 = 3
    [InlineData(-10, 2, -5)]  // Division with negative numbers
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
        Assert.Throws<DivideByZeroException>(() => 
            MathOperations.CreateDivision(10, 0));
    }
}
