namespace MathGame.History;

public static class GamesHistoryIO
{
    public static void SaveGame(string name, string gameName, int diff, int score, double time)
    {
        GamesHistoryData.History.Add((name, gameName, diff, score, time));
    }

    public static void LoadHistory()
    {
        
        if (!GamesHistoryData.History.Any())
        {   
            Console.WriteLine("\nNo games played yet.");
        }

        TextDisplayMethods.PrintSmallSeparator();

        MinorExtensions.TypeWriteLine("\nGames History:\n\n");
        Console.WriteLine($"{"Player",-15} | {"Game",-15} | {"Diff",-5} | {"Score",-5} | {"Time(s)",-10}");
        Console.WriteLine(new string('-', 60));

        foreach (var game in GamesHistoryData.History)
        {
            Console.WriteLine($"{game.name.Cut(15),-15} | {game.game.Cut(15),-15} | {((Difficulty)game.diff).ToString(),-5} | {game.score,-5} | {game.time,-10:F2}");
        }
                    
    }
}
