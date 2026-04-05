namespace MathGame;

public static class NameKeeper
{
    public static string GetPlayerName()
    {
        MinorExtensions.TypeWrite(GetNamePrompt());
        return ReadUserInput();
    }
    public static string GetNamePrompt() =>
        "\nPlease enter your name: ";

    public static string ReadUserInput() => 
         Console.ReadLine()?.Trim() ?? "Player"; // If the user doesn't enter a name, default to "Player"
}
