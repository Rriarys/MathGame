using MathGame.History;
using MathGame.Menu;

namespace MathGame;

public static class GamesRouter
{
public static void Run(int playerMenuChoice, int difficulty)    
{             
        OperationsTasks operationTask = new OperationsTasks(); // Create an instance of OperationsTasks to call the game methods

        switch (playerMenuChoice)
        {   
            // +
            case 1:
                {
                    TextDisplayMethods.PrintSeparator();
                    var (score, time) = operationTask.StartAdditionGame(difficulty);
                    GamesHistoryIO.SaveGame(PlayerNameKeeper.playerName, GamesNamesList.Games[playerMenuChoice], difficulty, score, time);
                    break;
                }
            // -
            case 2:
                {
                    TextDisplayMethods.PrintSeparator();
                    var (score, time) = operationTask.StartSubtractionGame(difficulty);
                    GamesHistoryIO.SaveGame(PlayerNameKeeper.playerName, GamesNamesList.Games[playerMenuChoice], difficulty, score, time);
                    break;
                } 
            // *
            case 3:
                {
                    TextDisplayMethods.PrintSeparator(); 
                    var (score, time) = operationTask.StartMultiplicationGame(difficulty);
                    GamesHistoryIO.SaveGame(PlayerNameKeeper.playerName, GamesNamesList.Games[playerMenuChoice], difficulty, score, time);
                    break;
                } 
            // /
            case 4:
                {
                    TextDisplayMethods.PrintSeparator(); 
                    var (score, time) = operationTask.StartDivisionGame(difficulty);
                    GamesHistoryIO.SaveGame(PlayerNameKeeper.playerName, GamesNamesList.Games[playerMenuChoice], difficulty, score, time);
                    break;
                }
            // Random operation
            case 5:
                {
                    TextDisplayMethods.PrintSeparator(); 
                    var (score, time) = operationTask.StartRandomOperationsGame(difficulty);
                    GamesHistoryIO.SaveGame(PlayerNameKeeper.playerName, GamesNamesList.Games[playerMenuChoice], difficulty, score, time);
                    break;     
                }
        }
    }
}