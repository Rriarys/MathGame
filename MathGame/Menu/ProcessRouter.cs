using MathGame.History;

namespace MathGame.Menu;

public static class ProcessRouter
{
    public static void Run(int playerMenuChoice)
    {
        switch (playerMenuChoice)
        {
            case 8:
                TextDisplayMethods.PrintSeparator();
                MinorExtensions.PlayerNameChangingLoadingAnimation();
                PlayerNameKeeper.GetPlayerName();
                break; 

            case 9:
                TextDisplayMethods.PrintSeparator();
                MinorExtensions.StoryShowLoadingAnimation();
                GamesHistoryIO.LoadHistory();
                break;

            case 0:
                MinorExtensions.TypeWriteLine($"\nThank you, {PlayerNameKeeper.playerName}, for playing the Math Game! Goodbye!");
                Thread.Sleep(2000);
                GameEngine.IsRunning = false; // Exit the program
                break;
        }
    } 
}
