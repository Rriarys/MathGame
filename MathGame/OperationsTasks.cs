namespace MathGame;

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
    private void RunGame(
        Func<Random, int, (int num1, int num2, string symbol, int correctAnswer)> questionGenerator, // Function parameter that generates a question based on the provided random number generator and difficulty level, returning a tuple containing the two numbers, the operation symbol, and the correct answer
        string description,
        int difficulty
    )
    {
        int score = 0;
        Random random = new();

        Console.ForegroundColor = ConsoleColor.Magenta;
        MinorExtensions.TypeWrite(description);
        Console.ResetColor();

        for (int i = 0; i < 5; i++)
        {
            var (num1, num2, symbol, correctAnswer) = questionGenerator(random, difficulty); // Difficulty parameter is passed to the question generator function, allowing it to create questions that are appropriate for the selected difficulty level

            Console.ForegroundColor = ConsoleColor.DarkYellow;
            MinorExtensions.TypeWriteLine($"Question {i + 1}: {num1} {symbol} {num2} = ?"); // Print the question to the console with a typewriting effect, using the generated numbers and operation symbol to create the question format
            Console.ResetColor();

            int userAnswer;

            while (true)
            {
                MinorExtensions.TypeWrite("\nYour answer: ");
                string? userInput = Console.ReadLine()?.Trim();

                if (userInput is null || !int.TryParse(userInput, out userAnswer))
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    MinorExtensions.TypeWrite("\nInvalid input. Please enter a valid integer answer:\n");
                    Console.ResetColor();
                    continue;
                }

                break;
            }

            if (userAnswer == correctAnswer)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                MinorExtensions.TypeWriteLine("\nCorrect!");
                Console.ResetColor();
                TextDisplayMethods.PrintSmallSeparator();
                score++;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                MinorExtensions.TypeWriteLine($"\nWrong! The correct answer was: {correctAnswer}");
                Console.ResetColor();
                TextDisplayMethods.PrintSmallSeparator();
            }
        }

        Console.ForegroundColor = ConsoleColor.DarkBlue;
        MinorExtensions.TypeWrite($"Game Over! Your final score is: {score}/5\n");
        Console.ResetColor();
    }

    // =============================== DIFFICULTY ===============================
    private int GetMaxDifficulty(int difficulty, int easy, int medium, int hard) // Method to determine the maximum difficulty level based on the player's choice, returning the corresponding value for easy, medium, or hard difficulty levels
    {
        return difficulty switch
        {
            1 => easy,
            2 => medium,
            3 => hard,
            _ => medium
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
        int maxDividend = GetMaxDifficulty(difficulty, 50, 100, 500);

        int divisor = random.Next(2, maxDividend + 1);
        int maxResult = maxDividend / divisor;

        int result = random.Next(1, maxResult + 1);
        int dividend = divisor * result;

        return (dividend, divisor, "/", result);
    }

    // =============================== REALISATIONS ===============================
    public void StartAdditionGame(int difficulty)
    {
        RunGame(GenerateAddition, additionDescription, difficulty);
    }

    public void StartSubtractionGame(int difficulty)
    {
        RunGame(GenerateSubtraction, subtractionDescription, difficulty);
    }

    public void StartMultiplicationGame(int difficulty)
    {
        RunGame(GenerateMultiplication, multiplicationDescription, difficulty);
    }

    public void StartDivisionGame(int difficulty)
    {
        RunGame(GenerateDivision, divisionDescription, difficulty);
    }

    // =============================== RANDOM OPERATIONS ===============================
    public void StartRandomOperationsGame(int difficulty)
    {
        RunGame(
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

// Strategy pattern is used to create a flexible and reusable game structure that can easily accommodate different types of math operations (addition, subtraction, multiplication, division) without duplicating code. By defining a common game logic in the RunGame method and using function parameters to generate questions based on the specific operation, we can maintain a clean and organized codebase while providing a consistent gaming experience across all operation types. This approach allows for easy expansion in the future if we want to add more operations or game modes without needing to rewrite the core game logic.