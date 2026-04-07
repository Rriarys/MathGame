using MathGame.Menu;

namespace MathGame;

public static class GameEngine
{
    public static void Run()
    {
        string playerName = PlayerNameKeeper.GetPlayerName(); // Get the player's name 

        MenuTyper.Print(); // Print the menu
        PlayerMenuChoiseKeeper.GetPlayerMenuChoice();

        MenuHandler.RunMenu(playerName);
    }
}
