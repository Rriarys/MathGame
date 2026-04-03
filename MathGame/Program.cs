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

    bool isChangingPlayer = false; // Flag to track if the player session is being changed
    MinorExtensions.TypeWrite("Please enter your name: ");
    string playerName = Console.ReadLine()?.Trim() ?? "Player"; // If the user doesn't enter a name, default to "Player"

    Console.ForegroundColor = ConsoleColor.Magenta;
    MinorExtensions.TypeWriteLine($"\nHello, {playerName}! Let's play the Math Game!");
    Console.ResetColor();

    // Print the menu options for the user to choose from with a typewriting effect
    TextDisplayMethods.PrintMenu(menuText);

    OperationsTasks operationTask = new OperationsTasks(); // Create an instance of OperationsTasks to call the game methods

    int difficulty; // Variable to store the selected difficulty level for the games
    
    while (true)
    {   
        // =============================== CHOICE OPERATION ===============================
        MinorExtensions.TypeWrite("\nEnter your choice: ");
        string? playerChoice = Console.ReadLine()?.Trim();

        switch (playerChoice)
        {   
            // +
            case "1":
                {
                    TextDisplayMethods.PrintSeparator(); 
                    difficulty = MinorExtensions.SelectDifficulty("Addition game");
                    var (score, time) = operationTask.StartAdditionGame(difficulty);
                    GamesHistory.History.Add($"{playerName} - Addition Game - {difficulty} - Score: {score}, Time: {time:F2} seconds");
                    TextDisplayMethods.PrintMenu(menuText); break;
                }
            // -
            case "2":
                {
                    TextDisplayMethods.PrintSeparator();
                    difficulty = MinorExtensions.SelectDifficulty("Subtraction game");
                    var (score, time) = operationTask.StartSubtractionGame(difficulty);
                    GamesHistory.History.Add($"{playerName} - Subtraction Game - {difficulty} - Score: {score}, Time: {time:F2} seconds");
                    TextDisplayMethods.PrintMenu(menuText); break;
                } 
            // *
            case "3":
                {
                    TextDisplayMethods.PrintSeparator(); 
                    difficulty = MinorExtensions.SelectDifficulty("Multiplication game");
                    var (score, time) = operationTask.StartMultiplicationGame(difficulty);
                    GamesHistory.History.Add($"{playerName} - Multiplication Game - {difficulty} - Score: {score}, Time: {time:F2} seconds");
                    TextDisplayMethods.PrintMenu(menuText); break;
                } 
            // /
            case "4":
                {
                    TextDisplayMethods.PrintSeparator(); 
                    difficulty = MinorExtensions.SelectDifficulty("Division game");
                    var (score, time) = operationTask.StartDivisionGame(difficulty);
                    GamesHistory.History.Add($"{playerName} - Division Game - {difficulty} - Score: {score}, Time: {time:F2} seconds");
                    TextDisplayMethods.PrintMenu(menuText); break;
                }
            // Random operation
            case "5":
                {
                    TextDisplayMethods.PrintSeparator(); 
                    difficulty = MinorExtensions.SelectDifficulty("Random operations game");
                    var (score, time) = operationTask.StartRandomOperationsGame(difficulty);
                    GamesHistory.History.Add($"{playerName} - Random Operations Game - {difficulty} - Score: {score}, Time: {time:F2} seconds");
                    TextDisplayMethods.PrintMenu(menuText); break;     
                }
            // Change player
            case "8":
                {
                    TextDisplayMethods.PrintSeparator();
                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                    MinorExtensions.PlayerNameChangingLoadingAnimation();
                    Console.ResetColor();
                    isChangingPlayer = true; // Set the flag to indicate that the player session is being changed
                    break;
                }
            // Story of games. Not implemented
            case "9":
                {
                    TextDisplayMethods.PrintSeparator();

                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                    MinorExtensions.StoryShowLoadingAnimation();

                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                    if (!GamesHistory.History.Any())
                    {   
                        Console.WriteLine("No games played yet.");
                        break;
                    }

                    foreach (var i in GamesHistory.History)
                    {
                        Console.WriteLine(i);
                    }

                    Console.ResetColor();
                    TextDisplayMethods.PrintMenu(menuText);
                    break;
                }      
            // Exit the program
            case "0":
                {
                    Console.ForegroundColor = ConsoleColor.Magenta;
                    MinorExtensions.TypeWriteLine($"\nThank you, {playerName}, for playing the Math Game! Goodbye!");
                    Console.ResetColor();
                    return; // Exit the program
                }
            // Wrong input
            default:
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    MinorExtensions.TypeWriteLine("\nInvalid choice. Please enter a valid number.");
                    Console.ResetColor();
                    continue; // Prompt the user again without breaking the loop
                }
        }

        if (isChangingPlayer) // If the player session is being changed, break the inner loop to return to the outer loop and prompt for a new player name
            break;
    }
}