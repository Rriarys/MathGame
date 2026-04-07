using MathGame.Menu;

namespace MathGame;

public static class GameEngine
{
    public static bool IsRunning { get; set; } = true;
    public static void Run()
    {
        PlayerProfile.GetPlayerName(); // Get the player's name 

        while (IsRunning)
        {
            MenuPrinter.Print(); // Print the menu
            MainMenuRouter.Run(MenuInputHandler.GetChoice()); // Get the player's menu choice
        }

    }
}
