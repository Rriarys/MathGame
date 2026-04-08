namespace MathGame.History;

public static class HistoryService
{
    public static void SaveGame(string name, string gameName, int difficulty, int score, string time)
    {
        var record = new GameRecord(name, gameName, (Difficulty)difficulty, score, time);
        GamesHistoryData.History.Add(record);
    }

    public static void LoadHistory()
    {
        if (!GamesHistoryData.History.Any())
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\nNo games played yet.");
            return; 
        }

        DisplayVisuals.PrintSmallSeparator();
        Console.ForegroundColor = ConsoleColor.DarkGreen;
        ConsoleExtensions.TypeWriteLine("\nGames History:\n\n");

        // Header
        Console.WriteLine($"{"Player",-15} | {"Game",-15} | {"Diff",-8} | {"Score",-7} | {"Time",-15}");
        Console.WriteLine(new string('-', 75));

        foreach (var game in GamesHistoryData.History)
        {
            Console.WriteLine($"{game.PlayerName.Cut(15),-15} | {game.GameName.Cut(15),-15} | {game.Difficulty,-8} | {game.Score + "/5",-7} | {game.Time,-15}");
        }
    }
}
