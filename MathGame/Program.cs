using MathGame;

// Save the original console colors to restore them later
var originalBg = Console.BackgroundColor;
var originalFg = Console.ForegroundColor;

// Initialize the console with a black background and white foreground for better look and readability of the game interface
Console.BackgroundColor = ConsoleColor.Black;
Console.ForegroundColor = ConsoleColor.White;

// Clear the console to apply the new background color and provide a clean slate for the game interface
Console.Clear();

try
{
// Print the welcome message, information message, and author signature with typewriting effects
TextDisplayMethods.PrintWelcomeMessage(TextsHandler.welcomeText); // Print the welcome message with a typewriting effect

TextDisplayMethods.PrintInformationMessage(TextsHandler.infoText, TextsHandler.welcomeText.Split('\n').Max(l => l.Length)); // Print the info message with a typewriting effect

TextDisplayMethods.PrintAuthorSignature(TextsHandler.signatureText); // Print the author signature with a typewriting effect



// =============================== MAIN PROGRAM ===============================
while (true)
{      
    TextDisplayMethods.PrintSeparator(); // Print a separator line to visually separate different sections of the console output

    bool isChangingPlayer = false; // Flag to track if the player session is being changed

    // Console.Write(new string(' ', Console.WindowWidth)); 
    // Console.SetCursorPosition(0, Console.CursorTop);

    string playerName = NameKeeper.GetPlayerName(); // Get the player's name 

    Console.ForegroundColor = ConsoleColor.Magenta;
    MinorExtensions.TypeWriteLine($"\nHello, {playerName}! Let's play the Math Game!");
    Console.ResetColor();

    // Print the menu options for the user to choose from with a typewriting effect
    TextDisplayMethods.PrintMenu(TextsHandler.menuText);

    OperationsTasks operationTask = new OperationsTasks(); // Create an instance of OperationsTasks to call the game methods

    int difficulty; // Variable to store the selected difficulty level for the games
    
    while (true)
    {   
        // =============================== CHOICE OPERATION ===============================
        Console.BackgroundColor = ConsoleColor.Black;
        MinorExtensions.TypeWrite("\nEnter your choice: ");
        string? playerChoice = Console.ReadLine()?.Trim();

        switch (playerChoice)
        {   
            // +
            case "1":
                {
                    TextDisplayMethods.PrintSeparator(); 
                    difficulty = DifficultySelector.SelectDifficulty("Addition game");
                    var (score, time) = operationTask.StartAdditionGame(difficulty);
                    GamesHistory.History.Add((playerName, "Addition game", difficulty, score, time));
                    TextDisplayMethods.PrintMenu(TextsHandler.menuText); break;
                }
            // -
            case "2":
                {
                    TextDisplayMethods.PrintSeparator();
                    difficulty = DifficultySelector.SelectDifficulty("Subtraction game");
                    var (score, time) = operationTask.StartSubtractionGame(difficulty);
                    GamesHistory.History.Add((playerName, "Subtraction game", difficulty, score, time));
                    TextDisplayMethods.PrintMenu(TextsHandler.menuText); break;
                } 
            // *
            case "3":
                {
                    TextDisplayMethods.PrintSeparator(); 
                    difficulty = DifficultySelector.SelectDifficulty("Multiplication game");
                    var (score, time) = operationTask.StartMultiplicationGame(difficulty);
                    GamesHistory.History.Add((playerName, "Multiplication game", difficulty, score, time));
                    TextDisplayMethods.PrintMenu(TextsHandler.menuText); break;
                } 
            // /
            case "4":
                {
                    TextDisplayMethods.PrintSeparator(); 
                    difficulty = DifficultySelector.SelectDifficulty("Division game");
                    var (score, time) = operationTask.StartDivisionGame(difficulty);
                    GamesHistory.History.Add((playerName, "Division game", difficulty, score, time));
                    TextDisplayMethods.PrintMenu(TextsHandler.menuText); break;
                }
            // Random operation
            case "5":
                {
                    TextDisplayMethods.PrintSeparator(); 
                    difficulty = DifficultySelector.SelectDifficulty("Random operations game");
                    var (score, time) = operationTask.StartRandomOperationsGame(difficulty);
                    GamesHistory.History.Add((playerName, "Random operations game", difficulty, score, time));
                    TextDisplayMethods.PrintMenu(TextsHandler.menuText); break;     
                }
            // Change player
            case "8":
                {
                    TextDisplayMethods.PrintSeparator();

                    Console.BackgroundColor = ConsoleColor.Black;
                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                    MinorExtensions.PlayerNameChangingLoadingAnimation();

                    Console.ForegroundColor = ConsoleColor.White;                   
                    isChangingPlayer = true; // Set the flag to indicate that the player session is being changed
                    break;
                }
            // Story of games. Not implemented
            case "9":
                {
                    TextDisplayMethods.PrintSeparator();

                    Console.BackgroundColor = ConsoleColor.Black;
                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                    MinorExtensions.StoryShowLoadingAnimation();

                    Console.BackgroundColor = ConsoleColor.Black;
                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                    if (!GamesHistory.History.Any())
                    {   
                        Console.WriteLine("\nNo games played yet.");
                        Console.ResetColor();
                        break;
                    }

                    TextDisplayMethods.PrintSmallSeparator();

                    Console.BackgroundColor = ConsoleColor.Black;
                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                    MinorExtensions.TypeWriteLine("\nGames History:\n\n");
                    Console.WriteLine($"{"Player",-15} | {"Game",-15} | {"Diff",-5} | {"Score",-5} | {"Time(s)",-10}");
                    Console.WriteLine(new string('-', 60));

                    foreach (var game in GamesHistory.History)
                    {
                        Console.WriteLine($"{game.name.Cut(15),-15} | {game.game,-15} | {((Difficulty)game.diff).ToString(),-5} | {game.score,-5} | {game.time,-10:F2}");
                    }

                    Console.ResetColor();
                    TextDisplayMethods.PrintMenu(TextsHandler.menuText);
                    break;
                }      
            // Exit the program
            case "0":
                {
                    Console.BackgroundColor = ConsoleColor.Black;
                    Console.ForegroundColor = ConsoleColor.Magenta;
                    MinorExtensions.TypeWriteLine($"\nThank you, {playerName}, for playing the Math Game! Goodbye!");
                    Console.ResetColor();
                    return; // Exit the program
                }
            // Wrong input
            default:
                {   
                    Console.BackgroundColor = ConsoleColor.Black;
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
}
finally
{
    // Restore the original colors
    Console.BackgroundColor = originalBg;
    Console.ForegroundColor = originalFg;
    Console.Clear();
}
