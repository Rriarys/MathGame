namespace MathGame.Tests;

public class QuestionFactoryTests
{
    [Theory]
    [InlineData(1, 1, 20)]  // Addition - Easy
    [InlineData(1, 2, 50)]  // Addition - Medium
    [InlineData(1, 3, 100)] // Addition - Hard
    [InlineData(2, 1, 20)]  // Subtraction - Easy
    [InlineData(2, 2, 50)]  // Subtraction - Medium
    [InlineData(2, 3, 100)] // Subtraction - Hard
    [InlineData(3, 1, 20)]  // Multiplication - Easy
    [InlineData(3, 2, 50)]  // Multiplication - Medium
    [InlineData(3, 3, 100)] // Multiplication - Hard
    public void GenerateQuestion_ShouldRespectDifficultyLimits(int gameType, int difficulty, int expectedLimit)
    {
        // Arrange
        var factory = new QuestionFactory();
        
        // Act
        var result = factory.GenerateQuestion(gameType, difficulty);

        // Assert
        // Verify that firstNum and secondNum are within the expected range
        Assert.True(result.firstNum >= 1 && result.firstNum <= expectedLimit, 
            $"FirstNum {result.firstNum} out of range for type {gameType}, diff {difficulty}");
        Assert.True(result.secondNum >= 1 && result.secondNum <= expectedLimit, 
            $"SecondNum {result.secondNum} out of range");
    }

    [Theory]
    [InlineData(1, 120, 6)]  // Division - Easy:   Max Dividend 120, Max Result 6
    [InlineData(2, 340, 12)] // Division - Medium: Max Dividend 340, Max Result 12
    [InlineData(3, 560, 20)] // Division - Hard:   Max Dividend 560, Max Result 20
    public void GenerateQuestion_Division_ShouldRespectAllLimits(int difficulty, int maxDividend, int maxResult)
    {
        // Arrange
        var factory = new QuestionFactory();
        int gameType = 4; // Division

        // Act
        var result = factory.GenerateQuestion(gameType, difficulty);

        // Assert
        // Check the Dividend (firstNum)
        Assert.True(result.firstNum <= maxDividend, 
            $"Dividend {result.firstNum} exceeds max limit {maxDividend} for difficulty {difficulty}");

        // Check the Result (answer)
        Assert.True(result.answer <= maxResult, 
            $"Result {result.answer} exceeds max possible result {maxResult}");
        
        // Check the Divisor (secondNum)
        // According to the logic: divisor = _random.Next(2, Math.Min(maxDividendLimit / expectedResult, maxPossibleResult) + 1)
        // So divisor should also not exceed maxResult
        Assert.True(result.secondNum <= maxResult, 
            $"Divisor {result.secondNum} exceeds max possible result {maxResult}");

        // Integrity check
        Assert.Equal(0, result.firstNum % result.secondNum);
        Assert.Equal(result.answer, result.firstNum / result.secondNum);
    }
}
