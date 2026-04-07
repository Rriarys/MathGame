namespace MathGame.Menu;

public class PlayerChoiceRouter
{
    public static void Run(int playerMenuChoice)
    {
        while (true)
        {
            if (playerMenuChoice is >=1 and <= 5)
            {
                GamesRouter.Run(playerMenuChoice, DifficultySelector.SelectDifficulty(GamesNamesList.Games[playerMenuChoice - 1])); // List starts from 0 
                break;
            }
            else if (playerMenuChoice is 0 or 8 or 9)
            {
                ProcessRouter.Run(playerMenuChoice);
                break;
            } 
            else
            {
                MinorExtensions.TypeWriteLine("\nInvalid choice. Please try again.\n");
                break;
            }
        }
    }
}