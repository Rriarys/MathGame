namespace MathGame.History;

public static class GamesHistoryIO
{
    public static void SaveGame(string name, string gameName, int diff, int score, string time)
    {
        GamesHistoryData.History.Add((name, gameName, diff, score, time));
    }

    public static void LoadHistory()
    {
        if (!GamesHistoryData.History.Any())
        {
            Console.WriteLine("\nNo games played yet.");
            return; 
        }

        TextDisplayMethods.PrintSmallSeparator();
        MinorExtensions.TypeWriteLine("\nGames History:\n\n");

        // Header
        Console.WriteLine($"{"Player",-15} | {"Game",-15} | {"Diff",-8} | {"Score",-7} | {"Time",-15}");
        Console.WriteLine(new string('-', 75));

        foreach (var game in GamesHistoryData.History)
        {

            string diffName = ((Difficulty)game.diff).ToString();


            Console.WriteLine($"{game.name.Cut(15),-15} | {game.game.Cut(15),-15} | {diffName,-8} | {game.score + "/5",-7} | {game.time,-15}");
        }
    }
}
