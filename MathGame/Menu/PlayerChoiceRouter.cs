namespace MathGame.Menu;

public class PlayerChoiceRouter
{
    public static void Run(int playerMenuChoice)
    {
        if (playerMenuChoice is >=1 and <= 5)
        {
            TextDisplayMethods.PrintSeparator();
            GamesRouter.Run(playerMenuChoice, DifficultySelector.SelectDifficulty(GamesNamesList.Games[playerMenuChoice - 1])); // List starts from 0 
        }

        else if (playerMenuChoice is 0 or 8 or 9)
            ProcessRouter.Run(playerMenuChoice);
        else
            MinorExtensions.TypeWriteLine("\nInvalid choice. Please try again.\n");
    }
}