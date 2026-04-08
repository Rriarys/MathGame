using MathGame.History;

namespace MathGame.Menu;

public static class SystemRouter
{
    public static void Run(int playerMenuChoice)
    {
        switch (playerMenuChoice)
        {
            case 8:
                DisplayVisuals.PrintSeparator();
                ConsoleExtensions.PlayerNameChangingLoadingAnimation();
                DisplayVisuals.PrintSeparator();
                PlayerProfile.GetPlayerName(); // Get the player's name after the Engine restart
                break; 

            case 9:
                DisplayVisuals.PrintSeparator();
                ConsoleExtensions.StoryShowLoadingAnimation();
                HistoryService.LoadHistory(); // Load the game history
                break;

            case 0:
                DisplayVisuals.PrintSmallSeparator();
                Console.ForegroundColor = ConsoleColor.Magenta;
                ConsoleExtensions.TypeWriteLine($"\nThank you, {PlayerProfile.playerName}, for playing the Math Game! Goodbye!");
                Thread.Sleep(2000);
                GameEngine.IsRunning = false; // Exit the program
                break;
        }
    } 
}
