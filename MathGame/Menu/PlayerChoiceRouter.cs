using System.Security.Cryptography.X509Certificates;

namespace MathGame.Menu;

public class PlayerChoiceRouter
{
    public static void Run(int playerMenuChoice)
    {
        if (playerMenuChoice is >=1 and <= 5)
            GamesRouter.Run(playerMenuChoice, DifficultySelector.SelectDifficulty(GamesNamesList.Games[playerMenuChoice]));
        else ProcessRouter.Run(playerMenuChoice);
        
    }
}
