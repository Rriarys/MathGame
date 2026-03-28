while (true)
{
    Console.WriteLine
    (
    @"\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\
    \\\\ Welcome to the Math Game! \\\\
    \\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\"
    );

    Console.Write("\nPlease enter your name: ");
    string playerName = Console.ReadLine() ?? "Player"; // If the user doesn't enter a name, default to "Player"

    Console.WriteLine($"\nHello, {playerName}! Let's play the Math Game!");

    Console.WriteLine
    (
    @"Choose operation by entering the corresponding number:

    1. Addition
    2. Subtraction
    3. Multiplication
    4. Division
    5. Random operations
    9. Story of games
    0. Exit (default option)
    "
    );

    int operationChoice; // Loop until a valid choice is made
    while (true)
        {   
            Console.Write("\nEnter your choice: ");
            string? inputChoice = Console.ReadLine();
            operationChoice = inputChoice switch 
                {
                    "1" => 1,
                    "2" => 2,
                    "3" => 3,
                    "4" => 4,
                    "5" => 5,
                    "9" => 9,
                    "0" => 0,
                    _ => -1 // Invalid choice
                }; 

            if (operationChoice != -1)
                break; // Valid choice, exit the loop

            Console.WriteLine("\nInvalid choice. Please enter a number between 1 and 5, or 9 for the story, or 0 to exit.\n");
        }

    if (operationChoice == 0)
    {
        Console.WriteLine("\nThank you for playing the Math Game! Goodbye!");
        break; // Exit the game
    }
}