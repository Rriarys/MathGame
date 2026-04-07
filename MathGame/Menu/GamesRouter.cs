using MathGame.Engine;
using MathGame.History;
using MathGame.Menu;

namespace MathGame;

public static class GamesRouter
{
    private static readonly GameSession _gameSession = new();

    // Main entry point for starting a game from the menu selection
    public static void Run(int menuChoice, int difficulty)    
    {             
        string gameDescription = GetDescription(menuChoice);
        
        // Execute the game and capture results
        var (score, time) = _gameSession.Start(menuChoice, difficulty, gameDescription);

        // Persistent storage of the game outcome
        GamesHistoryIO.SaveGame(
            PlayerNameKeeper.playerName, 
            GamesNamesList.Games[menuChoice - 1], 
            difficulty, 
            score, 
            time.ToString(@"m'm 's's 'fff'ms'")
        );
    }

    // Maps the numeric menu choice to the corresponding game description text
    private static string GetDescription(int choice) => choice switch 
    {
        1 => TextsHandler.additionDescription,
        2 => TextsHandler.subtractionDescription,
        3 => TextsHandler.multiplicationDescription,
        4 => TextsHandler.divisionDescription,
        5 => TextsHandler.randomOperationsDescription,
        _ => string.Empty
    };
}