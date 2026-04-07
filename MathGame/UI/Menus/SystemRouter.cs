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
                PlayerProfile.GetPlayerName();
                break; 

            case 9:
                DisplayVisuals.PrintSeparator();
                ConsoleExtensions.StoryShowLoadingAnimation();
                HistoryService.LoadHistory();
                break;

            case 0:
                ConsoleExtensions.TypeWriteLine($"\nThank you, {PlayerProfile.playerName}, for playing the Math Game! Goodbye!");
                Thread.Sleep(2000);
                GameEngine.IsRunning = false; // Exit the program
                break;
        }
    } 
}
