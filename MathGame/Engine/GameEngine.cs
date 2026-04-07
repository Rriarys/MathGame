using MathGame.Menu;

namespace MathGame;

public static class GameEngine
{
    public static bool IsRunning { get; set; } = true;
    public static void Run()
    {
        PlayerNameKeeper.GetPlayerName(); // Get the player's name 

        while (IsRunning)
        {
            MenuPrinter.Print(); // Print the menu
            PlayerChoiceRouter.Run(PlayerMenuChoiseKeeper.GetPlayerMenuChoice()); // Get the player's menu choice
        }

    }
}
