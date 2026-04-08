namespace MathGame.Tests;

public class MathOperationsTests
{
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
}
