namespace MathGame.Engine;

public class QuestionFactory
{
    private readonly Random _randomGenerator = new();

    // Generates a complete math question based on game type and difficulty
    public (int firstNum, int secondNum, string symbol, int answer) GenerateQuestion(int gameType, int difficulty)
    {
        // For Random mode (5), pick an operation between 1 (Add) and 4 (Divide)
        int operationType = gameType == 5 ? _randomGenerator.Next(1, 5) : gameType;
        int maxRange = MathOperations.GetDifficultyLimit(difficulty, 20, 50, 100);

        return operationType switch
        {
            1 => MathOperations.CreateAddition(_randomGenerator.Next(1, maxRange + 1), _randomGenerator.Next(1, maxRange + 1)),
            2 => MathOperations.CreateSubtraction(_randomGenerator.Next(1, maxRange + 1), _randomGenerator.Next(1, maxRange + 1)),
            3 => MathOperations.CreateMultiplication(_randomGenerator.Next(1, maxRange + 1), _randomGenerator.Next(1, maxRange + 1)),
            4 => GenerateDivision(difficulty),
            _ => (0, 0, "", 0)
        };
    }

    // Ensures division questions always result in a whole integer without remainders
    private (int firstNum, int secondNum, string symbol, int answer) GenerateDivision(int difficulty)
    {
        int maxPossibleResult = MathOperations.GetDifficultyLimit(difficulty, 6, 12, 20);
        int expectedResult = _randomGenerator.Next(2, maxPossibleResult + 1);
        
        int maxDividendLimit = MathOperations.GetDifficultyLimit(difficulty, 120, 340, 560);
        int divisor = _randomGenerator.Next(2, Math.Min(maxDividendLimit / expectedResult, maxPossibleResult) + 1);
        
        // Return dividend (divisor * result) to guarantee a clean division
        return MathOperations.CreateDivision(divisor * expectedResult, divisor);
    }
}