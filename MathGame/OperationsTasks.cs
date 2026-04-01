namespace MathGame;

public class OperationsTasks
{
    // =============================== CORE ===============================
    private void RunGame(
        string symbol, // Symbol to display in the question (e.g., +, -, *, /)
        Func<int, int, int> operation, // Function that takes two integers and returns the result of the operation (e.g., addition, subtraction, multiplication, division)
        Func<Random, (int num1, int num2)> numberGenerator, // Function that generates two random numbers for the game based on the provided Random instance
        string description // Description of the game to display to the user at the start of the game
    )
    {
        int score = 0;
        Random random = new();

        Console.ForegroundColor = ConsoleColor.Magenta;
        MinorExtensions.TypeWrite(description);
        Console.ResetColor();

        for (int i = 0; i < 5; i++)
        {
            var (num1, num2) = numberGenerator(random); // Generate two random numbers for the question using the provided number generator

            Console.ForegroundColor = ConsoleColor.DarkYellow;
            MinorExtensions.TypeWriteLine($"Question {i + 1}: {num1} {symbol} {num2} is... ?");
            Console.ResetColor();

            int correctAnswer = operation(num1, num2); // Calculate the correct answer using the provided operation function

            int userAnswer;

            while (true)
            {
                MinorExtensions.TypeWrite("\nYour answer: ");
                string? userInput = Console.ReadLine();

                if(userInput is null || !int.TryParse(userInput, out userAnswer)) // Validate the user input to ensure it's a valid integer. If not, prompt the user to enter a valid answer.
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    MinorExtensions.TypeWrite("\nInvalid input. Please enter a valid integer answer: \n");
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

    public void StartAdditionGame()
    {
        RunGame(
            "+",
            (a, b) => a + b,
            random => (random.Next(1, 101), random.Next(1, 101)),
            @"Welcome to the Addition Game!
Calculate the sum of two numbers.

");
    }

    public void StartSubtractionGame()
    {
        RunGame(
            "-",
            (a, b) => a - b,
            random => (random.Next(1, 101), random.Next(1, 101)),
            @"Welcome to the Subtraction Game!
Calculate the difference between two numbers.

");
    }

    public void StartMultiplicationGame()
    {
        RunGame(
            "*",
            (a, b) => a * b,
            random => (random.Next(1, 101), random.Next(1, 101)),
            @"Welcome to the Multiplication Game!
Calculate the product of two numbers.

");
    }

    public void StartDivisionGame()
    {
        RunGame(
            "/",
            (a,b) => a / b,
            random =>
            {
                int num2 = random.Next(1, 101);
                int result = random.Next(1, 11);
                int num1 = num2 * result;
                return (num1, num2);
            },
            @"Welcome to the Division Game!
Calculate the quotient of two numbers.

");
    }

    public void StartRandomOperationsGame()
    {
        Random random = new();
        int operation = random.Next(1, 5);

        switch (operation)
        {
            case 1: StartAdditionGame(); break;
            case 2: StartSubtractionGame(); break;
            case 3: StartMultiplicationGame(); break;
            case 4: StartDivisionGame(); break;
        }
    }    
}

