namespace MathGame;

public class OperationsTasks
{
    public void StartAdditionGame()
    {
        int score = 0; // Initialize score to keep track of correct answers
        Random random = new Random(); // Create a Random object to generate random numbers

        Console.WriteLine
        (
        @"Welcome to the Addition Game!
        In this game, you will be given two numbers, and you need to calculate their sum.
        Let's get started!"
        );

        for (int i = 0; i < 5; i++)
        {
            int number1 = random.Next(1, 101);
            int number2 = random.Next(1, 101);

            Console.WriteLine($"\nWhat is {number1} + {number2}?"); // Prompt the user with the addition question
            int correctAnswer = number1 + number2; // Game calculates the correct answer
            int userAnswer;
            while (true)
            {
                Console.Write("\nYour answer: "); string? userInput = Console.ReadLine();
                if (userInput is null || !int.TryParse(userInput, out userAnswer)) // Validate user input to ensure it's a valid integer
                {
                    Console.WriteLine("Invalid input. Please enter a valid answer type (number).");
                    continue; // Prompt the user again
                }

                break; // Valid input, exit the loop
            }

            if (userAnswer == correctAnswer)
                {
                    Console.WriteLine("Correct!");
                    score++;
                }
                else
                {
                    Console.WriteLine($"Incorrect. The correct answer is {correctAnswer}.");
                }
        }
        Console.WriteLine($"\nGame Over! Your final score is: {score}/5");
    }

    public void StartSubtractionGame()
    {
        // Similar structure to StartAdditionGame, but with subtraction logic
        int score = 0; // Initialize score to keep track of correct answers
        Random random = new Random(); // Create a Random object to generate random numbers

        Console.WriteLine
        (
        @"Welcome to the Subtraction Game!
        In this game, you will be given two numbers, and you need to calculate their difference.
        Let's get started!"
        );

        for (int i = 0; i < 5; i++)
        {
            int number1 = random.Next(1, 101);
            int number2 = random.Next(1, 101);

            Console.WriteLine($"\nWhat is {number1} - {number2}?"); // Prompt the user with the subtraction question
            int correctAnswer = number1 - number2; // Game calculates the correct answer
            int userAnswer;
            while (true)
            {
                Console.Write("\nYour answer: "); string? userInput = Console.ReadLine();
                if (userInput is null || !int.TryParse(userInput, out userAnswer)) // Validate user input to ensure it's a valid integer
                {
                    Console.WriteLine("Invalid input. Please enter a valid answer type (number).");
                    continue; // Prompt the user again
                }

                break; // Valid input, exit the loop
            }

            if (userAnswer == correctAnswer)
                {
                    Console.WriteLine("Correct!");
                    score++;
                }
                else
                {
                    Console.WriteLine($"Incorrect. The correct answer is {correctAnswer}.");
                }
        }
        Console.WriteLine($"\nGame Over! Your final score is: {score}/5");
    }

    public void StartMultiplicationGame()
    {
        // Similar structure to StartAdditionGame, but with multiplication logic
        int score = 0; // Initialize score to keep track of correct answers
        Random random = new Random(); // Create a Random object to generate random numbers

        Console.WriteLine
        (
        @"Welcome to the Multiplication Game!
        In this game, you will be given two numbers, and you need to calculate their product.
        Let's get started!"
        );

        for (int i = 0; i < 5; i++)
        {
            int number1 = random.Next(1, 101);
            int number2 = random.Next(1, 101);

            Console.WriteLine($"\nWhat is {number1} * {number2}?"); // Prompt the user with the multiplication question
            int correctAnswer = number1 * number2; // Game calculates the correct answer
            int userAnswer;
            while (true)
            {
                Console.Write("\nYour answer: "); string? userInput = Console.ReadLine();
                if (userInput is null || !int.TryParse(userInput, out userAnswer)) // Validate user input to ensure it's a valid integer
                {
                    Console.WriteLine("Invalid input. Please enter a valid answer type (number).");
                    continue; // Prompt the user again
                }

                break; // Valid input, exit the loop
            }

            if (userAnswer == correctAnswer)
                {
                    Console.WriteLine("Correct!");
                    score++;
                }
                else
                {
                    Console.WriteLine($"Incorrect. The correct answer is {correctAnswer}.");
                }
        }
        Console.WriteLine($"\nGame Over! Your final score is: {score}/5");
    }

    public void StartDivisionGame()
    {
        // Similar structure to StartAdditionGame, but with division logic
        int score = 0; // Initialize score to keep track of correct answers
        Random random = new Random(); // Create a Random object to generate random numbers

        Console.WriteLine
        (
        @"Welcome to the Division Game!
        In this game, you will be given two numbers, and you need to calculate their quotient.
        Let's get started!"
        );

        for (int i = 0; i < 5; i++)
        {   
            // In task said: "Ensure that the division will yield an integer result to avoid complications with decimal answers."
            int number2 = random.Next(1, 101);
            int maxResult = 100 / number2; // Calculate the maximum possible result to ensure the division will yield an integer
            int result = random.Next(1, maxResult + 1);
            int number1 = number2 * result; // Ensure that the division will yield an integer result

            Console.WriteLine($"\nWhat is {number1} / {number2}?"); // Prompt the user with the division question
            int correctAnswer = number1 / number2; // Game calculates the correct answer (integer division)
            int userAnswer;
            while (true)
            {
                Console.Write("\nYour answer: "); string? userInput = Console.ReadLine();
                if (userInput is null || !int.TryParse(userInput, out userAnswer)) // Validate user input to ensure it's a valid integer
                {
                    Console.WriteLine("Invalid input. Please enter a valid answer type (number).");
                    continue; // Prompt the user again
                }

                break; // Valid input, exit the loop
            }

            if (userAnswer == correctAnswer)
                {
                    Console.WriteLine("Correct!");
                    score++;
                }
                else
                {
                    Console.WriteLine($"Incorrect. The correct answer is {correctAnswer}.");
                }
        }
        Console.WriteLine($"\nGame Over! Your final score is: {score}/5");
    }

    public void StartRandomOperationsGame()
    {
        // This method can randomly select one of the four operations (addition, subtraction, multiplication, division) and call the corresponding game method
        Random random = new Random();
        int operation = random.Next(1, 5); // Generate a random number between 1 and 4 to select an operation

        switch (operation) // Methods dont return any value
        {
            case 1: StartAdditionGame(); break;
            case 2: StartSubtractionGame(); break;
            case 3: StartMultiplicationGame(); break;
            case 4: StartDivisionGame(); break;
        }
    }
}
