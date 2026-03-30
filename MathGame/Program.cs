using MathGame;

const string welcomeText = @"
 __  __       _   _        ____                      
|  \/  | __ _| |_| |__    / ___| __ _ _ __ ___   ___ 
| |\/| |/ _` | __| '_ \  | |  _ / _` | '_ ` _ \ / _ \
| |  | | (_| | |_| | | | | |_| | (_| | | | | | |  __/
|_|  |_|\__,_|\__|_| |_|  \____|\__,_|_| |_| |_|\___|
=====================================================
";

const string infoText = "Welcome to the Math Game! This is a fun and interactive game designed to help you practice and improve your math skills.";

const string signatureText = "Made by Rriarys";

const string menuText = @"
1. Addition
2. Subtraction
3. Multiplication
4. Division
5. Random operations
8. Change player session
9. Story of games
0. Exit";

// Print the welcome message, information message, and author signature with typewriting effects
TextDisplayMethods.PrintWelcomeMessage(welcomeText); // Print the welcome message with a typewriting effect

TextDisplayMethods.PrintInformationMessage(infoText, welcomeText.Split('\n').Max(l => l.Length)); // Print the info message with a typewriting effect

TextDisplayMethods.PrintAuthorSignature(signatureText); // Print the author signature with a typewriting effect

// =============================== MAIN PROGRAM ===============================
while (true)
{   
    TextDisplayMethods.PrintSeparator(); // Print a separator line to visually separate different sections of the console output

    MinorExtensions.TypeWrite("\nPlease enter your name: ");
    string playerName = Console.ReadLine() ?? "Player"; // If the user doesn't enter a name, default to "Player"

    Console.ForegroundColor = ConsoleColor.Magenta;
    MinorExtensions.TypeWriteLine($"\nHello, {playerName}! Let's play the Math Game!\n");
    Console.ResetColor();

    TextDisplayMethods.PrintSeparator();

    // Print the menu options for the user to choose from with a typewriting effect
    TextDisplayMethods.PrintMenu(menuText);

    OperationsTasks operationTask = new OperationsTasks(); // Create an instance of OperationsTasks to call the game methods
    
    while (true)
    {   
        // =============================== CHOICE OPERATION ===============================
        MinorExtensions.TypeWrite("\n\nEnter your choice: ");
        string? playerChoice = Console.ReadLine();
        Console.WriteLine();

        switch (playerChoice)
        {
            case "1": TextDisplayMethods.PrintSeparator(); operationTask.StartAdditionGame(); break;
            case "2": TextDisplayMethods.PrintSeparator(); operationTask.StartSubtractionGame(); break;
            case "3": TextDisplayMethods.PrintSeparator(); operationTask.StartMultiplicationGame(); break;
            case "4": TextDisplayMethods.PrintSeparator(); operationTask.StartDivisionGame(); break;
            case "5": TextDisplayMethods.PrintSeparator(); operationTask.StartRandomOperationsGame(); break;
            case "8": 
                TextDisplayMethods.PrintSeparator();

                Console.ForegroundColor = ConsoleColor.Green;
                MinorExtensions.PlayerNameChangingLoadingAnimation();
                Console.ResetColor();
                break; // This case allows the user to change their player session by showing a loading animation and then prompting them to enter their name again in the main game loop
            case "9": 
                TextDisplayMethods.PrintSeparator();

                Console.ForegroundColor = ConsoleColor.Green;
                MinorExtensions.StoryShowLoadingAnimation();
                Console.ResetColor();
                break;
            case "0":
                Console.ForegroundColor = ConsoleColor.Magenta;
                MinorExtensions.TypeWriteLine($"Thank you, {playerName}, for playing the Math Game! Goodbye!");
                Console.ResetColor();
                return; // Exit the program
            default:
                Console.ForegroundColor = ConsoleColor.Yellow;
                MinorExtensions.TypeWriteLine("Invalid choice. Please enter a valid number.");
                Console.ResetColor();
                continue; // Prompt the user again without breaking the loop
        }
    }
}