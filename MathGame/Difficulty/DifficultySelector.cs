using MathGame.Menu;

namespace MathGame;

public static class DifficultySelector
{
    public static int SelectDifficulty(string gameName)
    {   
        MinorExtensions.TypeWrite(GetDifficultyPrompt(gameName));
        
        return ValidateDifficulty(ReadUserInput());
    }

    public static string GetDifficultyPrompt(string gameName) =>
        $"\nYou choiced {gameName} game.\n" +
        "\nNow choose difficulty:\n" +
        "\n(1 - Easy, 2 - Medium, 3 - Hard, any other key - Random difficulty)\n\n" +
        "Enter difficulty (1-3): ";

    public static int ReadUserInput() =>
        int.TryParse(Console.ReadLine(), out var result) ? result : 0;

    public static int ValidateDifficulty(int userInput) =>
        userInput is >= 1 and <= 3 ? userInput : Random.Shared.Next(1, 4);
}
