using System.Diagnostics;

namespace MathGame;

// Strategy pattern
public class OperationsTasks
{
    const string additionDescription = @"Welcome to the Addition Game!
Calculate the sum of two numbers.

";
    const string subtractionDescription = @"Welcome to the Subtraction Game!
Calculate the difference between two numbers.

";
    const string multiplicationDescription = @"Welcome to the Multiplication Game!
Calculate the product of two numbers.

";
    const string divisionDescription = @"Welcome to the Division Game!
Calculate the quotient of two numbers.

";
    const string randomOperationsDescription = @"Welcome to the Random Operations Game!
Mix of all operations.

";

    // =============================== CORE ===============================
    private (int score, double time) RunGame(
        Func<Random, int, (int num1, int num2, string symbol, int correctAnswer)> questionGenerator, // Function parameter that generates a question based on the provided random number generator and difficulty level, returning a tuple containing the two numbers, the operation symbol, and the correct answer
        string description,
        int difficulty
    )
    {
        int score = 0;
        Random random = new();

        MinorExtensions.TypeWrite(description);

        var stopwatch = Stopwatch.StartNew(); // Start the stopwatch to measure the elapsed time for the game session

        for (int i = 0; i < 5; i++)
        {
            var (num1, num2, symbol, correctAnswer) = questionGenerator(random, difficulty); // Difficulty parameter is passed to the question generator function, allowing it to create questions that are appropriate for the selected difficulty level

            MinorExtensions.TypeWriteLine($"Question {i + 1}: {num1} {symbol} {num2} = ?"); // Print the question to the console with a typewriting effect, using the generated numbers and operation symbol to create the question format

            int userAnswer;

            while (true)
            {
                MinorExtensions.TypeWrite("\nYour answer: ");
                string? userInput = Console.ReadLine()?.Trim();

                if (userInput is null || !int.TryParse(userInput, out userAnswer))
                {
                    MinorExtensions.TypeWrite("\nInvalid input. Please enter a valid integer answer:\n");
                    continue;
                }

                break;
            }

            if (userAnswer == correctAnswer)
            {
                MinorExtensions.TypeWriteLine("\nCorrect!");
                TextDisplayMethods.PrintSmallSeparator();
                score++;
            }
            else
            {
                MinorExtensions.TypeWriteLine($"\nWrong! The correct answer was: {correctAnswer}");
                TextDisplayMethods.PrintSmallSeparator();
            }
        }
        stopwatch.Stop(); // Stop the stopwatch after the game session is completed
        MinorExtensions.TypeWrite($"Game Over! Your final score is: {score}/5. Time elapsed: {stopwatch.Elapsed.TotalSeconds:F2} seconds.\n");

        return (score, stopwatch.Elapsed.TotalSeconds);
    }

    // =============================== DIFFICULTY ===============================
    private int GetMaxDifficulty(int difficulty, int easy, int medium, int hard) // Method to determine the maximum difficulty level based on the player's choice, returning the corresponding value for easy, medium, or hard difficulty levels (easy, medium, hard it's just name of parameters, instead of 20, 50, 100)
    {
        return difficulty switch
        {
            1 => easy,
            2 => medium,
            3 => hard,
            _ => medium // Never be reached, just for no warnings, MinorExtensions.SelectDifficulty() - garantees that difficulty will be between 1 and 3
        };
    }

    // =============================== GENERATORS ===============================
    private (int, int, string, int) GenerateAddition(Random random, int difficulty) // Method to generate an addition question based on the provided random number generator and difficulty level, returning a tuple containing the two numbers, the operation symbol, and the correct answer
    {
        int maxDifficulty = GetMaxDifficulty(difficulty, 20, 50, 100);

        int a = random.Next(1, maxDifficulty + 1);
        int b = random.Next(1, maxDifficulty + 1);

        return (a, b, "+", a + b);
    }

    private (int, int, string, int) GenerateSubtraction(Random random, int difficulty)
    {
        int maxDifficulty = GetMaxDifficulty(difficulty, 20, 50, 100);

        int a = random.Next(1, maxDifficulty + 1);
        int b = random.Next(1, maxDifficulty + 1);

        return (a, b, "-", a - b);
    }

    private (int, int, string, int) GenerateMultiplication(Random random, int difficulty)
    {
        int maxDifficulty = GetMaxDifficulty(difficulty, 20, 50, 100);

        int a = random.Next(1, maxDifficulty + 1);
        int b = random.Next(1, maxDifficulty + 1);

        return (a, b, "*", a * b);
    }

    private (int, int, string, int) GenerateDivision(Random random, int difficulty)
    {
        int maxResult = GetMaxDifficulty(difficulty, 6, 12, 20); // The max Result difficulty

        int result = random.Next(2, maxResult + 1); // 1 too easy, so skip it

        int maxDividend = GetMaxDifficulty(difficulty, 120, 340, 560); // The max Dividend size
        int maxDivisor = maxDividend / result;

        int divisor = random.Next(2, Math.Min(maxDivisor, maxResult) + 1); // Ensure the divisor is not too large to keep the division manageable and the result within the desired difficulty range

        int dividend = divisor * result;

        return (dividend, divisor, "/", result);
    }

    // =============================== REALISATIONS ===============================
    public (int score, double time) StartAdditionGame(int difficulty)
    {
        return RunGame(GenerateAddition, additionDescription, difficulty);
    }

    public (int score, double time) StartSubtractionGame(int difficulty)
    {
        return RunGame(GenerateSubtraction, subtractionDescription, difficulty);
    }

    public (int score, double time) StartMultiplicationGame(int difficulty)
    {
        return RunGame(GenerateMultiplication, multiplicationDescription, difficulty);
    }

    public (int score, double time) StartDivisionGame(int difficulty)
    {
        return RunGame(GenerateDivision, divisionDescription, difficulty);
    }

    // =============================== RANDOM OPERATIONS ===============================
    public (int score, double time) StartRandomOperationsGame(int difficulty)
    {
        return RunGame(
            (random, difficulty) =>
            {
                int operationType = random.Next(1, 5);

                return operationType switch
                {
                    1 => GenerateAddition(random, difficulty),
                    2 => GenerateSubtraction(random, difficulty),
                    3 => GenerateMultiplication(random, difficulty),
                    4 => GenerateDivision(random, difficulty),
                    _ => (0, 0, "", 0)
                };
            },
            randomOperationsDescription,
            difficulty
        );
    }
}