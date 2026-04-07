namespace MathGame.Menu;

public class MainMenuRouter
{
    public static void Run(int playerMenuChoice)
    {
        if (playerMenuChoice is >=1 and <= 5)
        {
            DisplayVisuals.PrintSeparator();
            GameRouter.Run(playerMenuChoice, DifficultyService.SelectDifficulty(GamesNamesList.Games[playerMenuChoice - 1])); // List starts from 0 
        }

        else if (playerMenuChoice is 0 or 8 or 9)
            SystemRouter.Run(playerMenuChoice);
        else
        {
            Console.ForegroundColor = ConsoleColor.Yellow; 
            ConsoleExtensions.TypeWriteLine("\nInvalid choice. Please try again.\n");
        }
    }
}