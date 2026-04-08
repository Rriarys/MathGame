namespace MathGame;

public static class DifficultyService
{
    public static int SelectDifficulty(string gameName)
    {   
        ConsoleExtensions.TypeWrite(GetDifficultyPrompt(gameName));

        int result = ValidateDifficulty(ReadUserInput());

        ConsoleExtensions.TypeWrite(GetDifficultyPromptResult(result));

        return result;
    }

    public static string GetDifficultyPrompt(string gameName)
    {
        Console.ForegroundColor = ConsoleColor.Cyan;
        return $"You choiced {gameName} game.\n" +
        "\nNow choose difficulty:\n" +
        "\n(1 - Easy, 2 - Medium, 3 - Hard, any other key - Random difficulty)\n\n";
    }

    public static int ReadUserInput()
    {
        Console.ForegroundColor = ConsoleColor.White;
        ConsoleExtensions.TypeWrite("Enter difficulty (1-3): ");
        return int.TryParse(Console.ReadLine(), out var result) ? result : 0; // Only integers are allowed
    }

    public static int ValidateDifficulty(int userInput) =>
        userInput is >= 1 and <= 3 ? userInput : Random.Shared.Next(1, 4);

    public static string GetDifficultyPromptResult(int result)
    {
        Difficulty selectedDifficulty = (Difficulty)result;

        Console.ForegroundColor = ConsoleColor.Cyan;
        return $"\nYou choiced {selectedDifficulty} difficulty.\n";
    }
}
