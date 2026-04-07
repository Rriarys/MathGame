using MathGame.Menu;

namespace MathGame;

public static class GameEngine
{
    public static void Run()
    {
        PlayerNameKeeper.GetPlayerName(); // Get the player's name 

        while (true)
        {
            MenuPrinter.Print(); // Print the menu
            PlayerChoiceRouter.Run(PlayerMenuChoiseKeeper.GetPlayerMenuChoice()); // Get the player's menu choice
        }

    }
}
