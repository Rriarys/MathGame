using MathGame.Menu;

namespace MathGame;

public static class GameEngine
{
    public static bool IsRunning { get; set; } = true;
    public static void Run()
    {
        PlayerProfile.GetPlayerName(); // Get the player's name 

        while (IsRunning) // Main game loop, runs until IsRunning is set to false (menu 9 for change player's name or exit 0)
        {
            MenuPrinter.Print(); // Print the menu
            MainMenuRouter.Run(MenuInputHandler.GetChoice()); // Get the player's menu choice
        }

    }
}
