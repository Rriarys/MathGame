namespace MathGame.Tests;

public class QuestionFactoryTests
{
    [Theory]
    [InlineData(1, 1, 20)]  // Addition, Easy, Limit 20
    [InlineData(1, 2, 50)]  // Addition, Medium, Limit 50
    [InlineData(1, 3, 100)] // Addition, Hard, Limit 100
    public void GenerateQuestion_ShouldRespectDifficultyLimits(int gameType, int difficulty, int expectedLimit)
    {
        // Arrange
        var factory = new QuestionFactory();
        
        // Act
        var result = factory.GenerateQuestion(gameType, difficulty);

        // Assert
        // Check lower bounds
        Assert.True(result.firstNum >= 1, "First number must be >= 1");
        Assert.True(result.secondNum >= 1, "Second number must be >= 1");

        // Check upper bounds based on difficulty
        Assert.True(result.firstNum <= expectedLimit, $"First number {result.firstNum} exceeds limit {expectedLimit}");
        Assert.True(result.secondNum <= expectedLimit, $"Second number {result.secondNum} exceeds limit {expectedLimit}");
    }

    [Fact]
    public void GenerateQuestion_Division_ShouldHaveNoRemainder()
    {
        // Arrange
        var factory = new QuestionFactory();
        // Division,      Hard
        int gameType = 4, difficulty = 3;; 

        // Act
        var result = factory.GenerateQuestion(gameType, difficulty);

        // Assert
        // Verify that firstNum divided by secondNum equals the provided answer and there is no remainder logic-wise
        Assert.Equal(0, result.firstNum % result.secondNum);
        Assert.Equal(result.answer, result.firstNum / result.secondNum);
    }
}
