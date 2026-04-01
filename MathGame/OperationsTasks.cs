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
        Func<Random, (int num1, int num2, string symbol, int correctAnswer)> questionGenerator, // Function to generate questions based on the type of operation
        string description
    )
    {
        int score = 0;
        Random random = new();

        Console.ForegroundColor = ConsoleColor.Magenta;
        MinorExtensions.TypeWrite(description);
        Console.ResetColor();

        for (int i = 0; i < 5; i++)
        {
            var (num1, num2, symbol, correctAnswer) = questionGenerator(random); // Generate a question using the provided question generator function and unpack the returned tuple into individual variables for easier use in the game logic

            Console.ForegroundColor = ConsoleColor.DarkYellow;
            MinorExtensions.TypeWriteLine($"Question {i + 1}: {num1} {symbol} {num2} = ?"); // Print the question to the console with a typewriting effect, using the generated numbers and operation symbol to create the question format
            Console.ResetColor();

            int userAnswer;

            while (true)
            {
                MinorExtensions.TypeWrite("\nYour answer: ");
                string? userInput = Console.ReadLine();

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

    // =============================== GENERATORS ===============================
    private (int, int, string, int) GenerateAddition(Random random) // Method to generate a random addition question, returning the two numbers, the operation symbol, and the correct answer as a tuple
    {
        int a = random.Next(1, 101);
        int b = random.Next(1, 101);
        return (a, b, "+", a + b);
    }

    private (int, int, string, int) GenerateSubtraction(Random random)
    {
        int a = random.Next(1, 101);
        int b = random.Next(1, 101);
        return (a, b, "-", a - b);
    }

    private (int, int, string, int) GenerateMultiplication(Random random)
    {
        int a = random.Next(1, 21); // To keep the multiplication questions manageable and suitable for a wider range of players, we limit the random numbers to a smaller range (1 to 20). This way, the multiplication questions will be more reasonable and less likely to produce very large results
        int b = random.Next(1, 21);
        return (a, b, "*", a * b);
    }

    private (int, int, string, int) GenerateDivision(Random random)
    {
        int divisor = random.Next(2, 51); // To ensure we don't have division by zero and to keep the numbers manageable, we start from 2 and limit the divisor to 50 for better gameplay experience. This way, the division questions will be more reasonable and less likely to produce very large or very small results, making it more suitable for a wider range of players
        int maxResult = 100 / divisor;
        int result = random.Next(1, maxResult + 1); // Calculate the maximum possible result based on the divisor to ensure that the generated division question remains within a reasonable range for players. This prevents generating questions that would yield very large results, which could be overwhelming or less engaging for players, especially younger ones. By limiting the result based on the divisor, we can create a more balanced and enjoyable gaming experience
        int dividend = divisor * result;

        return (dividend, divisor, "/", result);
    }

    // =============================== REALISATIONS ===============================
    public void StartAdditionGame()
    {
        RunGame(GenerateAddition, additionDescription); // Start the addition game by calling the RunGame method with the GenerateAddition function as the question generator and the addition description as the game introduction text
    }

    public void StartSubtractionGame()
    {
        RunGame(GenerateSubtraction, subtractionDescription);
    }

    public void StartMultiplicationGame()
    {
        RunGame(GenerateMultiplication, multiplicationDescription);
    }

    public void StartDivisionGame()
    {
        RunGame(GenerateDivision, divisionDescription);
    }

    // =============================== RANDOM OPERATIONS ===============================
    public void StartRandomOperationsGame()
    {
        RunGame(
            random =>
            {
                int operationType = random.Next(1, 5);

                return operationType switch
                {
                    1 => GenerateAddition(random),
                    2 => GenerateSubtraction(random),
                    3 => GenerateMultiplication(random),
                    4 => GenerateDivision(random),
                    _ => (0, 0, "", 0)
                };
            },
            randomOperationsDescription
        );
    }
}