using System.Diagnostics;

namespace MathGame.Engine;

public class GameSession
{
    private readonly QuestionFactory _questionFactory = new();

    // Runs a full game session consisting of multiple questions
    public (int finalScore, TimeSpan elapsedTime) Start(int gameType, int difficulty, string description)
    {
        int currentScore = 0;
        MinorExtensions.TypeWrite(description);
        
        // Tracking precise duration of the game session
        var gameTimer = Stopwatch.StartNew();

        for (int i = 0; i < 5; i++)
        {
            var question = _questionFactory.GenerateQuestion(gameType, difficulty);
            MinorExtensions.TypeWriteLine($"Question {i + 1}: {question.firstNum} {question.symbol} {question.secondNum} = ?");

            int userAnswer = GetValidInput();

            if (userAnswer == question.answer)
            {
                MinorExtensions.TypeWriteLine("\nCorrect!");
                currentScore++;
            }
            else
            {
                MinorExtensions.TypeWriteLine($"\nWrong! The correct answer was: {question.answer}");
            }
            TextDisplayMethods.PrintSmallSeparator();
        }

        gameTimer.Stop();
        MinorExtensions.TypeWrite($"Game Over! Score: {currentScore}/5. Time: {gameTimer.Elapsed:m'm 's's 'fff'ms'}\n");

        return (currentScore, gameTimer.Elapsed);
    }

    // Handles user input to ensure only valid integers are accepted
    private int GetValidInput()
    {
        while (true)
        {
            MinorExtensions.TypeWrite("\nYour answer: ");
            string? inputString = Console.ReadLine()?.Trim();
            
            if (int.TryParse(inputString, out int numericValue)) 
                return numericValue;
                
            MinorExtensions.TypeWrite("\nInvalid input. Please enter a numerical integer:\n");
        }
    }
}